using System;
using System.Collections.Generic;
using System.Text;
using MiAppVeterinaria.DTO;
using MiAppVeterinaria.Repository;


namespace MiAppVeterinaria.Services
{
    class ConsultaService : IConsultaService
    {
        private readonly ConsultaRepository consultaRepository = new ConsultaRepository();
        public void Crear(ConsultaDTO consultaDTO)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(consultaDTO.Sintomas)){
                    throw new ArgumentException("El sintoma es obligatorio.");
                }

                consultaRepository.CreateConsulta(consultaDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void EliminarPorId(int ConsultaId) { }
        public void ActualizarPorId(int ConsultaId) { }
        public List<ConsultaDTO> ObtenerTodas() { 
            List < ConsultaDTO > listaConsultas = new List<ConsultaDTO>();
            return listaConsultas;
        }
    }
}
