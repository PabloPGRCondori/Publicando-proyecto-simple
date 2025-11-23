using Laboratorio14.Application.Servicios;
using Laboratorio14.Application.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio14.Adapters.Http;

[ApiController]
[Route("tickets")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _service;

    public TicketsController(ITicketService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<TicketDto>> Crear([FromBody] CreateTicketRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Descripcion))
            return BadRequest("La descripcion es requerida");

        var dto = await _service.CrearAsync(request.Descripcion);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = dto.Id }, dto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TicketDto>> ObtenerPorId([FromRoute] int id)
    {
        var dto = await _service.ObtenerPorIdAsync(id);
        if (dto == null)
            return NotFound();
        return Ok(dto);
    }
}