namespace MiAppVeterinaria.Models
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Especie { get; set; }
        public string Raza { get; set; }

        public int Edad { get; set; }
        public decimal Peso { get; set; }

        // Info del dueño
        public string NombreCompletoDuenio { get; set; }
        public string ContactoDuenio { get; set; }

        public Mascota() { }

        public Mascota(
            int id,
            string nombre,
            string especie,
            string raza,
            int edad,
            decimal peso,
            string nombreCompletoDuenio,
            string contactoDuenio
        )
        {
            Id = id;
            Nombre = nombre;
            Especie = especie;
            Raza = raza;
            Edad = edad;
            Peso = peso;
            NombreCompletoDuenio = nombreCompletoDuenio;
            ContactoDuenio = contactoDuenio;
        }

        public override string ToString()
        {
            return $"{Nombre} - {NombreCompletoDuenio}";
        }

        public string MascotaDuenioNombre => $"{Nombre} - {NombreCompletoDuenio}";
    }
}
