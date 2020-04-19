using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Sua.Accesos.Test.Biz.Fakes;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using System.Collections.Generic;
using System.Linq;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;

namespace Sua.Accesos.Test.Biz
{
    [TestClass]
    public class AccionBizTest
    {
        private AccionBiz _servicio;
        private FakeUOW_AccesosDB _FakeUOW_AccesosDB;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_AccesosDB = new FakeUOW_AccesosDB();
            _FakeUOW_AccesosDB.ACC_dAcciones = ListaAcciones();
            _servicio = new AccionBiz(_FakeUOW_AccesosDB);
        }

        public List<ACC_dAcciones> ListaAcciones()
        {
            return new List<ACC_dAcciones>()
            {
                new ACC_dAcciones()
                {
                    descripcion = "Test",
                    id = 1,
                    idAplicacion = "ACC",
                    idEstado = "A",
                    ts = DateTime.Now,
                    usuario = "Roro"
                }
            };
        }

        [TestMethod]
        public void GetTest()
        {
            var result = _servicio.GetByIdApp("ACC");

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACCdAccionesRepository.AccessCounterGet, "FakeACCdAccionesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACCdAccionesRepository.AccessCounterQuery, "FakeACCdAccionesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACCdAccionesRepository.AccessCounterInsert, "FakeACCdAccionesRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACCdAccionesRepository.AccessCounterUpdate, "FakeACCdAccionesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACCdAccionesRepository.AccessCounterDelete, "FakeACCdAccionesRepository.AccessCounterDelete");
            Assert.AreNotEqual(0,result.Count);
        }
        [TestMethod]
        public void GetTest_NotFound()
        {
            try
            {
                var result = _servicio.GetByIdApp("Test");
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(NotFoundException), e.GetType());
            }

        }
        [TestMethod]
        public void GetAllTest_OK()
        {
            var result = _servicio.GetAll();

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACCdAccionesRepository.AccessCounterGet, "FakeACCdAccionesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACCdAccionesRepository.AccessCounterQuery, "FakeACCdAccionesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACCdAccionesRepository.AccessCounterInsert, "FakeACCdAccionesRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACCdAccionesRepository.AccessCounterUpdate, "FakeACCdAccionesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACCdAccionesRepository.AccessCounterDelete, "FakeACCdAccionesRepository.AccessCounterDelete");
            Assert.AreNotEqual(0,result.Count);
        }
        [TestMethod]
        public void GetAllTest_NotFound()
        {
            try
            {
                _FakeUOW_AccesosDB.ACC_dAcciones = null;
                var result = _servicio.GetAll();
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(ArgumentNullException), e.GetType());
            }

        }


    }
}
