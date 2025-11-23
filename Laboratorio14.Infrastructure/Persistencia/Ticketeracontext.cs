using Laboratorio14.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio14.Infrastructure.Persistencia;

public class Ticketeracontext : DbContext
{
    public Ticketeracontext(DbContextOptions<Ticketeracontext> options) : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("tickets");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Descripcion).IsRequired();
        });
    }
}
