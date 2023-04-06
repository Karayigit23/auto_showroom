using Auto_Showroom.Core.Dtos.OrderTest;
using Auto_Showroom.Core.Model;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.OrderOperations.PostOrder;

public class CreateOrderCommand
{
    public CreateOrderTest Test { get; set; }
    public Orderİtem Item { get; set;}
    private readonly TestDbContext testDb;
    public CreateOrderCommand(TestDbContext db )
    {
        testDb = db;
        
    }

    public void Handle()
    {
        var order = testDb.Order.SingleOrDefault(p => p.PersonName == Test.PersonName);

        if (order != null)
        {
            throw new InvalidOperationException("this order is registered");
        }
        else
        {
            order = new Order();
            order.PersonName = Test.PersonName;
            order.OrderDate = Test.OrderDate;
            order.Orderİtem.Id = Item.Id;
        }

        testDb.Order.Add(order);

        testDb.SaveChanges();
    }
}