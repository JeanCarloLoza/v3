using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContarDías;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ContarDíasUTest
{
    [TestClass()]
    public class EjecutadorProgramaUTest
    {
        [TestMethod()]//SPIE, STUBS y dummy
        public void EjecutarPrograma_InvocaLeerArchivo_UnaVez()
        {
            //ARRANGE
            var DOCILeerArchivo = new Mock<iLectorArchivo>();
            string[] arrCadena = new string[] { "evento1,25/01/2020" };
            DOCILeerArchivo.Setup(doc => doc.LeerArchivo()).Returns(arrCadena);

            var DOCProcesadorEventos = new Mock<IProcesadorEventos>();
            DOCProcesadorEventos.Setup(doc => doc.Procesar(It.IsAny<string[]>())).Returns("");

            var DOCMostrarMensaje = new Mock<IMostrarMensajes>();
            DOCMostrarMensaje.Setup(doc => doc.mostrarEnConsola(It.IsAny<string>()));

            var SUT = new EjecutadorPrograma(DOCILeerArchivo.Object, DOCProcesadorEventos.Object, DOCMostrarMensaje.Object);
            
            //ACT
            SUT.EjecutarPrograma();

            //ASSERT
            DOCMostrarMensaje.Verify(a => a.mostrarEnConsola(It.IsAny<string>()), Times.Once);
        }

        [TestMethod()]//Mocks
        [ExpectedException(typeof(Exception))]
        public void EjecutarPrograma_FormatoIncorrecto_LanzaExcepcion()
        {
            //ARRANGE
            var DOCILeerArchivo = new Mock<iLectorArchivo>();
            string[] arrCadena = new string[] { "evento1,hola" };
            DOCILeerArchivo.Setup(doc => doc.LeerArchivo()).Returns(arrCadena);

            var DOCProcesadorEventos = new Mock<IProcesadorEventos>();
            DOCProcesadorEventos.Setup(doc => doc.Procesar(It.IsAny<string[]>())).Returns("");

            var DOCMostrarMensaje = new Mock<IMostrarMensajes>();
            DOCMostrarMensaje.Setup(doc => doc.mostrarEnConsola(It.IsAny<string>()));

            var SUT = new EjecutadorPrograma(DOCILeerArchivo.Object, DOCProcesadorEventos.Object, DOCMostrarMensaje.Object);

            //ACT
            SUT.EjecutarPrograma();
        }
    }
}