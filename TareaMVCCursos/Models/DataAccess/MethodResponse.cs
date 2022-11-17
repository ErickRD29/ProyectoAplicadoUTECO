namespace TareaMVCCursos.Models
{
    public class MethodResponse
    {
        public int Code { get; set; }

        public string Message { get; set; } = string.Empty;

        public object result { get; set; }

    }
}
