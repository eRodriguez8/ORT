using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;
using System.Linq;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz;
using Sua.Inventario.Test.Biz.Fakes;
using Corp.Cencosud.Supermercados.Sua.Inventario.Dal;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Exceptions;

namespace Corp.Cencosud.Supermercados.Inventario.Test.Biz
{
    /// <summary>
    /// Descripción resumida de InventarioBizTest
    /// </summary>
    [TestClass]
    public class InventarioBizTest
    {
        private InventarioBiz _servicio;
        private FakeUOW_CDsDB _FakeUOW_CDsDB;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_CDsDB = new FakeUOW_CDsDB();
            _FakeUOW_CDsDB.INV_dPosiciones = new List<INV_dPosiciones>();
            _FakeUOW_CDsDB.INV_dInventario = Inventarios();
            _FakeUOW_CDsDB.INV_dDocumentos = DocumentoBizTest.documentos();
            _servicio = new InventarioBiz(_FakeUOW_CDsDB);
        }

        private static List<INV_dInventario> Inventarios() {
            return new List<INV_dInventario>() { new INV_dInventario()
            {
                Estado = 1,
                FechaCreacion = DateTime.Now,
                cc = 217,
                Nombre = "Primer Inventario",
                Usuario = "E0344",
                id = 1
            } };
        }

        [TestMethod]
        public void ImportarExcelTest()
        {
            var url = Assembly.GetExecutingAssembly().Location.ToString()
                .Split(new string[] { "bin" }, StringSplitOptions.None).First() 
                 + @"test.xlsx";

            byte[] line = File.ReadAllBytes(url);
            var response = _servicio.ImportarExcel(line, 1, true);
            Assert.AreEqual("Metodo importar realizado con éxito", response);

        }

        [TestMethod]
        public void CrearInventarioTest()
        {
            var result = _servicio.Create(new Sua.Inventario.Entities.Inventario() {
                estado = Sua.Inventario.Entities.Estado.Iniciado,
                fechaCreacion = DateTime.Now,
                cc = 11,
                nombre = "Primer Inventario",
                usuario = "E0344"
            });

            Assert.AreEqual(1, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(2, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");

        }

        [TestMethod]
        public void CrearInventarioConflictExceptionTest()
        {
            try
            {
                var result = _servicio.Create(new Sua.Inventario.Entities.Inventario()
                {
                    estado = Sua.Inventario.Entities.Estado.Iniciado,
                    fechaCreacion = DateTime.Now,
                    cc = 217,
                    nombre = "Primer Inventario",
                    usuario = "E0344"
                });

                Assert.IsNull(result);
            }
            catch(ConflictException e)
            {
                Assert.AreEqual("ConflictException", e.GetType().Name);
            }

        }

        [TestMethod]
        public void GetxCCTest()
        {
            var result = _servicio.GetxCC(217);

            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");

        }

        [TestMethod]
        public void GetxCCNotFound()
        {
            try
            {
                var result = _servicio.GetxCC(333);
            }
            catch (NotFoundException ex)
            {
                Assert.AreEqual("NotFoundException", ex.GetType().Name);
            }
        }

        [TestMethod]
        public void GetxIdTest()
        {
            var result = _servicio.GetxId(1);

            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");

        }

        [TestMethod]
        public void GetxIdNotFound()
        {
            try
            {
                var result = _servicio.GetxId(2);
            }
            catch (NotFoundException ex)
            {
                Assert.AreEqual("NotFoundException", ex.GetType().Name);
            }
        }

        [TestMethod]
        public void GetxFechas_CC()
        {
            var result = _servicio.GetxFechas_CC(DateTime.Today.AddDays(-1).ToShortDateString(),
                DateTime.Today.ToShortDateString(), 217);

            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");

        }

        [TestMethod]
        public void GetxFechas_CCNotFound()
        {
            try
            {
                var result = _servicio.GetxFechas_CC(DateTime.Today.AddDays(-1).ToShortDateString(),
                    DateTime.Today.ToShortDateString(), 333);
            }
            catch (NotFoundException ex)
            {
                Assert.AreEqual("NotFoundException", ex.GetType().Name);
            }
        }

        [TestMethod]
        public void CancelarTest()
        {
            var result = _servicio.Cancelar(1);

            Assert.AreEqual(2, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dInventarioRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");

        }
    }
}
