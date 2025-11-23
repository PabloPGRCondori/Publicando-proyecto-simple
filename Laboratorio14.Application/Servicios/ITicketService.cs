using System.Threading.Tasks;

namespace Laboratorio14.Application.Servicios;

public interface ITicketService
{
    Task<Modelos.TicketDto> CrearAsync(string descripcion);
    Task<Modelos.TicketDto?> ObtenerPorIdAsync(int id);
}