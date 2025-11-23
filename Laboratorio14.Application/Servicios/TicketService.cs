using System.Threading.Tasks;

namespace Laboratorio14.Application.Servicios;

public class TicketService : ITicketService
{
    private readonly CasosDeUso.CreateTicketUseCase _create;
    private readonly CasosDeUso.GetTicketByIdUseCase _getById;

    public TicketService(CasosDeUso.CreateTicketUseCase create, CasosDeUso.GetTicketByIdUseCase getById)
    {
        _create = create;
        _getById = getById;
    }

    public Task<Modelos.TicketDto> CrearAsync(string descripcion)
    {
        return _create.ExecuteAsync(descripcion);
    }

    public Task<Modelos.TicketDto?> ObtenerPorIdAsync(int id)
    {
        return _getById.ExecuteAsync(id);
    }
}