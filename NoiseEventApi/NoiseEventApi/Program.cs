using NoiseEventApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => {
    o.AddPolicy("AllowAll", a => a.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});


var conn = new SqliteConnection($"Data Source=C:\\noiseevent\\noiseevent.db");
builder.Services.AddDbContext<NoiseEventDbContext>(o => o.UseSqlite(conn));

//builder.Services.AddIdentityCore<IdentityUser>()
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<NoiseEventDbContext>();

//builder.Services.AddAuthentication(options => {
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options => {
//    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
//        ValidateAudience = true,
//        ValidAudience = builder.Configuration["JwtSettings:Audience"],
//        ValidateLifetime = true,
//        ClockSkew = TimeSpan.Zero,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
//    };
//});

//builder.Services.AddAuthorization(options => {
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
//    .RequireAuthenticatedUser()
//    .Build();
//});

//builder.Host.UseSerilog((ctx, lc) =>
//    lc.WriteTo.Console()
//    .ReadFrom.Configuration(ctx.Configuration));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();             
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

// declare minimal API's
#region apis

// list events
app.MapGet("/noiseevents", async (NoiseEventDbContext db) => await db.NoiseEvents.ToListAsync()).AllowAnonymous();

// get an event
app.MapGet("/noiseevents/{id}", async (int id, NoiseEventDbContext db) =>
    await db.NoiseEvents.FindAsync(id) is NoiseEvent noiseEvent ? Results.Ok(noiseEvent) : Results.NotFound());

//update an event
app.MapPut("/noiseevents/{id}", async (int id, NoiseEvent noiseEvent, NoiseEventDbContext db) => {
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

app.Run();
