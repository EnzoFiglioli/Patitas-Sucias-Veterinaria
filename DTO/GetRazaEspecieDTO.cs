using System;
using System.Collections.Generic;
using System.Text;

namespace MiAppVeterinaria.DTO
{
    class GetRazaEspecieDTO
    {
        public int IdRaza { get; set; }
        public string NombreRaza { get; set; }
        public int IdEspecie { get; set; }
        public string NombreEspecie { get; set; }

        public GetRazaEspecieDTO() { }

        public GetRazaEspecieDTO(int id_raza, string nombreRaza, int id_especie, string nombreEspecie)
        {
            this.IdRaza = id_raza;
            this.NombreRaza = nombreRaza;
            this.IdEspecie = id_especie;
            this.NombreEspecie = nombreEspecie;
        }
    }
}
