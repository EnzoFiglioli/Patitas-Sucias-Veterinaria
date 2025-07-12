namespace MiAppVeterinaria.DTO
{
    class MascotaDTO
    {
        public string NombreMascota;
        public int DuenioId;
        public int EspecieId;
        public int RazaId;
        public int Edad;
        public decimal Peso;
        public string Nombre;

        public MascotaDTO() { }
        public MascotaDTO(string nombreMascota, int duenioID, int especieId, int razaId, int edad, decimal peso, string nombre)
        {
            NombreMascota = nombreMascota;
            DuenioId = duenioID;
            EspecieId = especieId;
            RazaId = razaId;
            Edad = edad;
            Peso = peso;
            Nombre = nombre;
        }
    }
}
