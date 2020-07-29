using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;
using System.Collections;
using ControllersAplicacion;

namespace ApiCalificacionesLlamada.Services
{
    public class ArchivoConversacionService
    {
        public RespuestaServiciosApi FormatearRespuestaServicioLlamada()
        {
            RespuestaServiciosApi rsa = new RespuestaServiciosApi();
            try
            {
                ProcesarConversaciones pc = new ProcesarConversaciones();
                ArrayList s = pc.procesarArchivoConversaciones();
                rsa.Resultado = s;
                rsa.EsExitoso = true;
                rsa.Errors = null;
                return rsa;
            } catch (Exception err)
            {
                rsa.Resultado = null;
                rsa.EsExitoso = false;
                rsa.Errors = err;
                return rsa;
            }
        }
    }
}