using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sura.Dtos;
using sura.Models;

namespace sura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CitasController : ControllerBase
    {
        private readonly ContextoDB _contexto;
        private readonly ILogger _logger;

        public CitasController(ContextoDB contexto, ILogger<CitasController> logger)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IEnumerable<Cita> ListarCitas()
        {
            var citas = _contexto.Citas.ToList();
            _logger.LogInformation("Listado de citas: " + citas);
            return citas;
        }

        [HttpPost]
        public IActionResult CrearCita([FromBody] CitaDto citaDto)
        {
            var cita = new Cita();
            cita.Fecha = citaDto.Fecha;
            cita.Medico = citaDto.Medico;
            cita.Paciente = citaDto.Paciente;

            _contexto.Citas.Add(cita);
            _contexto.SaveChanges();

            return Ok();
        }

        [Route("{id}")]
        [HttpGet]
        public Cita BuscarCita(int id)
        {
            return _contexto.Citas.Find(id);
        }

    }
}
