using System.Linq.Expressions;
using Auto_Showroom.Core.Model;

namespace Auto_Showroom.Core.Interfaces;
public interface IRepository
{
    Task<List<Car>> GetCar();
    Task<Car> GetCarById(int id);
    Task AddCar(Car car);
    Task UpdateCar(Car car);
    Task DeleteCar(int id);
}