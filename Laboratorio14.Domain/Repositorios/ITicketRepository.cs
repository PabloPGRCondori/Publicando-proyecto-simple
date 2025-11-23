using System.Threading.Tasks;

namespace Laboratorio14.Domain.Repositorios;

public interface ITicketRepository
{
    Task<Modelos.Ticket> AddAsync(Modelos.Ticket ticket);
    Task<Modelos.Ticket?> GetByIdAsync(int id);
}