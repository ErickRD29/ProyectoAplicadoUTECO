using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TareaMVCCursos.Models;
using TareaMVCCursos.Models.DataAccess;

namespace TareaMVCCursos.Controllers { 

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        var model = new CursosDataAccess();
        var listModelResult = model.GetCursosPublicaciones();
        var modelList = new List<CursoViewDto>();

        foreach (var curso in (List<Publicacione>)listModelResult.result)
        {
            var totalCupo = model.GetPersonasInscritas(curso.IdPublicacion);
            modelList.Add(new CursoViewDto
            {
                IdCurso = curso.IdPublicacion,
                CupoCurso = curso.Cupo,
                Descripcion = curso.Descripcion,
                FechaInicio = curso.FechaInicio ?? DateTime.Now,
                NombreCurso = curso.Nombre,
                ImageUrl = curso.UrlImagen,
                Inscritos = (int)totalCupo.result
            });
        }

        return View(modelList);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult addPersona()
    {
        return View();
    }

    public IActionResult GuardarRegistro(IFormCollection nuevaPersona)
    {
        var inscripcion = new CursosDataAccess();
        var solicitud = new Solicitude();

        var idpersona = PersonasDataAccess.CreatePersona(new Persona
        {
            Nombres = nuevaPersona["Nombres"].First(),
            Apellido = nuevaPersona["Apellido"].First(),
            AreaDeFormacion = nuevaPersona["AreaDeFormacion"].First(),
            Cedula = nuevaPersona["Cedula"].First(),
            Correo = nuevaPersona["Correo"].First(),
            Direccion = nuevaPersona["Direccion"].First(),
            Formacionacademica = nuevaPersona["Formacionacademica"].First(),
            Telefono = nuevaPersona["Telefono"].First(),
        });

        var ersona = (Persona)idpersona.result;
        solicitud.Fecha = DateTime.Now;
        solicitud.IdPersona = ersona.IdPersona;
        solicitud.IdPublicacion = (int)TempData["CurrentPublication"];
        solicitud.IdEstado = 1;
        inscripcion.InscribirPersona(solicitud);

        return RedirectToAction("Index");
    }

    public IActionResult Registros(int publicacionId)
    {
        TempData["CurrentPublication"] = publicacionId;
        var registro = new InscribirPersonaModel();
        var cursosDA = new CursosDataAccess();
        registro.publicacion = (Publicacione)cursosDA.GetCursosPublicacion(publicacionId).result;
        var estados = cursosDA.GetSolicitudesEstados();
        var publicacionTipo = cursosDA.GetPublicacionesTipos();
        var pubicacionModalidades = cursosDA.GetPublicacionesModalidades();

        registro.solicitudesEstados = (List<SolicitudesEstado>)estados.result;
        registro.tipos = (List<PublicacionesTipo>)publicacionTipo.result;
        registro.modalidades = (List<PublicacionesModalidade>)pubicacionModalidades.result;
        List<SelectListItem> modalidaes = new List<SelectListItem>();
        foreach (var item in registro.modalidades)
        {
            modalidaes.Add(new SelectListItem { Text = item.Nombre, Value = item.IdModalidad.ToString() });
        }

        List<SelectListItem> itemsEstados = new List<SelectListItem>();
        foreach (var item in registro.solicitudesEstados)
        {
            itemsEstados.Add(new SelectListItem { Text = item.Estado, Value = item.IdEstado.ToString() });
        }

        ViewBag.solicitudesEstados = itemsEstados;
        ViewBag.Modalidades = modalidaes;
        return View(registro);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}


