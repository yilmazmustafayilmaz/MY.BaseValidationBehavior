using AutoMapper;
using BaseValidationBehavior.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseValidationBehavior.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand createProductCommand) => Created("", await _mediator.Send(createProductCommand));
}
