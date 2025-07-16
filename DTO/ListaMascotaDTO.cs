using System;

namespace MiAppVeterinaria.DTO
{
    public class ListaMascotaDTO
    {
        public int Id { get; set; }
        public string Sintomas { get; set; }
        public string Veterinario { get; set; }
        public string Mascota { get; set; }

        public bool Emergencia { get; set; }
        public DateTime FechaConsulta { get; set; }

        public ListaMascotaDTO() { }
        public ListaMascotaDTO(int id, string sintomas, string nombreyApellido, string mascota, bool emergencia, DateTime fechaConsulta)
        {
            Id = id;
            Sintomas = sintomas;
            Veterinario = nombreyApellido;
            Emergencia = emergencia;
            Mascota = mascota;
            FechaConsulta = fechaConsulta;
        }
    }
}
