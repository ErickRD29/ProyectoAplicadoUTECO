

namespace TareaMVCCursos.Models { 

    public partial class Publicacione
    {
        public int IdPublicacion { get; set; }

        public int IdTipo { get; set; }

        public int IdModalidad { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Costo { get; set; }

        public int Cupo { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaExpiracion { get; set; }

        public string? UrlImagen { get; set; }

        public virtual PublicacionesModalidade IdModalidadNavigation { get; set; } = null!;

        public virtual PublicacionesTipo IdTipoNavigation { get; set; } = null!;

        public virtual ICollection<Solicitude> Solicitudes { get; } = new List<Solicitude>();
    }
}
