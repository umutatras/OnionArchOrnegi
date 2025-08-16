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
    public GetAllProductQueryHandler(IUnitOfWork uow)
    {
        _unitOfWork = uow;
    }

    public async Task<ResponseDto<List<GetByIdProductResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var result =await _unitOfWork.GetRepository<OnionArchOrnegi.Domain.Entities.Product>().GetQuery().Select(s=>new GetByIdProductResponse
        {
            Id=s.Id,
            Name=s.Name,
            Price=s.Price
        }).ToListAsync();
        
        return new ResponseDto<List<GetByIdProductResponse>> { Data = result, Success = true, Message = string.Empty, Errors = null };
    }
}