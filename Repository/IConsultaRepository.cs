using System;
using System.Collections.Generic;
using System.Text;
using MiAppVeterinaria.DTO;

namespace MiAppVeterinaria.Repository
{
    interface IConsultaRepository
    {
        void CreateConsulta(ConsultaDTO consulta);
    }
}
