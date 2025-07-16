using MiAppVeterinaria.DTO;
using MiAppVeterinaria.handlers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MiAppVeterinaria.Repository
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        public void Crear(VeterinarioDTO v)
        {
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().CreateConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("CrearVeterinario", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@i_Nombre", v.Nombre);
                        cmd.Parameters.AddWithValue("@i_Apellido", v.Apellido);
                        cmd.Parameters.AddWithValue("@i_Disponible", v.Disponible);
                        cmd.Parameters.AddWithValue("@i_Contacto", v.Contacto);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VeterinarioDTO> Obtener()
        {
            List<VeterinarioDTO> listaVeterinarios = new List<VeterinarioDTO>();
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().CreateConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("ListarVeterinarios", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VeterinarioDTO v = new VeterinarioDTO
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    Contacto = reader["Contacto"].ToString(),
                                    Disponible = Convert.ToBoolean(reader["Disponible"])
                                };
                                listaVeterinarios.Add(v);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaVeterinarios;
        }
    }
}
