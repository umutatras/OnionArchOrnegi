using MediatR;
using OnionArchOrnegi.Application.Models.General;

namespace OnionArchOrnegi.Application.Product.Commands.Add;

public sealed class ProductAddCommand : IRequest<ResponseDto<bool>>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
