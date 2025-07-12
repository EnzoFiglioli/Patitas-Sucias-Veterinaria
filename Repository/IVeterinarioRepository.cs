using System;
using System.Collections.Generic;
using System.Text;

using MiAppVeterinaria.DTO;

namespace MiAppVeterinaria.Repository
{
    interface IVeterinarioRepository
    {
        void Crear(VeterinarioDTO veterinario);
        List<VeterinarioDTO> Obtener();
    }
}
