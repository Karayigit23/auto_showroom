using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;
using MediatR;

namespace Auto_Showroom.Core.Query.OrderQuery;

public class GetOrderByIDQuery:IRequest<Order>
{
    public int Id { get; set; }      
}

public class GetCarByIDHandle : IRequestHandler<GetOrderByIDQuery, Order>
{
    private readonly IOrderRepository _orderRepository;
    public GetCarByIDHandle(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Handle(GetOrderByIDQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetById(request.Id);
    }
}    

    
