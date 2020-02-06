namespace ContarDías
{
    public class EjecutadorPrograma
    {
        iLectorArchivo lector;
        IProcesadorEventos procesador;
        IMostrarMensajes mensajes;

        public EjecutadorPrograma(iLectorArchivo _lector, IProcesadorEventos _procesador, IMostrarMensajes _mensajes)
        {
            lector = _lector;
            procesador = _procesador;
            mensajes = _mensajes;

        }

        public void EjecutarPrograma() {

            string[] arrInfo;
            string cRespusta;

            arrInfo = lector.LeerArchivo();
            cRespusta = procesador.Procesar(arrInfo);
            mensajes.mostrarEnConsola(cRespusta);
        }
    }
}
