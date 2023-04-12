using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Auto_Showroom.Core.Query.OrderQuery;

public class GetOrderByIDQuery:IRequest<Order>
{
    public int Id { get; set; }      
}

public class GetOrderByIDHandle : IRequestHandler<GetOrderByIDQuery, Order>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<GetOrderByIDHandle> _logger;
    public GetOrderByIDHandle(IOrderRepository orderRepository,ILogger<GetOrderByIDHandle> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<Order> Handle(GetOrderByIDQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message:$"{request.Id} order came");
        return await _orderRepository.GetById(request.Id);
    }
}    

    
