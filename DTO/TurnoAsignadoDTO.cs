using System;
using System.Collections.Generic;
using System.Text;

namespace MiAppVeterinaria.DTO
{
    class TurnoAsignadoDTO
    {
        public int Id { get; set; }
        public string Mascota { get; set; }
        public string Veterinario { get; set; }
        public DateTime FechaTurno { get; set; }
        public string Hora { get; set; }
        public string Motivo { get; set; }
    }
}
