using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchOrnegi.Application.Product.Commands.Add;
using OnionArchOrnegi.Application.Product.Commands.Delete;
using OnionArchOrnegi.Application.Product.Commands.Update;

namespace OnionArchOrnegi.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ApiControllerBase
{
    public ProductController(ISender mediatr) : base(mediatr)
    {
    }
    [HttpPost]
    public async Task<IActionResult> POST(ProductAddCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediatr.Send(command, cancellationToken));
    }
    [HttpPut]
    public async Task<IActionResult> PUT(ProductUpdateCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediatr.Send(command, cancellationToken));
    }
    [HttpDelete]
    public async Task<IActionResult> DELETE(ProductDeleteCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediatr.Send(command, cancellationToken));
    }
}
