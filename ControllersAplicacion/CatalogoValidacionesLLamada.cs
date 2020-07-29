using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Entidades.Models;

namespace ControllersAplicacion
{
    class CatalogoValidacionesLLamada
    {
        public int validarExcelenteServicioCoincidencias(string[] conversacion)
        {
            int puntosLlamada = 0;
            try
            {
                foreach (string registro in conversacion)
                {
                    if (registro.ToLower().Contains("excelente servicio"))
                    {
                        puntosLlamada = 100;
                        return puntosLlamada;
                    }
                    if (registro.ToLower().Contains("servicio") && !registro.ToLower().Contains("asesor"))
                    {
                        puntosLlamada = puntosLlamada + 10;
                    }

                }
                return puntosLlamada;
            } catch (Exception err)
            {
                return puntosLlamada;
            }

        }

        public short ValidarConversacionAbandonada(string[] conversacion)
        {
            short puntosLlamada = 0;
            try
            {
                if (conversacion.Length <= 2)
                {
                    puntosLlamada = -100;
                    return puntosLlamada;
                }
                return puntosLlamada;
            }
            catch (Exception err)
            {
                return puntosLlamada;
            }

        }

        public short validarPalabraUrgenteEnConvesacion(string[] conversacion)
        {
            short puntaje = 0;
            try
            {
                int urgente = 0;
                foreach (string element in conversacion)
                {
                    if (element.ToLower().Contains("urgente"))
                    {
                        urgente++;
                    }
                }
                if (urgente > 2)
                {
                    puntaje = -10;
                }
                if (urgente <= 2)
                {
                    puntaje = -5;
                }
                return puntaje;
            }
            catch (Exception err)
            {
                return puntaje;
            }

        }

        public short validarCantidadMensajesConversacion(string[] conversacion)
        {
            short puntosLlamada = 0;
            try
            {
                // Se añade uno mas a la validacion(6) ya que dentro de la conversacion viene titulo (EJ: CONVERSACION 1)
                if (conversacion.Length <= 6)
                {
                    puntosLlamada = 20;
                }
                if (conversacion.Length > 6)
                {
                    puntosLlamada = 10;
                }
                return puntosLlamada;
            }
            catch (Exception err)
            {
                return puntosLlamada;
            }

        }

        public int puntajePorDuracion(string[] conversacion)
        {
            int puntuacion = 0;
            try
            {
                string fechaInicial = null;
                string fechaFinal = null;
                string segundosInicial = null;
                string segundosFinal = null;
                for (int i = 0; i < conversacion.Length; i++)
                {
                    if (i == 1)
                    {
                        fechaInicial = conversacion[i];
                    }
                    if (i == conversacion.Length - 1)
                    {
                        fechaFinal = conversacion[conversacion.Length - 1];
                    }
                }
                string[] stringSeparators = new string[] { ":" };
                string[] inicial = fechaInicial.Split(stringSeparators, StringSplitOptions.None);
                string[] final = fechaFinal.Split(stringSeparators, StringSplitOptions.None);

                for (int i = 0; i < inicial.Length; i++)
                {
                    if (i == 2)
                    {
                        string[] stringSeparatorsEspecial = new string[] { " " };
                        string[] se = inicial[i].Split(stringSeparatorsEspecial, StringSplitOptions.None);
                        string[] seFi = final[i].Split(stringSeparatorsEspecial, StringSplitOptions.None);
                        segundosInicial = se[0];
                        segundosFinal = seFi[0];
                        break;
                    }
                }

                DateTime fechaInicialDate = new DateTime(2020, 07, 28, int.Parse(inicial[0]), int.Parse(inicial[1]), int.Parse(segundosInicial));
                DateTime fechaFinalDate = new DateTime(2020, 07, 28, int.Parse(final[0]), int.Parse(final[1]), int.Parse(segundosFinal));
                double difeSeconds = (fechaFinalDate - fechaInicialDate).TotalSeconds;
                if (difeSeconds >= 60)
                {
                    puntuacion = 25;
                }
                if (difeSeconds < 60)
                {
                    puntuacion = 50;
                }

                return puntuacion;
            }
            catch (Exception)
            {
                return puntuacion;
            }
        }

    }
}
