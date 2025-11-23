using Laboratorio14.Application.Servicios;
using Laboratorio14.Application.CasosDeUso;
using Laboratorio14.Infrastructure.Persistencia;
using Laboratorio14.Infrastructure.Repositorios;
using Laboratorio14.Domain.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Host=localhost;Port=5432;Database=ticketera;Username=postgres;Password=1234";

builder.Services.AddDbContext<Ticketeracontext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<ITicketRepository, EfTicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<CreateTicketUseCase>();
builder.Services.AddScoped<GetTicketByIdUseCase>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();