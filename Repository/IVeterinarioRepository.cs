using MiAppVeterinaria.DTO;
using System.Collections.Generic;

namespace MiAppVeterinaria.Repository
{
    interface IVeterinarioRepository
    {
        void Crear(VeterinarioDTO veterinario);
        List<VeterinarioDTO> Obtener();
    }
}
