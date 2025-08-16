using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionArchOrnegi.Application.Interfaces;
using OnionArchOrnegi.Application.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchOrnegi.Application.Features.Product.Queries.GetAll;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, ResponseDto<List<GetByIdProductResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cache;

    public GetAllProductQueryHandler(IUnitOfWork uow, ICacheService cache)
    {
        _unitOfWork = uow;
        _cache = cache;
    }

    public async Task<ResponseDto<List<GetByIdProductResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = "products:all";
        var products = await _cache.GetAsync<List<GetByIdProductResponse>>(cacheKey);
        if (products != null)
        {
            return new ResponseDto<List<GetByIdProductResponse>> { Data = products, Success = true, Message = string.Empty, Errors = null };
        }
        var result =await _unitOfWork.GetRepository<OnionArchOrnegi.Domain.Entities.Product>().GetQuery().Select(s=>new GetByIdProductResponse
        {
            Id=s.Id,
            Name=s.Name,
            Price=s.Price
        }).ToListAsync();
        await _cache.SetAsync(cacheKey, result, TimeSpan.FromHours(1));

        return new ResponseDto<List<GetByIdProductResponse>> { Data = result, Success = true, Message = string.Empty, Errors = null };
    }
}