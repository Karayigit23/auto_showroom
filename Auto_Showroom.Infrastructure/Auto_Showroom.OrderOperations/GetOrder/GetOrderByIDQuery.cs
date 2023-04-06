using Auto_Showroom.Core.Dtos.OrderTest;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.OrderOperations.GetOrder;

public class GetOrderByIDQuery
{
    private readonly TestDbContext testDb;
    public int OrderId { get; set; }

    public GetOrderByIDQuery(TestDbContext db)
    {  testDb = db;
    }
    public OrderViewTest Handle()
    {
        var order = testDb.Order.Where(p => p.PersonId ==OrderId).SingleOrDefault();
        if (order==null)
        {
            throw new InvalidOperationException("Order not found");
        }
        OrderViewTest or = new OrderViewTest();

        or.PersonName= order.PersonName; 
        or.OrderDate = or.OrderDate;
        or.Orderİtem = or.Orderİtem;

        return or;
    }
}