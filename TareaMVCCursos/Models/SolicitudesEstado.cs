

namespace TareaMVCCursos.Models { 

    public partial class SolicitudesEstado
    {
        public int IdEstado { get; set; }

        public string Estado { get; set; } = null!;

        public virtual ICollection<Solicitude> Solicitudes { get; } = new List<Solicitude>();
    }
}
