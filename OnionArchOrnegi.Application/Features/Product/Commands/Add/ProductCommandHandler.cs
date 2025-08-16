using MediatR;
using OnionArchOrnegi.Application.Interfaces;
using OnionArchOrnegi.Application.Mappings.Product;
using OnionArchOrnegi.Application.Models.General;
using OnionArchOrnegi.Domain.Entities;

namespace OnionArchOrnegi.Application.Product.Commands.Add;

public sealed class ProductCommandHandler : IRequestHandler<ProductAddCommand, ResponseDto<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly ICacheService _cacheService;

    public ProductCommandHandler(IUnitOfWork uow, ICurrentUserService currentUserService, ICacheService cacheService)
    {
        _unitOfWork = uow;
        _currentUserService = currentUserService;
        _cacheService = cacheService;
    }

    public async Task<ResponseDto<bool>> Handle(ProductAddCommand request, CancellationToken cancellationToken)
    {
        var product = request.ToEntity();
        product.CreatedByUserId = _currentUserService.UserId;
        product.CreatedOn = DateTime.UtcNow;
        var productRepository = _unitOfWork.GetRepository<OnionArchOrnegi.Domain.Entities.Product>();
        await productRepository.AddAsync(product);
        int islemSonucu = await _unitOfWork.SaveChangesAsync();
        // Cache Invalidation
        await _cacheService.RemoveAsync("products:all");
        if (islemSonucu > 0)
        {
            return new ResponseDto<bool>(true, "product added successfully");

        }
        return new ResponseDto<bool>(true, "product added failure");
    }
}
