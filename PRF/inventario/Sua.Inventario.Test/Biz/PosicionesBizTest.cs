using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz;
using Sua.Inventario.Test.Biz.Fakes;
using Corp.Cencosud.Supermercados.Sua.Inventario.Dal;

namespace Corp.Cencosud.Supermercados.Inventario.Test.Biz
{
    /// <summary>
    /// Descripción resumida de PosicionesBizTest
    /// </summary>
    [TestClass]
    public class PosicionesBizTest
    {
        private PosicionesBiz _servicio;
        private FakeUOW_CDsDB _FakeUOW_CDsDB;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_CDsDB = new FakeUOW_CDsDB();
            _FakeUOW_CDsDB.INV_dPosiciones = Posiciones();
            _servicio = new PosicionesBiz(_FakeUOW_CDsDB);
        }

        private static List<INV_dPosiciones> Posiciones()
        {
            return new List<INV_dPosiciones>() { new INV_dPosiciones()
            {
                id = 1,
                idDocumento = 1,
                sector = "bab",
                pasillo = "bab",
                columna = 1,
                nivel = 1,
                compart = 1,
                etiqueta = "bab",
                ean13 = "bab",
                descripcion = "bab",
                proveedor = "bab",
                id_orden_compra = "bab",
                fecha_hora_recepcion = DateTime.Now,
                vencimiento = DateTime.Now,
                vidautil = 1,
                diasvencer = "bab",
                cxh = 1,
                hxp = 1,
                uxb = 1,
                uxpack = 1,
                bultos = 1,
                packs = 1,
                unidades = 1,
                recepcionista = "bab",
                almacenador = "bab",
                estadocalidad = "bab",
                cara = 1,
                usuario = "bab",
                digito = "bab",
                bultosinv = 1,
                ts = DateTime.Now,
                fechaact = DateTime.Now,
                usuarioinventario = "bab",
                tipoinventario = "bab",
                hxpinv = 1,
                cajassueltasinv = 1,
                estado = "bab",
                observaciones = "bab",
                codigoarticulo = "bab",
                tipolectura = "bab",
                documentoasociado = "bab",
                INV_dDocumentos = new INV_dDocumentos()
            } };
        }

        [TestMethod]
        public void GetxDocumentoIdTest()
        {
            var result = _servicio.GetxDocumentoId(1);

            Assert.AreEqual(1, result.Count);
        }
        [TestMethod]
        public void GetAllxFiltrosTest()
        {
            var result = _servicio.GetAllxFiltros("1", 1, 1, 1);

            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_CDsDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_CDsDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dPosicionesRepository.AccessCounterInsert, "FakeINV_dPosicionesRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dPosicionesRepository.AccessCounterGet, "FakeINV_dPosicionesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dPosicionesRepository.AccessCounterQuery, "FakeINV_dPosicionesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dPosicionesRepository.AccessCounterUpdate, "FakeINV_dPosicionesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dPosicionesRepository.AccessCounterDelete, "FakeINV_dPosicionesRepository.AccessCounterDelete");
        }
    }
}
