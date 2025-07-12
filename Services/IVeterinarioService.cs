using System;
using System.Collections.Generic;
using System.Text;
using MiAppVeterinaria.DTO;

namespace MiAppVeterinaria.Services
{
    interface IVeterinarioService
    {
        void CrearVeterinario(VeterinarioDTO veterinario);
        List<VeterinarioDTO> ListarVeterinarios();

    }
}
