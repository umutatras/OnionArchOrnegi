using OnionArchOrnegi.Application.Models.Jwt;

namespace OnionArchOrnegi.Application.Interfaces;

public interface IJwtService
{
    JwtGenerateTokenResponse GenerateToken(JwtGenerateTokenRequest request);
    bool ValidateToken(string token);

    int GetUserIdFromJwt(string token);
}
