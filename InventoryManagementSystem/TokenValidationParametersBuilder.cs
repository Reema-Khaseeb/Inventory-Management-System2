using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InventoryManagementSystem;
public class TokenValidationParametersBuilder
{
    private TokenValidationParameters _parameters;

    public TokenValidationParametersBuilder()
    {
        _parameters = new TokenValidationParameters();
    }

    public TokenValidationParametersBuilder WithSecretKey(string secretKey)
    {
        _parameters.ValidateIssuerSigningKey = true;
        _parameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        return this;
    }

    public TokenValidationParametersBuilder WithDefaultValidationParameters()
    {
        _parameters.ValidateIssuer = false;
        _parameters.ValidateAudience = false;
        _parameters.ValidateLifetime = true;
        _parameters.ValidateIssuerSigningKey = true;
        return this;
    }

    public TokenValidationParameters Build()
    {
        return _parameters;
    }
}

