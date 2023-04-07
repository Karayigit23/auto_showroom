using Auto_Showroom.Core.Interfaces;
using Auto_Showroom.Core.Model;
using MediatR;

namespace Auto_Showroom.Core.Command;

public class DeleteCarQuery:IRequest<Car>
{
    public int Id { get; set; }
}
public class DeleteCarQueryHandle : IRequestHandler<DeleteCarQuery, Car>
{
    private readonly IRepository _repository;
    public DeleteCarQueryHandle(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<Car> Handle(DeleteCarQuery request, CancellationToken cancellationToken)
    {
         await _repository.DeleteCar(request.Id);
        return request.Id;
    }
}  