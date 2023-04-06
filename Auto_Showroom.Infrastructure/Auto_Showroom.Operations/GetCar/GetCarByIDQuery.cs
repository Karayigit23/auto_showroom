using Auto_Showroom.Core.Dtos;
namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;

public class GetCarByIDQuery
{
    private readonly TestDbContext TestDb;
    public int CarId { get; set; }

    public GetCarByIDQuery(TestDbContext db)
    {
        TestDb = db;
    }

    public CarViewTest Handle()
    {
        var car = TestDb.Car.Where(p => p.Id == CarId).SingleOrDefault();
        if (car==null)
        {
            throw new InvalidOperationException("Car not found");
        }
        CarViewTest cr = new CarViewTest();

        cr.Model = car.Model; 
        cr.Price = car.Price;

            return cr;
    }
}