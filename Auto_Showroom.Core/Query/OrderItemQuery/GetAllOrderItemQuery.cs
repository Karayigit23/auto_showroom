using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Core.Query.OrderQuery;
using MediatR;

namespace Auto_Showroom.Core.Query.OrderItemQuery;

public class GetAllOrderItemQuery:IRequest<List<OrderItem>>
{
    public class GetAllOrderItemQueryHandler : IRequestHandler<GetAllOrderItemQuery, List<OrderItem>>
    {
        
        private readonly IOrderItemRepository _orderItemRepository;

        public GetAllOrderItemQueryHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<List<OrderItem>> Handle(GetAllOrderItemQuery request, CancellationToken cancellationToken)
        {
            return await _orderItemRepository.GetOrderItem();
        }
    }
  
}