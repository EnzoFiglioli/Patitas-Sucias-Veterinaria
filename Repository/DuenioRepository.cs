using MiAppVeterinaria.handlers;
using MiAppVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MiAppVeterinaria.Repository
{
    class DuenioRepository
    {
        public DuenioRepository() { }

        public bool RegistrarDuenio(string nombre, string apellido, string contacto)
        {
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().CreateConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("crear_duenio", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@i_nombre", nombre);
                        cmd.Parameters.AddWithValue("@i_apellido", apellido);
                        cmd.Parameters.AddWithValue("@i_contacto", contacto);

                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public List<Duenio> ObtenerDuenios()
        {
            List<Duenio> listaDuenio = new List<Duenio>();
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().CreateConnection())
                {
                    conn.Open();
                    string query = "SELECT id_duenio, nombre, apellido, contacto FROM duenio ORDER BY nombre";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Duenio d = new Duenio
                                {
                                    Id = Convert.ToInt32(reader["id_duenio"]),
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    Contacto = reader["contacto"].ToString()
                                };
                                listaDuenio.Add(d);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar dueños", ex);
            }
            return listaDuenio;
        }
    }
}
