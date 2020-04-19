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
    public class AplicacionBizTest
    {
        private AplicacionBiz _servicio;
        private FakeUOW_AccesosDB _FakeUOW_AccesosDB;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_AccesosDB = new FakeUOW_AccesosDB();
            _FakeUOW_AccesosDB.ACC_dAplicaciones = ListaApp();
            _servicio = new AplicacionBiz(_FakeUOW_AccesosDB);
        }

        public List<ACC_dAplicaciones> ListaApp()
        {
            return new List<ACC_dAplicaciones>
            {
                new ACC_dAplicaciones { 
                    descripcion = "APP 1",
                    idEstado = "A",
                    id = "AP1",
                    ts = new DateTime(),
                    accesos = "S",
                    esPocket = "S",
                    imagen = null,
                    tooltip = "AFDSASDF",
                    url = "ASDF"},
                new ACC_dAplicaciones {
                    descripcion = "APP 2",
                    idEstado = "A",
                    id = "AP2",
                    ts = new DateTime(),
                    accesos = "S",
                    esPocket = "S",
                    imagen = null,
                    tooltip = "AFDSASDF",
                    url = "ASDF"}
             };
        }

        

        [TestMethod]
        public void GetTest()
        {
            var result = _servicio.GetxId("AP1");

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dAplicacionesRepository.AccessCounterGet, "FakeACC_dAplicacionesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dAplicacionesRepository.AccessCounterQuery, "FakeACC_dAplicacionesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dAplicacionesRepository.AccessCounterInsert, "FakeACC_dAplicacionesRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dAplicacionesRepository.AccessCounterUpdate, "FakeACC_dAplicacionesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dAplicacionesRepository.AccessCounterDelete, "FakeACC_dAplicacionesRepository.AccessCounterDelete");
            Assert.AreEqual(result.id, "AP1");
        }
        [TestMethod]
        public void GetTest_NotFound()
        {
            try
            {
                var result = _servicio.GetxId("Test");
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
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dAplicacionesRepository.AccessCounterGet, "FakeACC_dAplicacionesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dAplicacionesRepository.AccessCounterQuery, "FakeACC_dAplicacionesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dAplicacionesRepository.AccessCounterInsert, "FakeACC_dAplicacionesRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dAplicacionesRepository.AccessCounterUpdate, "FakeACC_dAplicacionesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dAplicacionesRepository.AccessCounterDelete, "FakeACC_dAplicacionesRepository.AccessCounterDelete");
            Assert.AreNotEqual(0,result.Count);
        }
        [TestMethod]
        public void GetAllTest_NotFound()
        {
            try
            {
                _FakeUOW_AccesosDB.ACC_dAplicaciones = null;
                var result = _servicio.GetAll();
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(ArgumentNullException), e.GetType());
            }

        }


    }
}
