namespace MiAppVeterinaria.Models
{
    public class Duenio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contacto { get; set; }
        public void ObtenerListadoMascotas()
        {

        }

        public string NombreCompleto => $"{Nombre} {Apellido}";

    }
}
