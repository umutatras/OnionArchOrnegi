using OnionArchOrnegi.Application.Models.Identity;

namespace OnionArchOrnegi.Application.Interfaces;

public interface IIdentityService
{
    Task<bool> AuthenticateAsync(IdentityAuthenticateRequest request);
    Task<IdentityLoginResponse> LoginAsync(IdentityLoginRequest request);

    Task<bool> CheckEmailExistsAsync(string email);
    Task<IdentityRegisterResponse> RegisterAsync(IdentityRegisterRequest request);


    Task<bool> CheckSecurityStampAsync(int userId, string securityStamp);
    Task<IdentityRefreshTokenResponse> RefreshTokenAsync(IdentityRefreshTokenRequest request);
}
