using Auto_Showroom.Core.Dtos;
using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Auto_Showroom.Infrastructure.Auto_Showroom.Operations.GetCar;


public class GetCarByIdRequestCommand : IRequest<Car>
{

    public int Id { get; set; }      
}

public class GetCarByIDHandle : IRequestHandler<GetCarByIdRequestCommand, Car>
{
    private readonly IRepository _repository;
    public GetCarByIDHandle(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Car> Handle(GetCarByIdRequestCommand request, CancellationToken cancellationToken)
    {
        return await _repository.GetCarById(request.Id);
    }
}    
       

      

    
  