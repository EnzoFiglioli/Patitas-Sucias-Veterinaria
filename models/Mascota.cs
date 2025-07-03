namespace MiAppVeterinaria.models
{
    class Mascota
    {
        public Especies especie { get; set; }
        public string raza { get; set; }
        public int edad { get; set; }
        public string duenio { get; set; }


        public Mascota(Especies especie, string raza, int edad, string duenio)
        {
            this.especie = especie;
            this.raza = raza;
            this.edad = edad;
            this.duenio = duenio;
        }

        public enum Especies
        {
            Perro,
            Gato,
            Loro
        }

    }
}
