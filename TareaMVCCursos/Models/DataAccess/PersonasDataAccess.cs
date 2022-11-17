using Newtonsoft.Json;

namespace TareaMVCCursos.Models
{
    public static class PersonasDataAccess
    {
        public static MethodResponse CreatePersona(Persona personaJson)
        {
            var response = new MethodResponse();
            var context = new TareaMvccursosContext();
            try
            {
                var persona = context.Personas.FirstOrDefault(a=>a.Cedula == personaJson.Cedula);
                if (persona is not null)
                {
                    response.Code = 0;
                    response.Message = "Persona ya existe en la BD";
                    response.result = persona;
                    return response;
                }

                if (personaJson is null)
                {
                    response.Message = "No se pudo agregar correctamente a la persona";
                    response.Code = -1;
                    return response;
                }

                context.Personas.Add(personaJson);
                response.Code = context.SaveChanges();
                response.Message = "Persona agregada exitosamente a la BD";
                response.result = context.Personas.OrderBy(a=>a.IdPersona).Last();
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = -1;
                return response;
            }
        }
    }
}
