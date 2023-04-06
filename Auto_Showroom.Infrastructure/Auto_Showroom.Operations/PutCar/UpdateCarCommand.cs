using Auto_Showroom.Core.Dtos;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.PutCar;

public class UpdateCarCommand
{
    public UpdateCarTest Test { get; set; }
    public int CarId { get; set; }

    private readonly TestDbContext testDb;

    public UpdateCarCommand(TestDbContext db)
    {
        testDb = db;
    }

    public void Handler()
    {
        var car = testDb.Car.SingleOrDefault(p => p.Id == CarId);
        if (car ==null)
        {
            throw new InvalidOperationException("Vehicle with this Id not found");
        }

        car.Model = Test.Model != default ? Test.Model : car.Model;
        car.Price = Test.Price != default ? Test.Price : car.Price;
        testDb.SaveChanges();
    }
    
}