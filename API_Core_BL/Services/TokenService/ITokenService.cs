namespace API_Core_BL.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateToken(string username, string role);
    }
}
