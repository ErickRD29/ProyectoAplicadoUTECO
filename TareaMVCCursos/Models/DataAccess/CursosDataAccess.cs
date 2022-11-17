using Microsoft.EntityFrameworkCore;
using TareaMVCCursos.Models.DataAccess;

namespace TareaMVCCursos.Models
{
    public class CursosDataAccess
    {
        private TareaMvccursosContext context = new TareaMvccursosContext();

        public MethodResponse GetCursosPublicaciones()
        {
            var result = context.Publicaciones.ToList();
            return new MethodResponse { Code = 0, Message = "Consulta completa", result = result };
        }

        public MethodResponse GetCursosPublicacion(int id)
        {
            var result = context.Publicaciones.First(a => a.IdPublicacion == id);
            return new MethodResponse { Code = 0, Message = "Consulta completa", result = result };
        }

        public MethodResponse GetPersonasInscritas(int idCurso)
        {
            var NopersonasInscritas = context.Solicitudes.Where(a => a.IdPublicacion == idCurso && a.IdEstado == 1).ToList();

            return new MethodResponse { Code = 0, Message = "Consulta completa", result = NopersonasInscritas.Count };
        }

        public MethodResponse InscribirPersona(Solicitude inscripcion)
        {

            if (context.Solicitudes.Any(a => a.IdPersona == inscripcion.IdPersona))
            {
                return new MethodResponse { Code = -1, Message = "La persona ya esta inscrita al curso" };
            }

            context.Solicitudes.Add(inscripcion);
            var cambios = context.SaveChanges();
            return new MethodResponse { Code = cambios, Message = "Suscripcion guardada" };
        }

        #region Catalogos

        public MethodResponse GetPublicacionesTipos()
        {
            MethodResponse response = new MethodResponse { Code = 0, Message = "Sin resultados" };

            var publicacion = this.context.PublicacionesTipos.ToList();
            if (publicacion is not null)
            {
                response.Code = 0;
                response.Message = "Consulta correcta";
                response.result = publicacion;
            }

            return response;
        }

        public MethodResponse GetPublicacionesModalidades()
        {
            MethodResponse response = new MethodResponse { Code = 0, Message = "Sin resultados" };

            var publicacion = this.context.PublicacionesModalidades.ToList();
            if (publicacion is not null)
            {
                response.Code = 0;
                response.Message = "Consulta correcta";
                response.result = publicacion;
            }

            return response;
        }
        public MethodResponse GetSolicitudesEstados()
        {
            MethodResponse response = new MethodResponse { Code = -1, Message = "Sin resultados" };

            var solicitudEstado = this.context.SolicitudesEstados.ToList();
            if (solicitudEstado is not null)
            {
                response.Code = 0;
                response.Message = "Consulta Correcta";
                response.result = solicitudEstado;
            }

            return response;
        }
        #endregion
    }
}
