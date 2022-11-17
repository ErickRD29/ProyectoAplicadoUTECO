

namespace TareaMVCCursos.Models { 

    public partial class PublicacionesModalidade
    {
        public int IdModalidad { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<Publicacione> Publicaciones { get; } = new List<Publicacione>();
    }
}