using MediatR;
using OnionArchOrnegi.Application.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchOrnegi.Application.Features.Product.Queries.GetAll;

public class GetAllProductQuery : IRequest<ResponseDto<List<GetByIdProductResponse>>>
{
}
