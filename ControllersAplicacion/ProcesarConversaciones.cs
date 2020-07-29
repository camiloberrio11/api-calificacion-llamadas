using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Collections;
using Newtonsoft.Json;
using Entidades.Models;

namespace ControllersAplicacion
{
    public class ProcesarConversaciones
    {
        public ArrayList procesarArchivoConversaciones()
        {
            InformacionArchivoLlamadas ial = new InformacionArchivoLlamadas();
            ArrayList conversacionesCalificadas = new ArrayList();
            string[] conversaciones = ial.obtenerConversaciones();

            short i = 0;
            foreach (string unaConversacion in conversaciones)
            {
                i++;
                string[] expresionSeparadora = new string[] { "\r\n" };
                string[] conversacion = unaConversacion.Split(expresionSeparadora, StringSplitOptions.None);
                Llamada puntajeLlamada = ValidacionesPuntajeXLlamada(conversacion, i);
                conversacionesCalificadas.Add(puntajeLlamada);
            }


            return conversacionesCalificadas
;       }

        public Llamada ValidacionesPuntajeXLlamada (string[] conversacion, short numeroLlamada)
        {
            Llamada call = new Llamada();
            CalificacionLlamada caliLlamada = new CalificacionLlamada();
            CatalogoValidacionesLLamada cvl = new CatalogoValidacionesLLamada();
            int puntaje = 0;


            call.numero = numeroLlamada;
            puntaje = cvl.ValidarConversacionAbandonada(conversacion);
            if (puntaje == -100)
            {
                call.puntos = puntaje;
                call.calificacion = call.calificacion = caliLlamada.ObtenerCalificacionCalculadoXLlamada(puntaje);
                return call;
            }
            puntaje = puntaje + cvl.validarExcelenteServicioCoincidencias(conversacion);
            if (puntaje == 100)
            {
                call.puntos = puntaje;
                call.calificacion = call.calificacion = caliLlamada.ObtenerCalificacionCalculadoXLlamada(puntaje);
                return call;
            }

            // Prueba
           puntaje = puntaje + cvl.puntajePorDuracion(conversacion);


           puntaje = puntaje + cvl.validarPalabraUrgenteEnConvesacion(conversacion);
            puntaje = puntaje + cvl.validarCantidadMensajesConversacion(conversacion);
            call.calificacion = call.calificacion = caliLlamada.ObtenerCalificacionCalculadoXLlamada(puntaje);
            call.puntos = puntaje;

            return call;
        }
    }
}
