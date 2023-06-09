using System.Linq.Expressions;
using Auto_Showroom.Core.Model;

namespace Auto_Showroom.Core.Interfaces;
public interface ICarRepository
{
    Task<List<Car>> GetCars();
    Task<Car> GetCarById(int id);
    Task AddCar(Car car);
    Task UpdateCar(Car car);
    Task DeleteCar(Car car);
}