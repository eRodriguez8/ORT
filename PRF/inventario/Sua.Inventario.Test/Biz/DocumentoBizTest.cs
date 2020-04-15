using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sua.Inventario.Test.Biz.Fakes;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz;
using Corp.Cencosud.Supermercados.Sua.Inventario.Dal;
using System.Collections.Generic;
using System.Linq;
using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;

namespace Corp.Cencosud.Supermercados.Inventario.Test.Biz
{
    [TestClass]
    public class DocumentoBizTest
    {
        private DocumentoBiz _servicio;
        private FakeUOW_CDsDB _FakeUOW_CDsDB;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_CDsDB = new FakeUOW_CDsDB();
            _FakeUOW_CDsDB.INV_dDocumentos = documentos();
            _servicio = new DocumentoBiz(_FakeUOW_CDsDB);
        }

        public static IList<INV_dDocumentos> documentos()
        {
            return new List<INV_dDocumentos>()
            {
                new INV_dDocumentos()
                {
                    id = 1,
                    Documento = "documentos",
                    LegajoAsignado = "",
                    Estado = 1,
                    Fecha = DateTime.Now,
                    Usuario = "EA0344",
                    idInventario = 1,
                    Fase  = 1,
                    idDocumentoPadre  = null,
                    INV_dPosiciones = new List<INV_dPosiciones>()
                    {
                        new INV_dPosiciones()
                        {
                            pasillo = "1",
                            columna = 1,
                            nivel = 1
                        },
                        new INV_dPosiciones()
                        {
                            pasillo = "2",
                            columna = 2,
                            nivel = 2
                        }
                    }
                },
                new INV_dDocumentos()
                {
                    id = 2,
                    Documento = "documentos 2",
                    LegajoAsignado = "",
                    Estado = 1,
                    Fecha = DateTime.Now,
                    Usuario = "EA0344",
                    idInventario = 1,
                    Fase  = 1,
                    idDocumentoPadre  = null,
                    INV_dPosiciones = new List<INV_dPosiciones>()
                    {
                        new INV_dPosiciones()
                        {
                            pasillo = "1",
                            columna = 1,
                            nivel = 1
                        },
                        new INV_dPosiciones()
                        {
                            pasillo = "2",
                            columna = 2,
                            nivel = 2
                        }
                    }
                }
            };
        }

        [TestMethod]
        public void GetByIdInventarioTest()
        {
            var result = _servicio.GetByIdInventario(1);

            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_CDsDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_CDsDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterInsert, "FakeINV_dDocumentosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterGet, "FakeINV_dDocumentosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterQuery, "FakeINV_dDocumentosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterUpdate, "FakeINV_dDocumentosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterDelete, "FakeINV_dDocumentosRepository.AccessCounterDelete");
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var result = _servicio.GetById(1);

            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_CDsDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_CDsDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterInsert, "FakeINV_dDocumentosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterGet, "FakeINV_dDocumentosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterQuery, "FakeINV_dDocumentosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterUpdate, "FakeINV_dDocumentosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterDelete, "FakeINV_dDocumentosRepository.AccessCounterDelete");
        }

        [TestMethod]
        public void GetAllTest()
        {
            var result = _servicio.GetAll(1);

            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_CDsDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_CDsDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterInsert, "FakeINV_dDocumentosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterGet, "FakeINV_dDocumentosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterQuery, "FakeINV_dDocumentosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterUpdate, "FakeINV_dDocumentosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterDelete, "FakeINV_dDocumentosRepository.AccessCounterDelete");
        }

        [TestMethod]
        public void InsertBulkTest()
        {
            var result = _servicio.InsertBulk(documentos().ToList().ToModel());

            Assert.AreEqual(1, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_CDsDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_CDsDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterInsert, "FakeINV_dDocumentosRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterGet, "FakeINV_dDocumentosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterQuery, "FakeINV_dDocumentosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterUpdate, "FakeINV_dDocumentosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterDelete, "FakeINV_dDocumentosRepository.AccessCounterDelete");
        }

        [TestMethod]
        public void DeleteById()
        {
            _servicio.DeleteById(1);

            Assert.AreEqual(1, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_CDsDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_CDsDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterInsert, "FakeINV_dDocumentosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterGet, "FakeINV_dDocumentosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterQuery, "FakeINV_dDocumentosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterUpdate, "FakeINV_dDocumentosRepository.AccessCounterUpdate");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterDelete, "FakeINV_dDocumentosRepository.AccessCounterDelete");
        }

        [TestMethod]
        public void CancelarDocumentosxIdInventarioTest()
        {
            _servicio.CancelarDocumentosxIdInventario(1);

            Assert.AreEqual(1, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_CDsDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_CDsDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterInsert, "FakeINV_dDocumentosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterGet, "FakeINV_dDocumentosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterQuery, "FakeINV_dDocumentosRepository.AccessCounterQuery");
            Assert.AreEqual(2, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterUpdate, "FakeINV_dDocumentosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterDelete, "FakeINV_dDocumentosRepository.AccessCounterDelete");
        }

        [TestMethod]
        public void GetAllxFiltrosTest()
        {
            var result = _servicio.GetAllxFiltros("1", 1, 1, "documentos", 1, 1,0,"0");

            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_CDsDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_CDsDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterInsert, "FakeINV_dDocumentosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterGet, "FakeINV_dDocumentosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterQuery, "FakeINV_dDocumentosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterUpdate, "FakeINV_dDocumentosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterDelete, "FakeINV_dDocumentosRepository.AccessCounterDelete");
        }

        [TestMethod]
        public void AsignarTest()
        {
            _servicio.Asignar(1, "EA0344");

            Assert.AreEqual(1, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_CDsDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_CDsDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterInsert, "FakeINV_dDocumentosRepository.AccessCounterInsert");
            Assert.AreEqual(2, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterGet, "FakeINV_dDocumentosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterQuery, "FakeINV_dDocumentosRepository.AccessCounterQuery");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterUpdate, "FakeINV_dDocumentosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterDelete, "FakeINV_dDocumentosRepository.AccessCounterDelete");
        }

        [TestMethod]
        public void DesasignarTest()
        {
            _servicio.Desasignar(1);

            Assert.AreEqual(1, _FakeUOW_CDsDB.AccessCounterSave, "FakeUOW_CDsDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_CDsDB.AccessCounterDispose, "FakeUOW_CDsDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterInsert, "FakeINV_dDocumentosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterGet, "FakeINV_dDocumentosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterQuery, "FakeINV_dDocumentosRepository.AccessCounterQuery");
            Assert.AreEqual(1, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterUpdate, "FakeINV_dDocumentosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_CDsDB.FakeINV_dDocumentosRepository.AccessCounterDelete, "FakeINV_dDocumentosRepository.AccessCounterDelete");
        }
    }
}
