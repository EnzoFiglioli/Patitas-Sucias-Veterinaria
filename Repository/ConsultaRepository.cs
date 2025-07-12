using System;
using System.Collections.Generic;
using System.Text;
using MiAppVeterinaria.DTO;
using MiAppVeterinaria.handlers;


using MySql.Data.MySqlClient;

namespace MiAppVeterinaria.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        public void CreateConsulta(ConsultaDTO consulta)
        {
            try
            {
                if (consulta == null)
                    throw new ArgumentNullException(nameof(consulta));

                if (consulta.MascotaId <= 0)
                    throw new ArgumentException("MascotaId inválido.");

                using (MySqlConnection conn = DBConnection.GetInstance().CreateConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Consulta(MascotaId, Sintoma, Emergencia, Veterinario) VALUES(@i_MascotaID, @i_Sintoma, @i_Emergencia, @i_Veterinario)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@i_MascotaID",consulta.MascotaId);
                        cmd.Parameters.AddWithValue("@i_Sintoma", consulta.Sintomas);
                        cmd.Parameters.AddWithValue("@i_Emergencia", consulta.Emergencia);
                        cmd.Parameters.AddWithValue("@i_Veterinario", consulta.VeterinarioId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error al crear consulta: {ex.Message}");
                throw;
            }
        }
    }
}
