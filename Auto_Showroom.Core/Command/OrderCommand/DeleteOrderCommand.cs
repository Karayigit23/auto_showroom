using Auto_Showroom.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Auto_Showroom.Core.Command.OrderCommand;

public class DeleteOrderCommand:IRequest
{
    public int Id { get; set; }
}
public class DeleteOrderCommandHandle : IRequestHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<DeleteOrderCommandHandle> _logger;
    public DeleteOrderCommandHandle(IOrderRepository orderRepository,ILogger<DeleteOrderCommandHandle> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;

    }

    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message:$"{request.Id} order called");
        var order = await _orderRepository.GetById(request.Id);
        if (order==null)
        {
            throw new Exception();
        }


        _logger.LogInformation(message: $"order deleted");
        
            
        await _orderRepository.DeleteOrder(order);
         //?? (çözüldü) sorun=>order başarılı bir şekilde siliniyor ama oluşturulan orderıtem silinen orderla beraber silinmiyor order ıtem delete işlemi yapılmaya çalışıldı ama başarılı olmadı
       return Unit.Value; //(sorun değilmiş) mediatR sürümünü düşürdüğüm için hata verdi oyüzden bu değişiklik yapldı (sürümün düşürme sebebim dependencyInjection sürümü mediatr ile uyuşmuyor)
    }
}  