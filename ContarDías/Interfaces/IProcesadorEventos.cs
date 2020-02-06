using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContarDías
{
    public interface IProcesadorEventos
    {
        string Procesar(string[] arrInfo);
    }
}
