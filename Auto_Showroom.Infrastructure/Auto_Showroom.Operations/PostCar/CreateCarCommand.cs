using Auto_Showroom.Core.Dtos;
using Auto_Showroom.Core.Model;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PostCar;

public class CreateCarCommand
{
    public CreateCarTest Test { get; set; }
    private readonly TestDbContext testDb;
    public CreateCarCommand(TestDbContext db )
    {
         testDb = db;
        
    }

    public void Handler()
    {
        var car = testDb.Car.SingleOrDefault(p => p.Model == Test.Model);
        if (car !=null)
        {
            throw new InvalidOperationException("this car is registered");
        }
        else
        {
            car = new Car();
            car.Model = Test.Model;
            car.Price = Test.Price;
        }

        testDb.Car.Add(car);
      //  testDb.Orderİtem.Add(car.Id);
        testDb.SaveChanges();
    }
}