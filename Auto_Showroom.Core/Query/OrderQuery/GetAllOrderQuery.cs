
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Auto_Showroom.Core.Query.OrderQuery;

public class GetAllOrderQuery:IRequest<List<Order>>
{
    
 public class GetAllOrderQueryHandler:IRequestHandler<GetAllOrderQuery,List<Order>>
 {
    private readonly IOrderRepository _OrderRepository;
    private readonly ILogger<GetAllOrderQueryHandler> _logger;

    public GetAllOrderQueryHandler(IOrderRepository orderRepository,ILogger<GetAllOrderQueryHandler> logger)
    {
        _OrderRepository = orderRepository;
        _logger = logger;
    }
    public async Task<List<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message:"All the orders have came");
        return await _OrderRepository.GetOrder();

           
          
           
           
    }
 }
}
