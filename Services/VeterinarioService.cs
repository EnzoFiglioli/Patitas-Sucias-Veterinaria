using MiAppVeterinaria.DTO;
using MiAppVeterinaria.Repository;
using System;
using System.Collections.Generic;


namespace MiAppVeterinaria.Services
{
    class VeterinarioService : IVeterinarioService
    {
        private readonly VeterinarioRepository veterinarioRepository = new VeterinarioRepository();
        public void CrearVeterinario(VeterinarioDTO veterinario)
        {
            try
            {
                veterinarioRepository.Crear(veterinario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VeterinarioDTO> ListarVeterinarios()
        {
            try
            {
                return veterinarioRepository.Obtener();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
