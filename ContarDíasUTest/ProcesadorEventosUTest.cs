using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ContarDías.Clases;
using System.Collections.Generic;

namespace ContarDíasUTest
{
    [TestClass]
    public class ProcesadorEventosUTest
    {
        [TestMethod()] //STUB
        public void ProcesarArchivo_ArchivoTieneUnRegistros_ListaUnEvento()
        {
            //ARRANGE
            //var DOCILeerArchivoService = new Mock<ILectorArchivo>();
            //string[] arrCadena = new string[] { "evento1,25/01/2020" };
            //DOCILeerArchivoService.Setup(doc => doc.ObtenerContenido(It.IsAny<string>())).Returns(arrCadena);
            var SUT = new ProcesadorEventos(DOCILeerArchivoService.Object);
            
            //ACT
            List<EventosDTO> lstEventos = SUT.Procesar("test", ",", DateTime.Now);
            
            //ASSERT
            Assert.AreEqual(1, lstEventos.Count);
        }



        /*[TestMethod()]//STUB
        [ExpectedException(typeof(Exception))]
        public void ProcesarArchivo_FormatoIncorrecto_LanzaExcepcion()
        {
            //ARRANGE
            var DOCILeerArchivoService = new Mock<ILectorArchivo>();
            string[] arrCadena = new string[] { "evento1|25/01/2020" };
            DOCILeerArchivoService.Setup(doc => doc.ObtenerContenido(It.IsAny<string>())).Returns(arrCadena);
            var SUT = new ProcesadorEventosTxtService(DOCILeerArchivoService.Object);
            
            //ACT
            List<EventosDTO> lstEventos = SUT.Procesar("test", ",", DateTime.Now);
        }



        [TestMethod()]//SPIE
        public void ProcesarArchivo_InvocaDependencia_UnaVez()
        {
            //ARRANGE
            var DOCILeerArchivoService = new Mock<ILectorArchivo>();
            string[] arrCadena = new string[] { "evento1,25/01/2020" };
            DOCILeerArchivoService.Setup(doc => doc.ObtenerContenido(It.IsAny<string>())).Returns(arrCadena);
            var SUT = new ProcesadorEventosTxtService(DOCILeerArchivoService.Object);
            
            //ACT
            List<EventosDTO> lstEventos = SUT.Procesar("test", ",", DateTime.Now);
            
            //ASSERT
            DOCILeerArchivoService.Verify(a => a.ObtenerContenido(It.IsAny<string>()), Times.Once);
        }



        [TestMethod()]//STUB
        public void ProcesarArchivo_RegistroCorrecto_FechaAsignada()
        {
            //ARRANGE
            var DOCILeerArchivoService = new Mock<ILectorArchivo>();
            string[] arrCadena = new string[] { "evento1,25/01/2020" };
            DOCILeerArchivoService.Setup(doc => doc.ObtenerContenido(It.IsAny<string>())).Returns(arrCadena);
            var SUT = new ProcesadorEventosTxtService(DOCILeerArchivoService.Object);
            
            //ACT
            List<EventosDTO> lstEventos = SUT.Procesar("test", ",", DateTime.Now);
            
            //ASSERT
            Assert.AreEqual(new DateTime(2020, 01, 25), lstEventos[0].dtEvento);
        }



        [TestMethod()]
        public void ProcesarArchivo_RegistroCorrecto_EventoAsignado()
        {
            //ARRANGE
            var DOCILeerArchivoService = new Mock<ILectorArchivo>();
            string[] arrCadena = new string[] { "evento1,25/01/2020" };
            DOCILeerArchivoService.Setup(doc => doc.ObtenerContenido(It.IsAny<string>())).Returns(arrCadena);
            var SUT = new ProcesadorEventosTxtService(DOCILeerArchivoService.Object);
            
            //ACT
            List<EventosDTO> lstEventos = SUT.Procesar("test", ",", DateTime.Now);
            
            //ASSERT
            Assert.AreEqual("evento1", lstEventos[0].cEvento);
        }*/
    }
}
