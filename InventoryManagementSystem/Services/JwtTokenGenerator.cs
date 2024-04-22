using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagementSystem.Services;
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly string _secretKey;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _secretKey = configuration["Authentication:SecretKey"]
            ?? throw new ArgumentNullException(nameof(configuration));
    }

    public string GenerateToken(User user)
    {
        const int expiringDays = 2;
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GetClaimsIdentity(user),
            Expires = DateTime.UtcNow.AddDays(expiringDays), // Token expiration time
            SigningCredentials = CreateSigningCredentials(_secretKey)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            tokenHandler.ValidateToken(token, GetTokenValidationParameters(), out _);
            return true;
        }
        catch (SecurityTokenException)
        {
            // Token validation failed
            return false;
        }
    }

    private ClaimsIdentity GetClaimsIdentity(User user)
    {
        return new ClaimsIdentity(new[]
        {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // token unique identifier; preventing token replay attacks
        new Claim(ClaimTypes.Role, user.Role.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
        });
    }

    private TokenValidationParameters GetTokenValidationParameters()
    {
        return new TokenValidationParametersBuilder()
            .WithSecretKey(_secretKey)
            .WithDefaultValidationParameters()
            .Build();
    }

    private SigningCredentials CreateSigningCredentials(string secretKey)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        return new SigningCredentials(
            symmetricSecurityKey,
            SecurityAlgorithms.HmacSha256Signature);
    }
}
