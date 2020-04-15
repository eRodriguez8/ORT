using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Corp.Cencosud.Supermercados.Sua.IWMS.Dal;
using Corp.Cencosud.Supermercados.Corp.Cencosud.Supermercados.Sua.IWMS.Biz;
using Moq;
using Corp.Cencosud.Supermercados.Sua.IWMS.Ent;

namespace Corp.Cencosud.Supermercados.Sua.IWMS.Test.Biz
{
    /// <summary>
    /// Descripción resumida de InventarioSegaTest
    /// </summary>
    [TestClass]
    public class InventarioSegaBizTest
    {
        private Mock<IContextCDsEntities> _dalMock;
        private IInventarioSegaBiz _biz;

        [TestInitialize]
        public void Init()
        {
            _dalMock = new Mock<IContextCDsEntities>();
            _biz = new InventarioSegaBiz(_dalMock.Object);
        }

        public InventarioSegaBizTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }
        
        [TestMethod]
        [TestCategory("Unitario")]
        public void ReiniciarDocumentoTest()
        {
            // Arrange
            var iddoc = 123;

            _dalMock.Setup(x => x.INV_dPosiciones_ReiniciarDocumento(iddoc))
               .Returns(new List<bool?> { true });

            // Action
            var response = _biz.ReiniciarDocumento(iddoc);
            
            // Assert
            _dalMock.Verify(x => x.INV_dPosiciones_ReiniciarDocumento(iddoc), Times.Once);

            Assert.IsTrue(response);
        }

