using ApiCalificacionesLlamada.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;


namespace ApiCalificacionesLlamada.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ArchivoConversacionController : ApiController
    {
        public ArchivoConversacionService acs = new ArchivoConversacionService();

        [HttpPost]
        [Route("api/calificacion")]
        public IHttpActionResult ObtenerCalificacionArchivo()
        {
            return Ok(acs.FormatearRespuestaServicioLlamada());
        }
    }
}