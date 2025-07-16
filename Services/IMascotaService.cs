using MiAppVeterinaria.DTO;
using MiAppVeterinaria.Models;
using System.Collections.Generic;
using System.ComponentModel;



namespace MiAppVeterinaria.Services
{
    interface IMascotaService
    {
        BindingList<Mascota> GetMascotas();
        string CreateMascota(MascotaDTO mascota);
        string DeleteMascotaById(int IdMascota);
        void UpdateMascotaById();
    }
}
