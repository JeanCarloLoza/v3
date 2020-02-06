using ContarDías.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ContarDías
{
    public class Program
    {
        DateTime dtHoy = DateTime.Now;

        /// <summary>
        /// Evento que se ejecuta al ejercutar el programa
        /// </summary>
        /// <param name="args">los argumentos que se envian al iniciar las clases</param>
        static void Main(string[] args)
        {
            string cRutaArchivo = @"C:\Trabajo\Cursos\SOLID\dias.txt";//TODO: leer la ruta de manera dinamica
            DateTime dtHoy = DateTime.Now;
            
            iLectorArchivo lector = new LectorArchivoTxt(cRutaArchivo);
            IProcesadorEventos procesador = new ProcesadorEventos(dtHoy);
            IMostrarMensajes mensajes = new MostrarMensajes();

            EjecutadorPrograma ejecutador = new EjecutadorPrograma(lector, procesador, mensajes);
            ejecutador.EjecutarPrograma();
        }
        
    }
}
