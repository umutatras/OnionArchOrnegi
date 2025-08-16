using MediatR;
using OnionArchOrnegi.Application.Interfaces;
using OnionArchOrnegi.Application.Models.General;
using OnionArchOrnegi.Application.Models.Identity;

namespace OnionArchOrnegi.Application.Features.Auth.RefreshToken;
public sealed class AuthRefreshTokenCommandHandler : IRequestHandler<AuthRefreshTokenCommand, ResponseDto<AuthRefreshTokenResponse>>
{
    private readonly IIdentityService _identityService;

    public AuthRefreshTokenCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<ResponseDto<AuthRefreshTokenResponse>> Handle(AuthRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var identityRefreshTokenRequest = new IdentityRefreshTokenRequest(request.AccessToken, request.RefreshToken);

        var identityRefreshTokenResponse = await _identityService.RefreshTokenAsync(identityRefreshTokenRequest);

        return new ResponseDto<AuthRefreshTokenResponse>(new AuthRefreshTokenResponse(identityRefreshTokenResponse.AccessToken, identityRefreshTokenResponse.Expires), "Token refreshed successfully");
    }
}
