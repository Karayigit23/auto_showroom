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
         testDb.Car.OrderBy(p => p.Id).
     
    }

   
}