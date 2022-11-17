

namespace TareaMVCCursos.Models { 

    public partial class PublicacionesTipo
    {
        public int IdTipo { get; set; }

        public string Tipo { get; set; } = null!;

        public int PorcentajeReservacion { get; set; }

        public int? CuotasMinimas { get; set; }

        public virtual ICollection<Publicacione> Publicaciones { get; } = new List<Publicacione>();
    }
}
