using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContarDías.Clases;
using Newtonsoft.Json;

namespace ContarDías
{
    class ProcesadorEventos : IProcesadorEventos
    {
        DateTime dtHoy;

        public ProcesadorEventos(DateTime _dateTime)
        {
            dtHoy = _dateTime;
        }

        public string Procesar(string[] arrInfo)
        {
            string cRespuesta = "";
            string[] arrColumnas;
            string cTiempo = "";
            #region recorro el archivo
            foreach (string l in arrInfo)
            {
                arrColumnas = l.Split(',');//TODO: validar que cada linea tenga el formato corecto
                cTiempo = CalcularTiempo(arrColumnas[1]);
                cRespuesta += string.Format("El evento {0} {1}\n", arrColumnas[0], cTiempo);
            }
            #endregion
            return cRespuesta;
        }
        

        /// <summary>
        /// Metodo que se encarga de calcular el tiempo trascurrido
        /// </summary>
        /// <param name="_cFecha">el formato de la fecha la cual se comparara con el dia de hoy</param>
        /// <returns>una cadena con el timepo trascurrido y la unidad de tiempo, igual distigue si ya le fecha y apaso o esta por pasar</returns>
        public string CalcularTiempo(string _cFecha)
        {
            #region declaracion de variables
            DateTime dtFecha = Convert.ToDateTime(_cFecha);//TODO: validar que la fecha tenga el formato correcto
            TimeSpan tsTiempo = dtHoy - dtFecha;
            decimal iCantidad = 0;
            string cUnidad = "";
            string cRespuesta = "";
            #endregion
            #region calculo del tiempo
            List<IntervalosTiempo> lstIntervalos = ObtenerListaIntervalos();
            foreach (IntervalosTiempo i in lstIntervalos.OrderByDescending(x=>x.iTiempo).ToList())
            {
                iCantidad = Math.Abs((int)(tsTiempo.TotalSeconds / i.iTiempo));
                cUnidad = (iCantidad == 1) ? i.cSingular : i.cPlural;
                if (iCantidad >= 1)
                {
                    break;
                }
            }
            #endregion

            #region definicion de mensaje
            if (dtHoy < dtFecha)
            {
                iCantidad = Math.Abs(iCantidad);
                cRespuesta = string.Format("ocurrirá dentro de {0} {1}", iCantidad, cUnidad);
            }
            else
                cRespuesta = string.Format("ocurrio hace {0} {1}", iCantidad, cUnidad);
            #endregion

            return cRespuesta;
        }

        public List<IntervalosTiempo> ObtenerListaIntervalos() {

            List<IntervalosTiempo> lstTiempo = new List<IntervalosTiempo>();

            lstTiempo.Add(new IntervalosTiempo
            {
                iTiempo = 5184000,
                cSingular = "bimestre",
                cPlural = "bimestres"
            });

            lstTiempo.Add(new IntervalosTiempo
            {
                iTiempo = 31536000,
                cSingular = "año",
                cPlural = "años"
            });

            lstTiempo.Add(new IntervalosTiempo
            {
                iTiempo = 2592000,
                cSingular = "mes",
                cPlural = "meses"
            });
            lstTiempo.Add(new IntervalosTiempo
            {
                iTiempo = 86400,
                cSingular = "dia",
                cPlural = "dias"
            });
            lstTiempo.Add(new IntervalosTiempo
            {
                iTiempo = 3600,
                cSingular = "hora",
                cPlural = "horas"
            });
            lstTiempo.Add(new IntervalosTiempo
            {
                iTiempo = 60,
                cSingular = "minuto",
                cPlural = "minutos"
            });

            return lstTiempo;
        }

    }
}
