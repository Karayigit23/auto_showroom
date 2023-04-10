using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;

namespace Auto_Showroom.Core.Query.OrderQuery;

public class GetOrderByIDQuery:IRequest<Order>
{
    public int Id { get; set; }      
}

public class GetOrderByIDHandle : IRequestHandler<GetOrderByIDQuery, Order>
{
    private readonly IOrderRepository _orderRepository;
    public GetOrderByIDHandle(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Handle(GetOrderByIDQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetById(request.Id);
    }
}    

    
