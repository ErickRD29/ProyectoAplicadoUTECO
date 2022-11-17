

namespace TareaMVCCursos.Models { 

    public partial class Solicitude
    {
        public int IdSolicitud { get; set; }

        public int IdPersona { get; set; }

        public int IdPublicacion { get; set; }

        public int IdEstado { get; set; }

        public DateTime Fecha { get; set; }

        public virtual SolicitudesEstado IdEstadoNavigation { get; set; } = null!;

        public virtual Persona IdPersonaNavigation { get; set; } = null!;

        public virtual Publicacione IdPublicacionNavigation { get; set; } = null!;
    }
}