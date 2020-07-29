using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllersAplicacion
{
    class CalificacionLlamada
    {
        public short ObtenerCalificacionCalculadoXLlamada(int puntosLlamada)
        {
            short calificacion = 0; 
            if (puntosLlamada < 25 && puntosLlamada >= 0)
            {
                calificacion = 1;
            }
            if (puntosLlamada >= 25 && puntosLlamada < 50)
            {
                calificacion = 2;
            }
            if (puntosLlamada >= 50 && puntosLlamada < 75)
            {
                calificacion = 3;
            }
            if (puntosLlamada >= 75 && puntosLlamada < 90)
            {
                calificacion = 4;
            }
            if (puntosLlamada >= 90)
            {
                calificacion = 5;
            }

            return calificacion;
        }
    }
}
