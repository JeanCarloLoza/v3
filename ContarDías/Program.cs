using ContarDías.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ContarDías
{
    class Program
    {
        DateTime dtHoy = DateTime.Now;

        /// <summary>
        /// Evento que se ejecuta al ejercutar el programa
        /// </summary>
        /// <param name="args">los argumentos que se envian al iniciar las clases</param>
        static void Main(string[] args)
        {
            string cRutaArchivo = @"C:\Trabajo\Cursos\Buenas practicas\dias.txt";//TODO: leer la ruta de manera dinamica
            string[] arrInfo;
            string cRespusta;
            DateTime dtHoy = DateTime.Now;
            
            ILectorArchivo lector = new LectorArchivoTxt(cRutaArchivo);
            IProcesadorEventos procesador = new ProcesadorEventos(dtHoy);
            IMostrarMensajes mensajes = new MostrarMensajes();

            arrInfo = lector.LeerArchivo();
            cRespusta = procesador.Procesar(arrInfo);
            mensajes.mostrarEnConsola(cRespusta);
        }
        
    }
}
