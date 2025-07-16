using System;
using System.ComponentModel;

namespace MiAppVeterinaria.DTO
{
    public class ConsultaDTO
    {
        public int Id { get; set; }
        [Browsable(false)]
        public int MascotaId { get; set; }
        public string Mascota { get; set; }
        public DateTime Fecha { get; set; }
        public string Sintomas { get; set; }
        public bool Emergencia { get; set; }
        public string Veterinario { get; set; }
        [Browsable(false)]
        public int VeterinarioId { get; set; }
    }

}
