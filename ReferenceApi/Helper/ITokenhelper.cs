using ReferenceApi.Models;

namespace ReferenceApi.Helper
{
    public interface ITokenhelper
    {
        string GenerateJSONWebToken(UserInfo userInfo);
        string GetUserFromToken(string token);
    }
}