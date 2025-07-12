using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

using MiAppVeterinaria.handlers;
using MiAppVeterinaria.Models;
using MiAppVeterinaria.DTO;
using MiAppVeterinaria.Repository;


namespace MiAppVeterinaria.Services
{
    class VeterinarioService : IVeterinarioService
    {
        private readonly VeterinarioRepository veterinarioRepository = new VeterinarioRepository();
        public void CrearVeterinario(VeterinarioDTO veterinario) {
            try
            {
                veterinarioRepository.Crear(veterinario);
            }
            catch(Exception ex)
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
