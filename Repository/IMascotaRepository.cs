using MiAppVeterinaria.Models;
using MiAppVeterinaria.DTO;

using System.Collections.Generic;
using System.ComponentModel;

namespace MiAppVeterinaria.Repository
{
    interface IMascotaRepository
    {
        BindingList<Mascota> ObtenerMascotas();
        List<GetRazaEspecieDTO> ObtenerRazaAnimalId(int id);
        string CrearMascota(MascotaDTO mascota);
        string EliminarMascotaPorId(int id);
    }
}
