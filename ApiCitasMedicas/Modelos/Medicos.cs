using System.ComponentModel.DataAnnotations;

namespace ApiCitasMedicas.Modelos
{
    public class Medicos
    {

        [Required]
        public string? codMed { get; set; }

        [Required]
        public string? nomMed { get; set; }

        [Required]
        public string? anioColegio { get; set; }

        [Required]
        public string? codDis { get; set; }

        [Required]
        public string? codEsp{ get; set; }

        [Required]
        public string? codHora { get; set; }

        public string? ocupado { get; set; }

    }
}
