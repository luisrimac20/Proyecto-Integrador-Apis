using ApiCitasMedicas.Modelos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Medicos.Models;
using System.Data;
using System.Data.SqlClient;


namespace ApiCitasMedicas.DAO
{
    public class GeneralDao
    {
        private readonly string cadena_conexion;

        public GeneralDao(IConfiguration config)
        {
            cadena_conexion = config.GetConnectionString("cn1");
        }

     //LISTA DE LOS MEDICOS
        public List<Medicos> ListarMedicos()
        {
            var lista = new List<Medicos>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena_conexion, "SP_LISTAR_MEDICOS");

            while (dr.Read())
            {
                lista.Add(new Medicos()
                {
                    codMed = dr.GetString(0),
                    nomMed = dr.GetString(1),
                    anioColegio = dr.GetString(2),
                    codDis = dr.GetString(3),
                    codEsp = dr.GetString(4),
                    codHora= dr.GetString(5),
                    ocupado = dr.GetString(6)


                });
            }
            dr.Close();

            return lista;

        }
    
    //BUSQUEDA POR LA ESPECIALIADAD DEL MEDICO
        public List<Medicos> ListarMedicosEspecialidad(string especialidad)
        {
            List<Medicos> lista = new List<Medicos>();

            SqlDataReader dr = SqlHelper.ExecuteReader(cadena_conexion, "SP_FILTRA_NOMBRE_ESPECIALIDAD", especialidad);

            while (dr.Read())
            {
                lista.Add(new Medicos
                {
                    codMed = dr.GetString(0),
                    nomMed = dr.GetString(1),
                    anioColegio = dr.GetString(2),
                    codDis = dr.GetString(3),
                    codEsp = dr.GetString(4),
                    codHora = dr.GetString(5),
                    ocupado = dr.GetString(6)
                });
            }
            dr.Close();
            return lista;
        }
        public List<Medicos> ListarCitasMedicos(string codmed)
        {
            var lista = new List<Medicos>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena_conexion, "SP_LISTAR_MEDICOS", codmed);

            while (dr.Read())
            {
                lista.Add(new Medicos()
                {
                    nomMed = dr.GetString(0),
                    anioColegio = dr.GetString(1),
                    codDis = dr.GetString(2),
                    codEsp = dr.GetString(3),
                    codHora = dr.GetString(4),
                    ocupado = dr.GetString(5)
                });
            }
            dr.Close();

            return lista;
        }

        public List<CitasProgramadas> ListarCitas()
        {
            var lista = new List<CitasProgramadas>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena_conexion, "SP_LISTAR_CITAS_PROGRAMADAS");

            while (dr.Read())
            {
                lista.Add(new CitasProgramadas()
                {            
                    codCita = dr.GetInt32(0),
                    codMed = dr.GetString(1),
                    nomPac = dr.GetString(2),
                    codEsp = dr.GetString(3),
                    codTurno = dr.GetString(4),
                    fecha = dr.GetDateTime(5),
                });
            }
            dr.Close();

            return lista;

        }

        public List<CitasProgramadas> Lista_Id_Citas(string codcita)
        {
            var lista = new List<CitasProgramadas>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena_conexion, "SP_LISTAR_CITAS_PROGRAMADAS", codcita);

            while (dr.Read())
            {
                lista.Add(new CitasProgramadas()
                {
                    codCita = dr.GetInt32(0),
                    codMed = dr.GetString(1),
                    nomPac = dr.GetString(2),
                    codEsp = dr.GetString(3),
                    codTurno = dr.GetString(4),
                    fecha = dr.GetDateTime(5),
                });
            }
            dr.Close();

            return lista;
        }

        public List<Especialidades> ListarEspecialidad()
        {
            var lista = new List<Especialidades>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena_conexion, "SP_LISTA_ESPECILIADADES");

            while (dr.Read())
            {
                lista.Add(new Especialidades()
                {
                    codEsp = dr.GetString(0),
                    nomEsp = dr.GetString(1),
                });
            }
            dr.Close();

            return lista;
        }


        public List<Turno> ListarTurno()
        {
            var lista = new List<Turno>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena_conexion, "SP_LISTA_TURNO");

            while (dr.Read())
            {
                lista.Add(new Turno()
                {
                    codTurno = dr.GetString(0),
                    nomTurno = dr.GetString(1),
                });
            }
            dr.Close();

            return lista;
        }



        public List<Medicos> ListaMedicos()
        {
            var lista = new List<Medicos>();

            SqlDataReader dr =
                SqlHelper.ExecuteReader(cadena_conexion, "SP_LISTAR_MEDICOS_NO");

            while (dr.Read())
            {
                lista.Add(new Medicos()
                {
                    nomMed = dr.GetString(0),
                    anioColegio = dr.GetString(1),
                    codDis = dr.GetString(2),
                    codEsp = dr.GetString(3),
                    codHora = dr.GetString(4),
                    ocupado = dr.GetString(5)
                });
            }
            dr.Close();

            return lista;
        }

        public string ProgramarCita(Citas obj)
        {
            string mensaje = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cadena_conexion, "SP_REGISTRAR_CITA_MEDICAS",                    
                       obj.nomPac, 
                       obj.codMed, 
                       obj.codEsp,
                       obj.codTurno, 
                       obj.fecha);
                //
                mensaje = $"Ha confirmado su cita para el dia {obj.fecha}";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public string EnviarMensajeContacto(Contacto s)
        {
            string msj = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cadena_conexion, "SP_ADD_MENSAJE_SOPORTE", s.name, s.email, s.phone, s.issue, s.message);
                msj = $"Gracias por su mensaje, estimado {s.name}. El equipo de Soporte le responderán lo más pronto posible.";
            }
            catch (Exception ex)
            {
                msj = ex.Message;
            }
            return msj;
        }

        public string RegistroUsuario(RegistroUsuario usuario)
        {
            string msj = "";
            try
            {
                SqlHelper.ExecuteNonQuery(cadena_conexion, "INSERTAR_USUARIO",
                    usuario.nombre,
                    usuario.apellido,
                    usuario.correo,
                    usuario.clave,
                    usuario.confimar_clave
                    );
                    msj = $"Ha completado el registro de usuario, estimado {usuario.nombre}";
            }
            catch (Exception ex)
            {
                msj = ex.Message;
            }
            return msj;
        }

        public string ActualizarCitaProgramada(CitasProgramadas obj) 
        {
            string msj = "";

            try {
                SqlHelper.ExecuteNonQuery(cadena_conexion, "SP_ACTUALIZAR_CITA",
                       obj.codCita,
                       obj.nomPac,
                       obj.codMed,
                       obj.codEsp,
                       obj.codTurno,
                       obj.fecha);
                msj = $"Su cita ha sido reprogramada para el dia {obj.fecha}";
            }
            catch (Exception ex)
            {
                msj = ex.Message;
            }
            return msj;
        }

    }
}

