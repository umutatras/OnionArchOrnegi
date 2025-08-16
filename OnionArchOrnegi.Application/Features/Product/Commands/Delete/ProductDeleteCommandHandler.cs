using MediatR;
using OnionArchOrnegi.Application.Interfaces;
using OnionArchOrnegi.Application.Models.General;

namespace OnionArchOrnegi.Application.Product.Commands.Delete;

public sealed class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, ResponseDto<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductDeleteCommandHandler(IUnitOfWork uow)
    {
        _unitOfWork = uow;
    }

    public async Task<ResponseDto<bool>> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
    {

        var product = await _unitOfWork.GetRepository<OnionArchOrnegi.Domain.Entities.Product>().FindAsync(request.Id);
        if (product is null)
        {
            return new ResponseDto<bool>(false, "product not found");
        }
        _unitOfWork.GetRepository<OnionArchOrnegi.Domain.Entities.Product>().Remove(product);
        int islemSonucu = await _unitOfWork.SaveChangesAsync();

        if (islemSonucu > 0)
        {
            return new ResponseDto<bool>(true, "product delete successfully");

        }
        return new ResponseDto<bool>(true, "product delete failure");
    }
}