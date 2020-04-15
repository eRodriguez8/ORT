using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz;
using Sua.Inventario.Test.Biz.Fakes;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using Corp.Cencosud.Supermercados.Sua.Inventario.Dal;

namespace Corp.Cencosud.Supermercados.Inventario.Test.Biz
{
    /// <summary>
    /// Descripción resumida de CCTest
    /// </summary>
    [TestClass]
    public class CCTest
    {
        private CCBiz _servicio;
        private FakeUOW_CDsDB _FakeUOW_CDsDB;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_CDsDB = new FakeUOW_CDsDB();
            _FakeUOW_CDsDB.CCs = CCs();
            _servicio = new CCBiz(_FakeUOW_CDsDB);
        }

        public List<INV_dCCsActivos> CCs()
        {
            return new List<INV_dCCsActivos>(){
                new INV_dCCsActivos()
                {
                    cc = 1,
                    descripcion = "aaa",
                    estado = "A",
                    id = 1,
                    idb = 1,
                    idRegion = 1,
                    ts = DateTime.Now,
                    usuario = "Cencosud\\EA0344"
                },
                new INV_dCCsActivos()
                {
                    cc = 2,
                    descripcion = "aaa",
                    estado = "A",
                    id = 2,
                    idb = 2,
                    idRegion = 1,
                    ts = DateTime.Now,
                    usuario = "Cencosud\\EA0344"
                },
                new INV_dCCsActivos()
                {
                    cc = 4,
                    descripcion = "aaa",
                    estado = "A",
                    id = 4,
                    idb = 4,
                    idRegion = 2,
                    ts = DateTime.Now,
                    usuario = "Cencosud\\EA0344"
                },
            };
        }

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        [TestMethod]
        public void GetxIdRegionTest()
        {
            var result = _servicio.GetxIdRegion(1);

            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dCCsActivosRepository.AccessCounterInsert, "FakeINV_dCCsActivosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dCCsActivosRepository.AccessCounterGet, "FakeINV_dCCsActivosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dCCsActivosRepository.AccessCounterQuery, "FakeINV_dCCsActivosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dCCsActivosRepository.AccessCounterUpdate, "FakeINV_dCCsActivosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dCCsActivosRepository.AccessCounterDelete, "FakeINV_dCCsActivosRepository.AccessCounterDelete");
            Assert.AreEqual(2, result.Count);
        }
    }
}
