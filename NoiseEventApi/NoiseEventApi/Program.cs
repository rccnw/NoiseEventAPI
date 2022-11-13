using NoiseEventApi.Data;

const string corsPolicyNameAllowAll = "AllowAll";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => {
    o.AddPolicy( name: corsPolicyNameAllowAll, a => a.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});


var conn = new SqliteConnection($"Data Source=C:\\noiseevent\\noiseevent.db");
builder.Services.AddDbContext<NoiseEventDbContext>(o => o.UseSqlite(conn));

builder.Services.AddIdentityCore<ApiUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<NoiseEventDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
});

// global for all endpoints - instead of using RequireAuthorization() on each endpoint
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
    .RequireAuthenticatedUser()
    .Build();
});

builder.Host.UseSerilog((ctx, loggerConfiguration) =>
    loggerConfiguration.WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();             
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(policyName: corsPolicyNameAllowAll);

// declare minimal API's
#region Noise Event apis

// list events
app.MapGet("/noiseevents", async (NoiseEventDbContext db) => await db.NoiseEvents.ToListAsync()).AllowAnonymous();

// get an event
app.MapGet("/noiseevents/{id}", async (int id, NoiseEventDbContext db) =>
    await db.NoiseEvents.FindAsync(id) is NoiseEvent noiseEvent ? Results.Ok(noiseEvent) : Results.NotFound());

//update an event
app.MapPut("/noiseevents/{id}", async (int id, NoiseEvent noiseEvent, NoiseEventDbContext db) =>
{
    var record = await db.NoiseEvents.FindAsync(id);
    if (record is null) return Results.NotFound();

    record.Data = noiseEvent.Data;
    record.Type = noiseEvent.Type;
    record.UtcTime = noiseEvent.UtcTime;
    record.Longitude = noiseEvent.Longitude;
    record.Latitude = noiseEvent.Latitude;


    await db.SaveChangesAsync();

    return Results.NoContent();

});

// add an event
app.MapPost("/noiseevents", async (NoiseEvent noiseEvent, NoiseEventDbContext db) => {
    var result = await db.AddAsync(noiseEvent);
    var id = await db.SaveChangesAsync();

    return Results.Created($"/noiseevents/{noiseEvent.Id}", noiseEvent);

});

// delete an event
app.MapDelete("/noiseevents/{id}", async (int id, NoiseEventDbContext db) => {
    var record = await db.NoiseEvents.FindAsync(id);
    if (record is null) return Results.NotFound();
    db.Remove(record);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
#endregion

#region Identity apis

app.MapPost("/login", async (LoginDto loginDto, UserManager<ApiUser> _userManager) =>
{

    var user = await _userManager.FindByNameAsync(loginDto.Username);

    if (user is null)
    {
        return Results.Unauthorized();
    }

    var isValidPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);

    if (!isValidPassword)
    {
        return Results.Unauthorized();
    }

    // Generate an access token
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]));
    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var roles = await _userManager.GetRolesAsync(user);
    var claims = await _userManager.GetClaimsAsync(user);
    var tokenClaims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim("email_confirmed", user.EmailConfirmed.ToString())
    }.Union(claims)
    .Union(roles.Select(role => new Claim(ClaimTypes.Role, role)));

    var securityToken = new JwtSecurityToken(
        issuer: builder.Configuration["JwtSettings:Issuer"],
        audience: builder.Configuration["JwtSettings:Audience"],
        claims: tokenClaims,
        expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(builder.Configuration["JwtSettings:DurationInMinutes"])),
        signingCredentials: credentials
    );

    var accessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);


    var response = new AuthResponseDto
    {
        UserId = user.Id,
        Username = user.UserName,
        Token = accessToken
    };

    return Results.Ok(response);
}).AllowAnonymous();  // override global auth rules to allow anyone to get to the login endpoint

#endregion

app.Run();


internal class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

internal class AuthResponseDto
{
    public string UserId { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }
}