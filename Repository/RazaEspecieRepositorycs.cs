using MiAppVeterinaria.DTO;
using MiAppVeterinaria.handlers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MiAppVeterinaria.Repository
{
    public class RazaEspecieRepository
    {
        public List<EspecieDTO> ObtenerEspecies()
        {
            var lista = new List<EspecieDTO>();
            using (var conn = DBConnection.GetInstance().CreateConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT id_especie, nombre_especie FROM especie", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new EspecieDTO
                        {
                            Id = Convert.ToInt32(reader["id_especie"]),
                            Nombre = reader["nombre_especie"].ToString()
                        });
                    }
                }
            }
            return lista;
        }


        public List<RazaDTO> ObtenerRazasPorEspecie(int idEspecie)
        {
            var lista = new List<RazaDTO>();
            using (var conn = DBConnection.GetInstance().CreateConnection())
            {
                conn.Open();
                var query = @"SELECT id_raza, nombre_raza FROM raza WHERE especie = @idEspecie";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idEspecie", idEspecie);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new RazaDTO
                        {
                            Id = Convert.ToInt32(reader["id_raza"]),
                            Nombre = reader["nombre_raza"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

    }

}
