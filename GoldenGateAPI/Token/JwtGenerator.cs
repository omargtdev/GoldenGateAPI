using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GoldenGateAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace GoldenGateAPI.Token;

public class JwtGenerator : IJwtGenerator
{
    // Compose by 3 elements: Header Payload(Jwt Data) Signature
    public string CreateToken(User user)
    {
        // Every property of tha data to store (payload) is called a claim
        var claims = new List<Claim> {
            //          key                         :   value
            new Claim(JwtRegisteredClaimNames.NameId, user.UserName!),
            new Claim("userId", user.Id),
            new Claim("email", user.Email!),
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("MySecretKey")
        );

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescription = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(claims), // Payload
            Expires = DateTime.Now.AddDays(30),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescription);

        return tokenHandler.WriteToken(token);
    }
}
