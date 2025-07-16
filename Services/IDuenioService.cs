using System.Collections.Generic;
using MiAppVeterinaria.Models;

namespace MiAppVeterinaria.Services
{
    interface IDuenioService
    {
        bool RegistrarDuenio(Duenio d);
        List<Duenio> ObtenerDuenios();
    }
}
