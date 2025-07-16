using MiAppVeterinaria.DTO;
using System.Collections.Generic;

namespace MiAppVeterinaria.Services
{
    interface IVeterinarioService
    {
        void CrearVeterinario(VeterinarioDTO veterinario);
        List<VeterinarioDTO> ListarVeterinarios();

    }
}
