using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sua.Accesos.Test.Biz.Fakes;

namespace Sua.Accesos.Test.Biz
{
    [TestClass]
    public class RegionBizTest
    {
        private RegionBiz _servicio;
        private FakeUOW_AccesosDB _FakeUOW_AccesosDB;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_AccesosDB = new FakeUOW_AccesosDB();
            _FakeUOW_AccesosDB.ACC_sRegiones = Regiones();
            _servicio = new RegionBiz(_FakeUOW_AccesosDB);
        }

        public static List<ACC_sRegiones> Regiones()
        {
            return new List<ACC_sRegiones>()
            {
                new ACC_sRegiones()
                {
                    descripcion = "Buenos Aires",
                    descripcionCorta = "BsAs",
                    id = 1
                }
            };
        }

        [TestMethod]
        public void GetAllTest_OK()
        {
            var result = _servicio.GetAll();
            Assert.AreNotEqual(0,result.Count);
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_sRegionesRepository.AccessCounterGet, "FakeACC_sRegionesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_sRegionesRepository.AccessCounterQuery, "FakeACC_sRegionesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_sRegionesRepository.AccessCounterInsert, "FakeACC_sRegionesRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_sRegionesRepository.AccessCounterUpdate, "FakeACC_sRegionesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_sRegionesRepository.AccessCounterDelete, "FakeACC_sRegionesRepository.AccessCounterDelete");

        }
        [TestMethod]
        public void GetAllTest_Exe()
        {
            try
            {
                _FakeUOW_AccesosDB.ACC_sRegiones = new List<ACC_sRegiones>();
                var result = _servicio.GetAll();
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(NotFoundException),e.GetType());
            }
        }
    }
}
