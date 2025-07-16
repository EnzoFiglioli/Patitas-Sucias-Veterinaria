using System;
using MiAppVeterinaria.DTO;
using MySql.Data.MySqlClient;
using MiAppVeterinaria.handlers;
using System.Collections.Generic;

namespace MiAppVeterinaria.Repository
{
    class TurnoRepository
    {
        public TurnoRepository() { }

        public string CrearTurno(TurnoDTO t)
        {
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().CreateConnection()){
                    conn.Open();
                    string query = $"INSERT INTO turno(IdMascota, IdVeterinario, FechaHora, Motivo) VALUES (@id_mascota, @id_veterinario, @fechaHora, @motivo)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_mascota",t.IdMascota);
                        cmd.Parameters.AddWithValue("@id_veterinario", t.IdVeterinario);
                        cmd.Parameters.AddWithValue("@fechaHora", t.FechaHora); 
                        cmd.Parameters.AddWithValue("@motivo", t.Motivo);

                        int resultado = cmd.ExecuteNonQuery();
                        if(resultado > 0)
                        {
                            return "Turno creado exitosamente!";
                        }
                        else
                        {
                            return "Error al crear turno.";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<TurnoAsignadoDTO> ListarTurnos()
        {
            var turnos = new List<TurnoAsignadoDTO>();
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().CreateConnection())
                {
                    conn.Open();
                    string query = "SELECT t.IdTurno, m.nombre_mascota AS NombreMascota, Concat(v.nombre, ' ', v.apellido) as 'Veterinario', t.Motivo, t.FechaHora FROM veter_patas_sucias.turno t INNER JOIN mascota m ON m.id_mascota = t.IdMascota INNER JOIN veterinario v ON v.VeterinarioId = t.IdVeterinario";
                    using (MySqlCommand cmd = new MySqlCommand(query,conn))
                    {
                        using(MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime fechaCompleta = Convert.ToDateTime(reader["FechaHora"]);

                                TurnoAsignadoDTO t = new TurnoAsignadoDTO
                                {
                                    Id = Convert.ToInt32(reader["IdTurno"]),
                                    Mascota = reader["NombreMascota"].ToString(),
                                    Veterinario = reader["Veterinario"].ToString(),
                                    Motivo = reader["Motivo"].ToString(),
                                    FechaTurno = fechaCompleta.Date,
                                    Hora = fechaCompleta.ToString("HH:mm")
                                };
                                turnos.Add(t);
                            }
                        }
                    }
                    
                }
                return turnos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
