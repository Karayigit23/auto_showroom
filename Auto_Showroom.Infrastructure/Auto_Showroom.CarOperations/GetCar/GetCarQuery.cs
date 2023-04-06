using Auto_Showroom.Core.Dtos;
using Auto_Showroom.Core.Model;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;

public class GetCarQuery
{
    private readonly TestDbContext testDb;

    public GetCarQuery(TestDbContext db)
    {
        testDb = db;
    }

    public List<CarViewTest> Handle()
    {
        var carlist = testDb.Car.OrderBy(p => p.Id).ToList<Car>();
        List<CarViewTest> cr = new List<CarViewTest>();
        foreach (var car in carlist)
        {
            cr.Add(new CarViewTest()
            {
                Model = car.Model,
                Price = car.Price

            });

        }

        return cr;
    }

   
}