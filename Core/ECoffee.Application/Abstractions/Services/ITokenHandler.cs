namespace ECoffee.Application.Abstractions.Services
{
    public interface ITokenHandler
    {
        string CreateAccessToken(string email);
    }
}
