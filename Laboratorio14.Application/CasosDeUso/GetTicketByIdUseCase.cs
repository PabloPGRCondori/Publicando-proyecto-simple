using System.Threading.Tasks;
using Laboratorio14.Domain.Repositorios;
using Laboratorio14.Application.Modelos;

namespace Laboratorio14.Application.CasosDeUso;

public class GetTicketByIdUseCase
{
    private readonly ITicketRepository _repository;

    public GetTicketByIdUseCase(ITicketRepository repository)
    {
        _repository = repository;
    }

    public async Task<Modelos.TicketDto?> ExecuteAsync(int id)
    {
        var ticket = await _repository.GetByIdAsync(id);
        return ticket == null ? null : new Modelos.TicketDto { Id = ticket.Id, Descripcion = ticket.Descripcion };
    }
}