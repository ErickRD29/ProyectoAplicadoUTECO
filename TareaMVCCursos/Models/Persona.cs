

namespace TareaMVCCursos.Models {

public partial class Persona
{
    public int IdPersona { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public string? Telefono { get; set; }

    public string Correo { get; set; } = null!;

    public string? Direccion { get; set; }

    public string AreaDeFormacion { get; set; } = null!;

    public string Formacionacademica { get; set; } = null!;

    public virtual ICollection<Solicitude> Solicitudes { get; } = new List<Solicitude>();
    }
}
