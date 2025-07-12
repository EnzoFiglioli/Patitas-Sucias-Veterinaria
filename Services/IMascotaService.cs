using System;
using System.Collections.Generic;
using System.Text;
using MiAppVeterinaria.Models;
using MiAppVeterinaria.DTO;


namespace MiAppVeterinaria.Services
{
    interface IMascotaService
    {
        List<Mascota> GetMascotas();
        string CreateMascota(MascotaDTO mascota);
        void DeleteMascotaById();
        void UpdateMascotaById();
    }
}
