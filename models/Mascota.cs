using MiAppVeterinaria.Models;

namespace MiAppVeterinaria.Models
{
    public class Mascota : RazaEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Edad { get; set; }
        public decimal Peso { get; set; }
        public string NombreCompletoDuenio { get; set; }
        public string ContactoDuenio { get; set; }

        public Mascota() { }
        public Mascota(int id, string nombre, string especie, string raza , int edad,decimal peso, string duenio, string contacto) : base(raza, especie)
        {
            Id = id;
            Nombre = nombre;
            Edad = edad;
            Peso = peso;
            NombreCompletoDuenio = duenio;
            ContactoDuenio = contacto;
        }

        public override string ToString()
        {
            return $"{Nombre} - {NombreCompletoDuenio}";
        }
    }

}
