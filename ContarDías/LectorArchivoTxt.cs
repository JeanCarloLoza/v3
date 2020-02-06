using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContarDías
{
    public class LectorArchivoTxt : iLectorArchivo
    {
        string cRuta;

        public LectorArchivoTxt(string _cRuta) {
            this.cRuta = _cRuta;
        }

        /// <summary>
        /// Metodo que se encarga de leer el archivo e ir recorriendo las líneas
        /// </summary>
        public string[] LeerArchivo()
        {
            return System.IO.File.ReadAllLines(cRuta);//TODO: validar que el archivo exista
        }
    }
}
