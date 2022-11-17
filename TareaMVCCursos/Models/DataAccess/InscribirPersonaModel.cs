namespace TareaMVCCursos.Models.DataAccess
{
    public class InscribirPersonaModel
    {
       public int InscribirPersonaModelId { get; set; }
       public Persona persona { get; set; }
       public Solicitude solicitude { get; set; }
       public SolicitudesEstado solicitudesEstado { get; set; }
       public Publicacione publicacion { get; set; }

        public List<SolicitudesEstado> solicitudesEstados { get; set; }
        public List<PublicacionesTipo> tipos { get; set; }
        public List<PublicacionesModalidade> modalidades { get; set; }

    }
}
