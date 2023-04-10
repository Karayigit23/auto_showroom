using Auto_Showroom.Core.Interfaces;
using MediatR;

namespace Auto_Showroom.Core.Command.OrderCommand;

public class DeleteOrderCommand:IRequest
{
    public int Id { get; set; }
}
public class DeleteOrderCommandHandle : IRequestHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    public DeleteOrderCommandHandle(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetById(request.Id);
        await _orderRepository.DeleteOrder(order);
       
    }
}  