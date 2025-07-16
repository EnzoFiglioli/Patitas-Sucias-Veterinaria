using System;
using System.Collections.Generic;
using System.Text;

using MiAppVeterinaria.Models;
using MiAppVeterinaria.Repository;

namespace MiAppVeterinaria.Services
{
    class DuenioService : IDuenioService
    {
        private readonly DuenioRepository duenioRepository = new DuenioRepository();
        public DuenioService() { }

        public bool RegistrarDuenio(Duenio d)
        {
            return true;
        }
        public List<Duenio> ObtenerDuenios()
        {
            return duenioRepository.ObtenerDuenios();
        }
    }
}
