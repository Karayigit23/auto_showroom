using Auto_Showroom.Core.Command;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Core.Query.OrderItemQuery;
using Auto_Showroom.Core.Query.OrderQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auto_Showroom.Controllers;

[ApiController]
[Route("orderıtems")]
public class OrderItemController:ControllerBase
{
    private readonly IMediator _mediator;

        public OrderItemController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<OrderItem>> Get()
        {

            return await _mediator.Send(new GetAllOrderItemQuery());

        }
      

        

}