namespace TareaMVCCursos.Models
{
    public class CursoViewDto
    {
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }

        public int CupoCurso { get; set; }

        public int Inscritos { get; set; }
        public string ImageUrl { get; set; }
    }
}
