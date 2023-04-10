using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Auto_Showroom.Infrastructure.Repositories;

public class CarRepository:ICarRepository
{
    private readonly AppDbContext _context;

    public CarRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Car>> GetCars()
    {
       return _context.Car.ToListAsync();
    }

    public Task<Car> GetCarById(int id)
    {
        return _context.Car.Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddCar(Car car)
    {
        await _context.Car.AddAsync(car);
       await _context.SaveChangesAsync();
    }

    public async Task UpdateCar(Car car)
    {
        _context.Car.Update(car);
       await _context.SaveChangesAsync();
    }

    public async Task DeleteCar(Car car)
    {
        
        _context.Car.Remove(car);
        await _context.SaveChangesAsync();
    }
}

