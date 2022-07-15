using Microsoft.IdentityModel.Tokens;
using ReferenceApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReferenceApi.Helper
{
    public class Tokenhelper
    {
        public async Task<string> GenerateJSONWebToken(UserInfo userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisismySecretKey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.LoginName),
            };
            var token = new JwtSecurityToken("Test.com",
              "Test.com",
              claims,
              expires: DateTime.Now.AddMinutes(100),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<string> GetUserFromToken(string token)
        {
            var jwtSecurityToken = new JwtSecurityToken(token);
            var claims = jwtSecurityToken.Claims.ToList();

            return claims[0].Value;
        }
    }
}
