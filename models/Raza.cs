namespace MiAppVeterinaria.Models
{
    public class RazaEntity
    {
        public string Raza { get; set; }
        public string Especie { get; set; }

        public RazaEntity() { }
        public RazaEntity(string raza, string especie)
        {
            this.Especie = especie;
            this.Raza = raza;
        }
    }

}
