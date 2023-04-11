using Auto_Showroom.Core.Command.OrderCommand;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Core.Query.OrderQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Showroom.Controllers;
[ApiController]
[Route("orders")]
public class OrderController:ControllerBase
{
    private readonly IMediator _mediator;
    public OrderController(IMediator mediator)
    {
      
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<List<Order>> Get()
    {
        
        return await _mediator.Send(new GetAllOrderQuery());
        
    }
    [HttpGet("{OrderId}")]
    public async Task<Order> GetById(int OrderId)
    {
        
        return await _mediator.Send( request: new GetOrderByIDQuery{Id = OrderId});
    }
    [HttpPost]
    public async Task Post ([FromBody] CreateOrderCommand newOrder)
    {
        await _mediator.Send(newOrder);

    }
    [HttpPut("{OrderId}")]
    public async Task Put(int OrderId, [FromBody]  UpdateOrderCommand updateOrder)
    {
        if (OrderId!=updateOrder.OrderId)
        {
            BadRequest();
        }

        updateOrder.OrderId = OrderId;
        await _mediator.Send(updateOrder);
    }
    [HttpDelete("{OrderId}")]
    public async Task Delete(int OrderId)
    {
       
        await _mediator.Send( new DeleteOrderCommand(){Id = OrderId});
    }
}