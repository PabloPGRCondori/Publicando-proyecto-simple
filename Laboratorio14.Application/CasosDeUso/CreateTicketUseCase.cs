using System.Threading.Tasks;
using Laboratorio14.Domain.Repositorios;
using Laboratorio14.Application.Modelos;

namespace Laboratorio14.Application.CasosDeUso;

public class CreateTicketUseCase
{
    private readonly ITicketRepository _repository;

    public CreateTicketUseCase(ITicketRepository repository)
    {
        _repository = repository;
    }

    public async Task<Modelos.TicketDto> ExecuteAsync(string descripcion)
    {
        var ticket = new Laboratorio14.Domain.Modelos.Ticket { Descripcion = descripcion };
        var creado = await _repository.AddAsync(ticket);
        return new Modelos.TicketDto { Id = creado.Id, Descripcion = creado.Descripcion };
    }
}