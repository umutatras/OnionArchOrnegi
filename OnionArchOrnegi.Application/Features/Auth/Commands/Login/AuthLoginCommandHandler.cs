using MediatR;
using OnionArchOrnegi.Application.Interfaces;
using OnionArchOrnegi.Application.Models.General;

namespace OnionArchOrnegi.Application.Features.Auth.Commands.Login;

public class AuthLoginCommandHandler : IRequestHandler<AuthLoginCommand, ResponseDto<AuthLoginDto>>
{
    private readonly IIdentityService _identityService;

    public AuthLoginCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<ResponseDto<AuthLoginDto>> Handle(AuthLoginCommand request, CancellationToken cancellationToken)
    {
        var response = await _identityService.LoginAsync(request.ToIdentityLoginRequest());
        return new ResponseDto<AuthLoginDto>(AuthLoginDto.FromIdentityLoginResponse(response));
    }


}
