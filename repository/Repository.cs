using System;
using System.Collections.Generic;
using System.Text;
using MiAppVeterinaria.models;

namespace MiAppVeterinaria.repository
{
    class Repository
    {
        public static List<Mascota> Mascotas { get; set; } = new List<Mascota>();
        public static List<Veterinario> Veterinarios { get; set; } = new List<Veterinario>();
        public static List<Turno> Turnos { get; set; } = new List<Turno>();
    }
}
