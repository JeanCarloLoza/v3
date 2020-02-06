using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContarDías;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ContarDías.Tests
{
    [TestClass()]
    public class ProcesadorEventosUTest
    {
        [TestMethod()]
        public void Procesar_CalculaDiaFuturo_UnDia()//nombreclase_quequieresvalidar_resultado
        {
            //ARRANGE
            string[] arrCadena = new string[] { "evento1,06/02/2020" };
            string cRepuesta = "";
            var SUT = new ProcesadorEventos(new DateTime(2020,02,5));
            
            //ACT
            cRepuesta = SUT.Procesar(arrCadena);
            
            //ASSERT
            Assert.AreEqual("El evento evento1 ocurrirá dentro de 1 dia\n", cRepuesta);
        }

    }
}