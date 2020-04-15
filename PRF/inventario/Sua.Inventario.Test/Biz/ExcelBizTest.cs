using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sua.Inventario.Test.Biz.Fakes;

namespace Corp.Cencosud.Supermercados.Inventario.Test.Biz
{
    [TestClass]
   public  class ExcelBizTest
    {
        private ExcelBiz _servicio;
        private FakeUOW_CDsDB _FakeUOW_CDsDB;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_CDsDB = new FakeUOW_CDsDB();
            _servicio = new ExcelBiz(_FakeUOW_CDsDB);
        }

        [TestMethod]
        public void DescargarEstadoActualTest()
        {
            var resp = _servicio.DescargarEstadoActual(1);
            Assert.IsInstanceOfType(resp,typeof(byte[]));
        }
        [TestMethod]
        public void DescargarPosicionesExcelTest()
        {
            var resp = _servicio.DescargarPosicionesExcel(1);
            Assert.IsInstanceOfType(resp, typeof(byte[]));
        }
        [TestMethod]
        public void DescargarPosicionexInventarioExcelTest()
        {
            var resp = _servicio.DescargarPosicionexInventario(1);
            Assert.IsInstanceOfType(resp, typeof(byte[]));
        }
    }
}
