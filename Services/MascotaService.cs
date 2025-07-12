using MiAppVeterinaria.Models;
using MiAppVeterinaria.Repository;
using MiAppVeterinaria.DTO;

using System;
using System.Collections.Generic;


namespace MiAppVeterinaria.Services
{
    class MascotaService : IMascotaService
    {
        public readonly MascotaRepository _mascotaRepository = new MascotaRepository();

        public MascotaService() { }

        public List<Mascota> GetMascotas()
        {
            List<Mascota> listaMascotas = new List<Mascota>();
            return _mascotaRepository.ObtenerMascotas();
        }
        public string CreateMascota(MascotaDTO mascota) {
            try
            {
                if (mascota == null)
                {
                    return "Todos los campos son necesario";
                }
                _mascotaRepository.CrearMascota(mascota);
                return "Mascota creada exitosamente";
            }
            catch (Exception ex)
            {
                return "Ocurrió un error al crear la mascota: " + ex.Message;
            }
        }
        public void DeleteMascotaById() { }
        public void UpdateMascotaById() { }
    }
}
