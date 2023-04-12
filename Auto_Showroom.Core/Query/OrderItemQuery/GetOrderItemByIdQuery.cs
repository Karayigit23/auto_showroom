using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Auto_Showroom.Core.Query.OrderItemQuery;

public class GetOrderItemByIdQuery:IRequest<OrderItem>
{
    public int Id { get; set; }
    
    
}

public class GetOrderItemByIdHandle : IRequestHandler<GetOrderItemByIdQuery, OrderItem>
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly ILogger<GetOrderItemByIdHandle> _logger;

    public GetOrderItemByIdHandle(IOrderItemRepository orderItemRepository, ILogger<GetOrderItemByIdHandle> logger)
    {
        _orderItemRepository = orderItemRepository;
        _logger = logger;
    }
    public async Task<OrderItem> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message:$"{request.Id} orderItem came"); //?? ama bu loga gerek yok emin değilim
        return await _orderItemRepository.GetOrderItemById(request.Id);
    }
}