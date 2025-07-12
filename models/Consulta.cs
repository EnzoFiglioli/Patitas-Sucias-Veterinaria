using System;

namespace MiAppVeterinaria.Models
{
    public class Consulta
    {
        public int id_consulta { get; set; }
        public int mascota_id { get; set; }
        public DateTime fecha { get; set; }
        public string síntomas { get; set; }
        public int veterinario_id { get; set; }
    }
}
