using Auto_Showroom.Core.Dtos.OrderTest;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.OrderOperations.PutOrder;

public class UpdateOrderCommand
{ 
    public UpdateOrderTest Test { get; set; }
    public int PersonId { get; set; }
    
    private readonly TestDbContext testDb;
    public UpdateOrderCommand(TestDbContext db)
        {
            testDb = db;
        }

    public void Handle()
        {
            var order = testDb.Order.SingleOrDefault(p => p.PersonId == PersonId);
            if (order ==null)
            {
                throw new InvalidOperationException("Order with this PersonId not found");
            }

            order.PersonName = Test.PersonName != default ? Test.PersonName : order.PersonName;
            order.OrderDate = Test.OrderDate != default ? Test.OrderDate : order.OrderDate;
            order.OrderItem = Test.OrderItem != default ? Test.OrderItem : order.OrderItem;
            
            testDb.SaveChanges();
        }
        
}