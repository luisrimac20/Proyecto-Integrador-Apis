using Microsoft.AspNetCore.Mvc;
using ApiCitasMedicas.Modelos;
using ApiCitasMedicas.DAO;
using Proyecto_Medicos.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly GeneralDao dao;
        

        public ApiController(GeneralDao _dao)
        {
            dao = _dao;
           
        }

        // GET: api/<ApiController>
        [HttpGet("GetMedicos")]
        public List<Medicos> Get()
        {
            return dao.ListarMedicos();
        }

        
        [HttpGet("GetMedicoEspecialidad/{Nombre_Especialidad}")]
        public List<Medicos> GetEspecialidad(string Nombre_Especialidad)
        {
            return dao.ListarMedicosEspecialidad(Nombre_Especialidad);
        }

        // GET api/<ApiController>/5
        [HttpGet("GetMedico/{id}")]
        public Medicos Get(string id)
        {
            Medicos? obj = dao.ListarMedicos()
                .Find(m => m.codMed.Equals(id));
            return obj;
        }



        [HttpGet("GetCitas")]
        public List<Citas> GetCitasProgramadas()
        {
            return dao.ListarCitas();
        }

        // GET api/<ApiController>/5
        [HttpGet("GetCitas/{id}")]
        public Citas GetIdCitas(string id)
        {
            Citas? obj = dao.ListarCitas()
                .Find(m => m.codCita.Equals(id));
            return obj;
        }

        [HttpPost("AddCita")]
        public string Post([FromBody] Citas obj)
        {
            string mensaje = dao.ProgramarCita(obj);

            return mensaje;
        }


        [HttpGet("GetMedicosNo")]
        public List<Medicos> GetMedicoNo()
        {
            return dao.ListarMedicos();
        }


        [HttpGet("GetEspecialidades")]
        public List<Especialidades> GetEspecialidades()
        {
            return dao.ListarEspecialidad();
        }

        [HttpGet("GetTurno")]
        public List<Turno> GetTurno()
        {
            return dao.ListarTurno();
        }


        [HttpPost("AddContacto")]
        public String Post([FromBody] Contacto s)
        {
            String mensaje = dao.EnviarMensajeContacto(s);
            return mensaje;
        }

        [HttpPost("AddRegistroUsuario")]
        public String Post([FromBody] RegistroUsuario usuario)
        {
            String mensaje = dao.RegistroUsuario(usuario);
            return mensaje;
        }
    }
}
