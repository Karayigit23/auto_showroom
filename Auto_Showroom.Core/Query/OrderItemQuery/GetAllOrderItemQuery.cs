using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Core.Query.OrderQuery;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Auto_Showroom.Core.Query.OrderItemQuery;

public class GetAllOrderItemQuery:IRequest<List<OrderItem>>
{
    public class GetAllOrderItemQueryHandler : IRequestHandler<GetAllOrderItemQuery, List<OrderItem>>
    {
        
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ILogger<GetAllOrderItemQueryHandler> _logger;

        public GetAllOrderItemQueryHandler(IOrderItemRepository orderItemRepository,ILogger<GetAllOrderItemQueryHandler> logger)
        {
            _orderItemRepository = orderItemRepository;
            _logger = logger;
        }

        public async Task<List<OrderItem>> Handle(GetAllOrderItemQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(message:"All the orderItems have came");
            return await _orderItemRepository.GetOrderItem();
        }
    }
  
}