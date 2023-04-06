namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.DeleteCar;

public class DeleteCarCommand
{
    private readonly TestDbContext testDb;
    public int CarId { get; set; }

    public DeleteCarCommand(TestDbContext db)
    {
        testDb = db;
    }

    public void Handle()
    {
        var car = testDb.Car.SingleOrDefault(p => p.Id == CarId);
        if (car == null)
        {
            throw new InvalidOperationException("Car not found");
        }

        testDb.Car.Remove(car);
        testDb.SaveChanges();
    }
}