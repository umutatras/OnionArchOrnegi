using MediatR;
using OnionArchOrnegi.Application.Models.General;

namespace OnionArchOrnegi.Application.Product.Commands.Update;

public class ProductUpdateCommand : IRequest<ResponseDto<bool>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
