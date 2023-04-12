using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;

namespace Auto_Showroom.Core.Query.OrderItemQuery;

public class GetOrderItemByIdQuery:IRequest<OrderItem>
{
    public int Id { get; set; }
    
    
}

public class GetOrderItemByIdHandle : IRequestHandler<GetOrderItemByIdQuery, OrderItem>
{
    private readonly IOrderItemRepository _orderItemRepository;

    public GetOrderItemByIdHandle(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }
    public async Task<OrderItem> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    {
        return await _orderItemRepository.GetOrderItemById(request.Id);
    }
}