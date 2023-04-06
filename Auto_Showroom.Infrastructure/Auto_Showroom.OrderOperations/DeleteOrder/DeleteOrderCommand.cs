namespace Auto_Showroom.Infrastructure.Auto_Showroom.OrderOperations.DeleteOrder;

public class DeleteOrderCommand
{
    private readonly TestDbContext testDb;
    public int PersonId { get; set; }

    public DeleteOrderCommand(TestDbContext db)
    {
        testDb = db;
    }

    public void Handle()
    {
        var order = testDb.Order.SingleOrDefault(p => p.PersonId == PersonId);
        if (order == null)
        {
            throw new InvalidOperationException("Order not found");
        }

        testDb.Order.Remove(order);
        testDb.SaveChanges();
    }
}