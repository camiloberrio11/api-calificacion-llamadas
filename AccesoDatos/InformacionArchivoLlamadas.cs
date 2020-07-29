using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AccesoDatos
{
    public class InformacionArchivoLlamadas
    {
        private string ObtenerContenidoArchivo(string path)
        {
            try
            {
                string contenido = File.ReadAllText(@path);
                return contenido;
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }

        public string[] obtenerConversaciones()
        {
            // Test
            string filename = @"File\historial_de_conversaciones.txt";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + filename;
            string contenidoArchivo = ObtenerContenidoArchivo(filePath);
            string[] expresionSeparadores = new string[] { "\r\n\r\n" };
            string[] conversaciones = contenidoArchivo.Split(expresionSeparadores, StringSplitOptions.None);
            return conversaciones;
        }
    }
}
