using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionArchOrnegi.Application.Interfaces;
using OnionArchOrnegi.Application.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchOrnegi.Application.Features.Product.Queries.GetById;

public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ResponseDto<GetByIdProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cache;

    public GetByIdProductQueryHandler(IUnitOfWork uow, ICacheService cache)
    {
        _unitOfWork = uow;
        _cache = cache;
    }

    public async Task<ResponseDto<GetByIdProductResponse>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"product:{request.Id}";
        var product = await _cache.GetAsync<GetByIdProductResponse>(cacheKey);
        if (product != null)
        {
            return new ResponseDto<GetByIdProductResponse> { Data = product, Success = true, Message = string.Empty, Errors = null };
        }
        var result =await _unitOfWork.GetRepository<OnionArchOrnegi.Domain.Entities.Product>().GetQuery().Where(f=>f.Id==request.Id).Select(s=>new GetByIdProductResponse
        {
            Id=s.Id,
            Name=s.Name,
            Price=s.Price
        }).FirstOrDefaultAsync();
        await _cache.SetAsync(cacheKey, result, TimeSpan.FromHours(1));

        return new ResponseDto<GetByIdProductResponse> { Data = result, Success = true, Message = string.Empty, Errors = null };
    }
}