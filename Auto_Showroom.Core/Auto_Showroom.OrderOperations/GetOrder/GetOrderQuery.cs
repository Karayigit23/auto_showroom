using Auto_Showroom.Core.Dtos;
using Auto_Showroom.Core.Dtos.OrderTest;
using Auto_Showroom.Core.Model;
using Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.OrderOperations.GetOrder;

public class GetOrderQuery
{
    private readonly TestDbContext testDb;

    public GetOrderQuery(TestDbContext db)
    {
        testDb = db;
    }

    public List<OrderViewTest> Handle()
    {
        var orderlist = testDb.Order.OrderBy(p => p.PersonId).ToList<Order>();
        List<OrderViewTest> or = new List<OrderViewTest>();
        foreach (var order in orderlist)
        {
            or.Add(new OrderViewTest()
            {
                PersonName = order.PersonName,
                OrderItem = order.OrderItem,
                OrderDate = order.OrderDate


            });
        }

        return or;
    }
}