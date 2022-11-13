namespace NoiseEventApi.Interfaces
{
    public interface IAuthManager
    {
        Task<bool> Register(ApiUserDto userDto);
    }
}
