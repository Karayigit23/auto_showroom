using Auto_Showroom.Core.Command;
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;

namespace Auto_Showroom.Core.Query.OrderQuery;

public class GetAllOrderQuery:IRequest<List<Order>>
{
    
 public class GetAllCarQueryHandler:IRequestHandler<GetAllOrderQuery,List<Order>>
 {
    private readonly IOrderRepository _OrderRepository;

    public GetAllCarQueryHandler(IOrderRepository orderRepository)
    {
        _OrderRepository = orderRepository;
    }
    public async Task<List<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        return await _OrderRepository.GetOrder();

           
          
           
           
    }
 }
}
