using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using DS.Domain.ClientControll;
using DS.Infrastructure.Utils.ClientControll;

namespace DS.Service.ClientControll
{
    public class TokenService
    {
        public static string GenerateToken(User user)
        {
            Log.write(Log.Nivel.INFO, "UserName = " + user.username + " IN");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.secret);
            var tokenDescriptor = new SecurityTokenDescriptor

            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.username.ToString()),
                    new Claim(ClaimTypes.Role, user.role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
         
            return tokenHandler.WriteToken(token);
        }
    }
}
