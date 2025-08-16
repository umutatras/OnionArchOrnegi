using MediatR;
using OnionArchOrnegi.Application.Interfaces;
using OnionArchOrnegi.Application.Mappings.Product;
using OnionArchOrnegi.Application.Models.General;
using OnionArchOrnegi.Application.Product.Commands.Update;
using OnionArchOrnegi.Domain.Entities;

namespace OnionArchOrnegi.Application.Product.Invoice.Commands.Update;

public sealed class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, ResponseDto<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly ICacheService _cache;

    public ProductUpdateCommandHandler(IUnitOfWork uow, ICurrentUserService currentUserService, ICacheService cache)
    {
        _unitOfWork = uow;
        _currentUserService = currentUserService;
        _cache = cache;
    }

    public async Task<ResponseDto<bool>> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {

        var product = await _unitOfWork.GetRepository<OnionArchOrnegi.Domain.Entities.Product>().FindAsync(request.Id);
        if (product is null)
        {
            return new ResponseDto<bool>(false, "Product not found");
        }
        product = request.ToEntity(product);
        product.ModifiedByUserId = _currentUserService.UserId;
        product.ModifiedOn = DateTime.UtcNow;
        int islemSonucu =await  _unitOfWork.SaveChangesAsync();
        await _cache.RemoveAsync($"product:{product.Id}");
        await _cache.RemoveAsync("products:all");
        if (islemSonucu > 0)
        {
            return new ResponseDto<bool>(true, "Product update successfully");

        }
        return new ResponseDto<bool>(true, "Product update failure");
    }
}