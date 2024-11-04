namespace Proyecto_Zetta.Client.Servicios
{
    public class HttpRespuesta<T>(T respuesta, bool error, HttpResponseMessage httpResponseMessage)
    {
        public T Respuesta { get; } = respuesta;
        public bool Error { get; } = error;
        public HttpResponseMessage HttpResponseMessage { get; set; } = httpResponseMessage;

        public async Task<string> ObtenerError()
        {
            if (!Error)
            {
                return "";
            }

            var satuscode = HttpResponseMessage.StatusCode;

            switch (satuscode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    return HttpResponseMessage.Content.ReadAsStringAsync().ToString()!;
                    return "Error, no se puede procesar la informacion";
                case System.Net.HttpStatusCode.Unauthorized:
                    return "Error, no esta logueado";
                case System.Net.HttpStatusCode.Forbidden:
                    return " Error,  no tiene autorizacion a ejecutar este proceso";
                case System.Net.HttpStatusCode.NotFound:
                    return "Error, direccion no encontrada";
                default:
                    return HttpResponseMessage.Content.ReadAsStringAsync().Result;



            }


        }
    }
}
