using System;
using System.Collections.Generic;
using System.Text;

using MiAppVeterinaria.DTO;

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
