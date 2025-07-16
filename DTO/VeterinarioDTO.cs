namespace MiAppVeterinaria.DTO
{
    public class VeterinarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Disponible { get; set; }
        public string Contacto { get; set; }

        public VeterinarioDTO() { }
        public VeterinarioDTO(string nombre, string apellido, bool disponible, string contacto)
        {
            Nombre = nombre;
            Apellido = apellido;
            Disponible = disponible;
            Contacto = contacto;
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
        }
        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}
