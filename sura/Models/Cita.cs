using System;
namespace sura.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Medico { get; set; }
        public string Paciente { get; set; }
    }
}
