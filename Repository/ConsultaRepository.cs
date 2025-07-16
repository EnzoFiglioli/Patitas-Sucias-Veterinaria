using MiAppVeterinaria.DTO;
using MiAppVeterinaria.handlers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


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
                        cmd.Parameters.AddWithValue("@i_MascotaID", consulta.MascotaId);
                        cmd.Parameters.AddWithValue("@i_Sintoma", consulta.Sintomas);
                        cmd.Parameters.AddWithValue("@i_Emergencia", consulta.Emergencia);
                        cmd.Parameters.AddWithValue("@i_Veterinario", consulta.VeterinarioId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear consulta: {ex.Message}");
                throw;
            }
        }
        public List<ConsultaDTO> ListarConsultas()
        {
            var listaHistorial = new List<ConsultaDTO>();
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().CreateConnection())
                {
                    conn.Open();

                    string query = "SELECT c.ConsultaId, c.Sintoma,c.FechaConsulta,c.Emergencia,c.Veterinario AS Veterinario,m.id_mascota AS MascotaId, m.nombre_mascota AS Mascota FROM Consulta c INNER JOIN Mascota m ON m.id_mascota = c.MascotaId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader()){
                            while (reader.Read())
                            {
                                ConsultaDTO c = new ConsultaDTO
                                { 
                                    Id = Convert.ToInt32(reader["ConsultaId"]),
                                    Sintomas = reader["Sintoma"].ToString(),
                                    Fecha = Convert.ToDateTime(reader["FechaConsulta"]),
                                    Veterinario = reader["Veterinario"].ToString(),
                                    Emergencia = Convert.ToBoolean(reader["Emergencia"]),
                                    MascotaId = Convert.ToInt32(reader["MascotaId"]), 
                                    Mascota = reader["Mascota"].ToString(),
                                };
                                listaHistorial.Add(c);
                            }
                        }
                    }
                }
                return listaHistorial;
            }
            catch(Exception)
            {
                throw;
            }
            return listaHistorial;
        }
    }
}
