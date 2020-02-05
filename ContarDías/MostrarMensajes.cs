using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContarDías
{
    class MostrarMensajes : IMostrarMensajes
    {
        public void mostrarEnConsola(string cRespusta)
        {
            System.Console.WriteLine(cRespusta);
            System.Console.ReadKey();
        }
    }
}
