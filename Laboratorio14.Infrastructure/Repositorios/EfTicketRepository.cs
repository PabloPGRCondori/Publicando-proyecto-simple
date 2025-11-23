using Laboratorio14.Domain.Repositorios;
using Laboratorio14.Domain.Modelos;
using Laboratorio14.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio14.Infrastructure.Repositorios;

public class EfTicketRepository : ITicketRepository
{
    private readonly Ticketeracontext _db;

    public EfTicketRepository(Ticketeracontext db)
    {
        _db = db;
    }

    public async Task<Ticket> AddAsync(Ticket ticket)
    {
        _db.Tickets.Add(ticket);
        await _db.SaveChangesAsync();
        return ticket;
    }

    public async Task<Ticket?> GetByIdAsync(int id)
    {
        return await _db.Tickets.FirstOrDefaultAsync(t => t.Id == id);
    }
}