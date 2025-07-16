namespace MiAppVeterinaria.DTO
{
    class MascotaDTO
    {
        public int Id { get; set; }
        public string NombreMascota { get; set; }

        public int EspecieId { get; set; }
        public string EspecieNombre { get; set; }

        public string Raza { get; set; }

        public int Edad { get; set; }

        public decimal Peso { get; set; }

        public int DuenioId { get; set; }
        public string DuenioNombre { get; set; }

        public MascotaDTO() { }
        public MascotaDTO(string nombreMascota, int duenioID, string especieNombre, string raza, int edad, decimal peso)
        {
            NombreMascota = nombreMascota;
            DuenioId = duenioID;
            EspecieNombre = especieNombre; // ✅ esta sí existe
            Raza = raza;
            Edad = edad;
            Peso = peso;
        }
    }
}
