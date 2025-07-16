using MiAppVeterinaria.DTO;
using System.Collections.Generic;

namespace MiAppVeterinaria.Services
{
    interface IConsultaService
    {
        void Crear(ConsultaDTO consultaDTO);
        void EliminarPorId(int ConsultaId);
        void ActualizarPorId(int ConsultaId);
        List<ConsultaDTO> ObtenerTodas();

    }
}
