using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;

namespace ApiCitasMedicas.Modelos
{
    public class Citas
    {
        public string? codCita { get; set; }
        public string? nomPac { get; set; }

       public string? codMed { get; set; }

       public string? codEsp { get; set; }

       public string? codTurno { get; set; }

       public string? fecha { get; set;} 

    }
}