        [TestMethod]
        [TestCategory("Unitario")]
        public void ReiniciarDocumentoTestFalse()
        {
            // Arrange
            var iddoc = 123;

            _dalMock.Setup(x => x.INV_dPosiciones_ReiniciarDocumento(iddoc))
               .Returns(new List<bool?> { false });

            // Action
            var response = _biz.ReiniciarDocumento(iddoc);


            // Assert
            _dalMock.Verify(x => x.INV_dPosiciones_ReiniciarDocumento(iddoc), Times.Once);

            Assert.IsFalse(response);
        }
        [TestMethod]
        [TestCategory("Unitario")]
        public void ReiniciarDocumentoTestExe()
        {

            try
            {
                var response = _biz.ReiniciarDocumento(123);
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(InvalidOperationException),e.GetType());
            }
        }

        [TestMethod]
        [TestCategory("Unitario")]
        public void UpdateTest()
        {
            // Arrange

            var update = new InventarioUpdate()
            {
                id = 1,
                usuario = "ema",
                digito = "123",
                bultosInv = 2,
                usuarioInventario = "test",
                hxPInv = 1,
                cajasSueltasInv = 1,
                observaciones = "carlos sabe",
                codigoArticulo = "batata"
            };

            var id = 1;
            var usuario = "ema";
            var digito = "123";
            var bultosInv = 2;
            var usuarioInventario = "test";
            var hxPInv = 1;
            var cajasSueltasInv = 1;
            var observaciones = "carlos sabe";
            var codigoArticulo = "batata";


            _dalMock.Setup(x => x.INV_dPosiciones_Update(id, usuario, digito, bultosInv, usuarioInventario, hxPInv, cajasSueltasInv, observaciones, codigoArticulo))
                .Returns(new List<bool?>{true});

            // Action
            var response = _biz.Update(update);

            // Assert
            _dalMock.Verify(x => x.INV_dPosiciones_Update(id, usuario, digito, bultosInv, usuarioInventario, hxPInv, cajasSueltasInv, observaciones, codigoArticulo), Times.Once);

            Assert.IsTrue(response);
        }

        [TestMethod]
        [TestCategory("Unitario")]
        public void UpdateTestFalse()
        {
            // Arrange

            var update = new InventarioUpdate()
            {
                id = 1,
                usuario = "ema",
                digito = "123",
                bultosInv = 2,
                usuarioInventario = "test",
                hxPInv = 1,
                cajasSueltasInv = 1,
                observaciones = "carlos sabe",
                codigoArticulo = "batata"
            };

            var id = 1;
            var usuario = "ema";
            var digito = "123";
            var bultosInv = 2;
            var usuarioInventario = "test";
            var hxPInv = 1;
            var cajasSueltasInv = 1;
            var observaciones = "carlos sabe";
            var codigoArticulo = "batata";


            _dalMock.Setup(x => x.INV_dPosiciones_Update(id, usuario, digito, bultosInv, usuarioInventario, hxPInv, cajasSueltasInv, observaciones, codigoArticulo))
                .Returns(new List<bool?> { false });

            // Action
            var response = _biz.Update(update);

            // Assert
            _dalMock.Verify(x => x.INV_dPosiciones_Update(id, usuario, digito, bultosInv, usuarioInventario, hxPInv, cajasSueltasInv, observaciones, codigoArticulo), Times.Once);

            Assert.IsFalse(response);
        }

        [TestMethod]
        [TestCategory("Unitario")]
        public void UpdateTestExe()
        {
            try
            {

                var update = new InventarioUpdate()
                {
                    id = 1,
                    usuario = "ema",
                    digito = "123",
                    bultosInv = 2,
                    usuarioInventario = "test",
                    hxPInv = 1,
                    cajasSueltasInv = 1,
                    observaciones = "carlos sabe",
                    codigoArticulo = "batata"
                };

                var response = _biz.Update(update);
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(InvalidOperationException), e.GetType());
            }
        }

        [TestMethod]
        [TestCategory("Unitario")]
        public void SelectByDocumentoTest()
        {
            // Arrange
            var iddoc = 123;

            _dalMock.Setup(x => x.INV_dPosiciones_SelectByDocumento(iddoc))
                .Returns(new List<INV_dPosiciones_SelectByDocumento_Result> { new INV_dPosiciones_SelectByDocumento_Result {
                    TotalRegistros = 1,
                    Escritos = 2,
                    PrimerId = 3,
                    PrimerIdDisponible = 4
                }});

            // Action
            var response = _biz.GetPosicionesxIdDoc(iddoc);

            // Assert
            _dalMock.Verify(x => x.INV_dPosiciones_SelectByDocumento(iddoc), Times.Once);

            Assert.AreEqual(1, response.TotalRegistros);
            Assert.AreEqual(2, response.Escritos);
            Assert.AreEqual(3, response.PrimerId);
            Assert.AreEqual(4, response.PrimerIdDisponible);
        }

        [TestMethod]
        [TestCategory("Unitario")]
        public void SelectByDocumentoTest_Exe()
        {
            try
            {
                var response = _biz.GetPosicionesxIdDoc(123);
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(InvalidOperationException), e.GetType());
            }
        }

        [TestMethod]
        [TestCategory("Unitario")]
        public void PrimerRegistroDisponibleTest()
        {
            // Arrange
            var iddoc = 123;

            _dalMock.Setup(x => x.INV_dPosiciones_SelectDisponible(iddoc))
                .Returns(new List<INV_dPosiciones_SelectDisponible_Result> { new INV_dPosiciones_SelectDisponible_Result {
                    id = 1,
                    sector = "bab",
                    pasillo= "2",
                    columna = 3,
                    nivel = 4,
                    compart = 5,
                    etiqueta = "carlos",
                    ean13 = "javi",
                    descripcion = "juli",
                    proveedor = "nico",
                    id_orden_compra = "pablo",
                    vidautil = 6,
                    diasvencer = "ale",
                    cxh = 7,
                    hxp = 8,
                    uxb = 9,
                    uxpack = 10,
                    bultos = 11,
                    packs = 12,
                    unidades = 13,
                    recepcionista = "diego",
                    almacenador = "mati2",
                    estadocalidad = "mati3",
                    cara = 14,
                    usuario= "haydee",
                    digito = "mati",
                    bultosinv = 15,
                    usuarioinventario = "martin",
                    hxpinv = 16,
                    cajassueltasinv = 17,
                    estado = "jhon",
                    observaciones = "luciano",
                    codigoarticulo = "bianca",

                }});

            // Action
            var response = _biz.PrimerRegistroDisponible(iddoc);

            // Assert
            _dalMock.Verify(x => x.INV_dPosiciones_SelectDisponible(iddoc), Times.Once);

            Assert.AreEqual(1, response.Id);
            Assert.AreEqual("bab", response.Sector);
            Assert.AreEqual("2", response.PASILLO);
            Assert.AreEqual(3, response.COLUMNA);
            Assert.AreEqual(4, response.NIVEL);
            Assert.AreEqual(5, response.COMPART);
            Assert.AreEqual("carlos", response.ETIQUETA);
            Assert.AreEqual("javi", response.ean13);
            Assert.AreEqual("juli", response.DESCRIPCION);
            Assert.AreEqual("nico", response.Proveedor);
            Assert.AreEqual("pablo", response.ID_ORDEN_COMPRA);
            Assert.AreEqual(6, response.VidaUtil);
            Assert.AreEqual("ale", response.DiasVencer);
            Assert.AreEqual(7, response.CxH);
            Assert.AreEqual(8, response.HxP);
            Assert.AreEqual(9, response.UxB);
            Assert.AreEqual(10, response.UxPack);
            Assert.AreEqual(11, response.Bultos);
            Assert.AreEqual(12, response.Packs);
            Assert.AreEqual(13, response.Unidades);
            Assert.AreEqual("diego", response.Recepcionista);
            Assert.AreEqual("mati2", response.Almacenador);
            Assert.AreEqual("mati3", response.EstadoCalidad);
            Assert.AreEqual(14, response.CARA);
            Assert.AreEqual("haydee", response.Usuario);
            Assert.AreEqual("mati", response.Digito);
            Assert.AreEqual(15, response.BultosInv);
            Assert.AreEqual("martin", response.UsuarioInventario);
            Assert.AreEqual(16, response.HxPInv);
            Assert.AreEqual(17, response.CajasSueltasInv);
            Assert.AreEqual("jhon", response.Estado);
            Assert.AreEqual("luciano", response.Observaciones);
            Assert.AreEqual("bianca", response.CodigoArticulo);
        }
        [TestMethod]
        [TestCategory("Unitario")]
        public void PrimerRegistroDisponibleTest_Exe()
        {
            try
            {
                var response = _biz.PrimerRegistroDisponible(123);
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(InvalidOperationException), e.GetType());
            }
        }
        [TestMethod]
        [TestCategory("Unitario")]
        public void GetDocumentoTest()
        {
            // Arrange
            var legajoTest = "3020";

            _dalMock.Setup(x => x.INV_dDocumentos_SelectxLegajo(legajoTest))
                .Returns(new List<INV_dDocumentos_SelectxLegajo_Result> { new INV_dDocumentos_SelectxLegajo_Result() {
                    id = 1,
                    Documento = "Test"
                }});

            // Action
            var response = _biz.GetDocumento(legajoTest);

            // Assert
            _dalMock.Verify(x => x.INV_dDocumentos_SelectxLegajo(legajoTest), Times.Once);

            Assert.AreEqual(1, response.idDoc);
            Assert.AreEqual("Test", response.documento);
        }

        [TestMethod]
        [TestCategory("Unitario")]
        public void GetDocumentoTest_Exe()
        {
            try
            {
                // Arrange
                var legajoTest = "3020";

                // Action
                var response = _biz.GetDocumento(legajoTest);
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(InvalidOperationException), e.GetType());
            }

        }

        [TestMethod]
        [TestCategory("Unitario")]
        public void ControlAutomaticoTest()
        {
            // Arrange
            var idDoc = 1;

            _dalMock.Setup(x => x.INV_dPosiciones_ValidarYCrearControles(idDoc))
                .Returns(new List<string> {"Control Automático Creado correctamente"});

            // Action
            var response = _biz.ControlAutomatico(idDoc);

            // Assert
            _dalMock.Verify(x => x.INV_dPosiciones_ValidarYCrearControles(idDoc), Times.Once);

            Assert.AreEqual("Control Automático Creado correctamente", response);

        }

        [TestMethod]
        [TestCategory("Unitario")]
        public void ControlAutomaticoTest_exe()
        {
            try
            {
                // Arrange
                var idDoc = 1;

                // Action
                var response = _biz.ControlAutomatico(idDoc);
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(InvalidOperationException), e.GetType());
            }

        }
    }
}
