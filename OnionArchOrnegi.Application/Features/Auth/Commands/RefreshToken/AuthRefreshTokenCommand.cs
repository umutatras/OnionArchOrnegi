using MediatR;
using OnionArchOrnegi.Application.Models.General;


namespace OnionArchOrnegi.Application.Features.Auth.RefreshToken;

public sealed class AuthRefreshTokenCommand : IRequest<ResponseDto<AuthRefreshTokenResponse>>
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public AuthRefreshTokenCommand()
    {

    }
    public AuthRefreshTokenCommand(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
}
