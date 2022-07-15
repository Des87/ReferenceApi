using ReferenceApi.Models;

namespace ReferenceApi.Helper
{
    public interface ITokenhelper
    {
        Task<string> GenerateJSONWebToken(UserInfo userInfo);
        Task<string> GetUserFromToken(string token);
    }
}