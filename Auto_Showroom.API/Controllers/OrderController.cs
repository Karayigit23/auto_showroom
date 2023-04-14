using System.Collections.Generic;
using System.Threading.Tasks;
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
    /// <summary>
    /// Get All Order
    /// </summary>
    /// <returns>List of orders</returns>
    [HttpGet]
    public async Task<List<Order>> Get()
    {
        
        return await _mediator.Send(new GetAllOrderQuery());
        
    }
    /// <summary>
    /// Get Order By Id
    /// </summary>
    /// <param name="OrderId">The ID of the order to retrieve</param>
    /// <returns>The retrieved order</returns>
    [HttpGet("{OrderId}")]
    public async Task<Order> GetById(int OrderId)
    {
        
        return await _mediator.Send( request: new GetOrderByIDQuery{Id = OrderId});
    }
    /// <summary>
    /// Create an Order
    /// </summary>
    /// <param name="newOrder">The data for the new order to be created</param>
    /// <returns></returns>
    [HttpPost]
    public async Task Post ([FromBody] CreateOrderCommand newOrder)
    {
        await _mediator.Send(newOrder);

    }
    /// <summary>
    /// Update the Order
    /// </summary>
    /// <param name="OrderId">The ID of the order to be updated</param>
    /// <param name="updateOrder">The updated order object</param>
    /// <returns></returns>
    [HttpPut("{OrderId}")]
    public async Task Put(int OrderId, [FromBody]  UpdateOrderCommand updateOrder)
    {
        if (OrderId!=updateOrder.Id)
        {
            BadRequest();
        }

        updateOrder.Id = OrderId;
        await _mediator.Send(updateOrder);
    }
    ///<summary>
    ///Delete the Order
    /// </summary>
    ///<param name="OrderId">The ID of the order to be deleted</param>
    ///<returns></returns>
    [HttpDelete("{OrderId}")]
    public async Task Delete(int OrderId)
    {
       
        await _mediator.Send( new DeleteOrderCommand(){Id = OrderId});
    }
}