namespace MiAppVeterinaria.Models
{
    class Veterinario
    {
        public int VeterinarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Disponible { get; set; }
        public string Contacto { get; set; }

        public Veterinario() { }
        public Veterinario(int veterinarioId, string nombre, string apellido, bool disponible, string contacto)
        {
            VeterinarioId = veterinarioId;
            Nombre = nombre;
            Apellido = apellido;
            Disponible = disponible;
            Contacto = contacto;
        }
        public string NombreApellido => $"{Nombre} {Apellido}";
    }
}
