using MediatR;
using OnionArchOrnegi.Application.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchOrnegi.Application.Features.Product.Queries.GetById;

public class GetByIdProductQuery : IRequest<ResponseDto<GetByIdProductResponse>>
{
    public int Id { get; set; }
    public GetByIdProductQuery(int id)
    {
        Id = id;
    }
}
