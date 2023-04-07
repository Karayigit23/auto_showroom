using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Auto_Showroom.Infrastructure.Repositories;

public class Repository<T>:IRepository<T>where T:EntityBase
{
    private readonly AppDbContext _context;




}

