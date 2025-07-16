using System.Collections.Generic;
using MiAppVeterinaria.Models;
using MiAppVeterinaria.DTO;

namespace MiAppVeterinaria.Services
{
    interface ITurnoService
    {
        List<Turno> ObtenerTurnos();
        string RegistrarTurno(TurnoDTO turnoDTO);
    }
}
