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
    public GetByIdProductQueryHandler(IUnitOfWork uow)
    {
        _unitOfWork = uow;
    }

    public async Task<ResponseDto<GetByIdProductResponse>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        var result =await _unitOfWork.GetRepository<OnionArchOrnegi.Domain.Entities.Product>().GetQuery().Where(f=>f.Id==request.Id).Select(s=>new GetByIdProductResponse
        {
            Id=s.Id,
            Name=s.Name,
            Price=s.Price
        }).FirstOrDefaultAsync();
        
        return new ResponseDto<GetByIdProductResponse> { Data = result, Success = true, Message = string.Empty, Errors = null };
    }
}