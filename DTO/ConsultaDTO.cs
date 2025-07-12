using System;
using System.Collections.Generic;
using System.Text;

namespace MiAppVeterinaria.DTO
{
    public class ConsultaDTO
    {
        public int MascotaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Sintomas { get; set; }
        public bool Emergencia{ get; set; }

        public int VeterinarioId { get; set; }
    }


}
