using MiAppVeterinaria.DTO;
using MiAppVeterinaria.handlers;
using MiAppVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MiAppVeterinaria.Repository
{
    class MascotaRepository
    {
        public MascotaRepository() { }

        public List<Mascota> ObtenerMascotas()
        {
            List<Mascota> listaMascotas = new List<Mascota>();
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().CreateConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("ListarMascotas", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Mascota m = new Mascota
                                {
                                    Id = Convert.ToInt32(reader["ID"]),
                                    Nombre = reader["Mascota"].ToString(),
                                    Especie = reader["Especie"].ToString(),
                                    Raza = reader["Raza"].ToString(),
                                    Edad = Convert.ToInt32(reader["Edad"]),
                                    Peso = Convert.ToDecimal(reader["Peso"]),
                                    NombreCompletoDuenio = reader["Nombre y Apellido"].ToString(),
                                    ContactoDuenio = reader["Contacto"].ToString()
                                };

                                listaMascotas.Add(m);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaMascotas;
        }

        private List<GetRazaEspecieDTO> ObtenerRazaAnimalId(int id)
        {
            List<GetRazaEspecieDTO> listarRazas = new List<GetRazaEspecieDTO>();
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().CreateConnection())
                {
                    conn.Open();

                    var query = @"SELECT id_raza, nombre_raza, id_especie nombre_especie FROM raza rz INNER JOIN especie e ON e.id_especie = rz.especie WHERE e.id_especie = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GetRazaEspecieDTO r = new GetRazaEspecieDTO
                                {
                                    IdEspecie = Convert.ToInt32(reader["id_especie"]),
                                    NombreEspecie = reader["nombre_especie"].ToString(),
                                    IdRaza = Convert.ToInt32(reader["id_raza"]),
                                    NombreRaza = reader["nombre_raza"].ToString()
                                };
                                listarRazas.Add(r);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listarRazas;
        }

        public string CrearMascota(MascotaDTO mascota)
        {
            try
            {
                using (MySqlConnection conn = DBConnection.GetInstance().CreateConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("insertar_mascota", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@in_nombre_mascota", mascota.Nombre);
                        cmd.Parameters.AddWithValue("@in_especie", mascota.EspecieId);
                        cmd.Parameters.AddWithValue("@in_raza", mascota.RazaId);
                        cmd.Parameters.AddWithValue("@in_edad", mascota.Edad);
                        cmd.Parameters.AddWithValue("@in_peso", mascota.Peso);
                        cmd.Parameters.AddWithValue("@in_duenio", mascota.DuenioId);

                        cmd.ExecuteNonQuery();
                    }
                }
                return "E";
            }
            catch (Exception)
            {
                throw;
            }
            return "Usuario agregado exitosamente!";
        }
    }
}
