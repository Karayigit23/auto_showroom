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
    private readonly IOrderItemRepository _orderItemRepository;
    public DeleteOrderCommandHandle(IOrderRepository orderRepository,IOrderItemRepository orderItemRepository )
    {
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
    }

    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetById(request.Id);
      
        
        await _orderRepository.DeleteOrder(order);
         //?? (çözüldü) sorun=>order başarılı bir şekilde siliniyor ama oluşturulan orderıtem silinen orderla beraber silinmiyor order ıtem delete işlemi yapılmaya çalışıldı ama başarılı olmadı
       return Unit.Value; //(sorun değilmiş) mediatR sürümünü düşürdüğüm için hata verdi oyüzden bu değişiklik yapldı (sürümün düşürme sebebim dependencyInjection sürümü mediatr ile uyuşmuyor)
    }
}  