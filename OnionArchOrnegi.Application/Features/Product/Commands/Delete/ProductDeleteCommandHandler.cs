using MediatR;
using OnionArchOrnegi.Application.Interfaces;
using OnionArchOrnegi.Application.Models.General;

namespace OnionArchOrnegi.Application.Product.Commands.Delete;

public sealed class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, ResponseDto<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cache;

    public ProductDeleteCommandHandler(IUnitOfWork uow, ICacheService cache)
    {
        _unitOfWork = uow;
        _cache = cache;
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
        await _cache.RemoveAsync($"product:{product.Id}");
        await _cache.RemoveAsync("products:all");
        if (islemSonucu > 0)
        {
            return new ResponseDto<bool>(true, "product delete successfully");

        }
        return new ResponseDto<bool>(true, "product delete failure");
    }
}