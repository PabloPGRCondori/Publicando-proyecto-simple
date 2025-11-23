using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Laboratorio14.Infrastructure.Persistencia;

public class DesignTimeTicketeracontextFactory : IDesignTimeDbContextFactory<Ticketeracontext>
{
    public Ticketeracontext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Ticketeracontext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ticketera;Username=postgres;Password=1234");
        return new Ticketeracontext(optionsBuilder.Options);
    }
}
