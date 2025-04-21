using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Application.Features.Orders.CreateOrder;

namespace SimpleShop.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderCommand command, CancellationToken ct)
    {
        var orderId = await _mediator.Send(command, ct);
        return CreatedAtAction(nameof(CreateOrder), new { id = orderId }, new { orderId });
    }
}