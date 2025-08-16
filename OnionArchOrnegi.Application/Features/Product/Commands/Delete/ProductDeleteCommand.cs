using MediatR;
using OnionArchOrnegi.Application.Models.General;

namespace OnionArchOrnegi.Application.Product.Commands.Delete;

public sealed class ProductDeleteCommand : IRequest<ResponseDto<bool>>
{
    public int Id { get; set; }
}
