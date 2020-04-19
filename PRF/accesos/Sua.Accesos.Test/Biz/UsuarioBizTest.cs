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
using Moq;

namespace Sua.Accesos.Test.Biz
{
    [TestClass]
    public class UsuarioBizTest
    {
        private UsuarioBiz _servicio;
        private UsuarioBiz _servicioConSeguridad;
        private FakeUOW_AccesosDB _FakeUOW_AccesosDB;
        private Mock<ISeguridadBiz> _SeguridadBizMock;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_AccesosDB = new FakeUOW_AccesosDB();
            _FakeUOW_AccesosDB.ACC_dUsuarios = ListaUsuarios();
            _FakeUOW_AccesosDB.ACC_rdUsuarios_dPerfiles_dAcciones = ListaPerfilesxUsuario();
            _FakeUOW_AccesosDB.ACC_dPerfiles = ListaPerfiles();
            _FakeUOW_AccesosDB.ACC_dAplicaciones = ListaApps();
            _FakeUOW_AccesosDB.ACC_rdPerfil_dAcciones = ListaPerfilAcciones();
            _SeguridadBizMock = new Mock<ISeguridadBiz>();
            _servicioConSeguridad = new UsuarioBiz(_FakeUOW_AccesosDB, _SeguridadBizMock.Object);
            _servicio = new UsuarioBiz(_FakeUOW_AccesosDB);
        }

        private List<ACC_rdPerfil_dAcciones> ListaPerfilAcciones()
        {
            return new List<ACC_rdPerfil_dAcciones> {
                                   new ACC_rdPerfil_dAcciones() {
                                   id =2,
                                   idAccion = 2,
                                   idPerfil = 2,
                                   ts = DateTime.Now,
                                   usuario = @"Cencosud\\EA0344"
                                   },
                                   new ACC_rdPerfil_dAcciones() {
                                   id =1,
                                   idAccion = 1,
                                   idPerfil = 1,
                                   ts = DateTime.Now,
                                   usuario = @"Cencosud\\EA0344"
                                   }
                               };
        }

        private List<ACC_dPerfiles> ListaPerfiles()
        {
            return new List<ACC_dPerfiles>
            {
                new ACC_dPerfiles { idRegion = 1,
                               descripcion = "perfil 1",
                               idEstado = "A",
                               id = 3,
                               idAplicacion = "ACC",
                               ts = new DateTime(),
                               usuario = "EB2122" },
                new ACC_dPerfiles { idRegion = 1,
                               descripcion = "perfil 2",
                               idEstado = "A",
                               id = 4,
                               idAplicacion = "ACC",
                               ts = new DateTime(),
                               usuario = "EB2122"
                }
             };
        }
        private List<ACC_dUsuarios> ListaUsuarios()
        {
            return new List<ACC_dUsuarios>
            {
                new ACC_dUsuarios
                {
                    apellido = "Partuzi",
                    fhAlta = System.DateTime.Now,
                    id = 1,
                    idEstado = "A",
                    legajo = "1",
                    nombre = "Ciro",
                    ts = DateTime.Now,
                    usuario = "Cencosud\\EA0303",
                    usuarioAD = "Cencosud\\EA0303",
                    fhBaja = null,
                    ACC_rdUsuarios_dPerfiles_dAcciones = ListaPerfilesxUsuario(),
                    
                },
                new ACC_dUsuarios
                {
                    apellido = "Armenio",
                    fhAlta = System.DateTime.Now,
                    id = 2,
                    idEstado = "A",
                    legajo = "2",
                    nombre = "Esteban",
                    ts = DateTime.Now,
                    usuario = "Cencosud\\EA0308",
                    usuarioAD = "Cencosud\\EA0308",
                    fhBaja = null,
                    ACC_rdUsuarios_dPerfiles_dAcciones = ListaPerfilesxUsuario()
                }
            };
        }
        private List<ACC_dAplicaciones> ListaApps()
        {
            return new List<ACC_dAplicaciones>
            {
                new ACC_dAplicaciones()
                {
                    id = "ACC",
                    descripcion = "Acceso",
                    idEstado = "A",
                    esPocket = "S",
                    imagen = "",
                    tooltip = "",
                    url = "",
                    accesos = "S",
                    ts = DateTime.Now
                },
                new ACC_dAplicaciones()
                {
                    id = "AUD",
                    descripcion = "Auditoria",
                    idEstado = "A",
                    esPocket = "S",
                    imagen = "",
                    tooltip = "",
                    url = "",
                    accesos = "S",
                    ts = DateTime.Now
                }
            };
        }

        private List<ACC_rdUsuarios_dPerfiles_dAcciones> ListaPerfilesxUsuario()
        {
            return new List<ACC_rdUsuarios_dPerfiles_dAcciones>
            {
                new ACC_rdUsuarios_dPerfiles_dAcciones { idPerfilAccion = 1,
                    idUsuario = 1,
                    ACC_dUsuarios = new ACC_dUsuarios
                    {
                            apellido = "Partuzi",
                            fhAlta = System.DateTime.Now,
                            id = 1,
                            idEstado = "A",
                            legajo = "1",
                            nombre = "Ciro",
                            ts = DateTime.Now,
                            usuario = "Cencosud\\EA0303",
                            usuarioAD = "Cencosud\\EA0303",
                            fhBaja = null
                    },
                    ACC_rdPerfil_dAcciones = new ACC_rdPerfil_dAcciones()
                    {
                        id = 1,
                        idAccion = 1,
                        idPerfil = 1,
                        ACC_dAcciones = new ACC_dAcciones()
                        {
                            id = 1,
                            descripcion = "aaa",
                            idAplicacion = "ACC",
                            idEstado = "A",
                            ACC_dAplicaciones = new ACC_dAplicaciones()
                            {
                                id = "ACC",
                                descripcion = "Acceso",
                                idEstado = "A",
                                esPocket = "S",
                                imagen = "",
                                tooltip = "",
                                url = "",
                                accesos = "S",
                                ts = DateTime.Now
                            }
                        },
                        ACC_dPerfiles = new ACC_dPerfiles { idRegion = 1,
                               descripcion = "perfil 1",
                               idEstado = "A",
                               id = 1,
                               idAplicacion = "ACC",
                               ts = new DateTime(),
                               usuario = "EB2122" }
                }
                },
                new ACC_rdUsuarios_dPerfiles_dAcciones { idPerfilAccion = 2,
                    idUsuario = 1,
                    ACC_dUsuarios = new ACC_dUsuarios
                    {
                            apellido = "Partuzi",
                            fhAlta = System.DateTime.Now,
                            id = 1,
                            idEstado = "A",
                            legajo = "1",
                            nombre = "Ciro",
                            ts = DateTime.Now,
                            usuario = "Cencosud\\EA0303",
                            usuarioAD = "Cencosud\\EA0303",
                            fhBaja = null
                    },
                    ACC_rdPerfil_dAcciones = new ACC_rdPerfil_dAcciones()
                    {
                        id = 2,
                        idAccion = 2,
                        idPerfil = 1,
                        ACC_dAcciones = new ACC_dAcciones()
                        {
                            id = 2,
                            descripcion = "bbbb",
                            idAplicacion = "ACC",
                            idEstado = "A",
                            ACC_dAplicaciones = new ACC_dAplicaciones()
                            {
                                id = "ACC",
                                descripcion = "Acceso",
                                idEstado = "A",
                                esPocket = "S",
                                imagen = "",
                                tooltip = "",
                                url = "",
                                accesos = "S",
                                ts = DateTime.Now
                            }
                        },
                        ACC_dPerfiles = new ACC_dPerfiles { idRegion = 1,
                               descripcion = "perfil 1",
                               idEstado = "A",
                               id = 1,
                               idAplicacion = "ACC",
                               ts = new DateTime(),
                               usuario = "EB2122" }
                }
                }
            };
        }

        [TestMethod]
        public void CreateTest()
        {
            var usuario = ListaUsuarios().First().ToModel();
            usuario.id = 3;
            usuario.legajo = "45";
            var result = _servicioConSeguridad.Create(usuario);

            Assert.AreEqual(1, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(2, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");
            Assert.AreEqual(result.id, 3);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var result = _servicioConSeguridad.Delete("1", "eadwd22");

            Assert.AreEqual(1, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");


            var user = _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.Data.Single(x => x.id == 1);
            Assert.AreEqual(user.idEstado, "I");
        }

        [TestMethod]
        public void GetTest()
        {
            var result = _servicio.Get(1);

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");
            Assert.AreEqual(result.id, 1);
        }


        [TestMethod]
        public void GetExceptionTest()
        {
            try
            {
                var result = _servicio.Get(8);

            }
            catch (NotFoundException e)
            {
                Assert.AreEqual(e.GetType().Name, "NotFoundException");
            }
        }

        [TestMethod]
        public void GetByUsuarioADExceptionTest()
        {
            try
            {
                var result = _servicio.GetxUsuarioAD("aaaaaaaaa");

            }
            catch (NotFoundException e)
            {
                Assert.AreEqual(e.GetType().Name, "NotFoundException");
            }
        }

        [TestMethod]
        public void GetxLegajoExceptionTest()
        {
            try
            {
                var result = _servicio.GetByLegajoIdAplicacion("3333","AAA");

            }
            catch (NotFoundException e)
            {
                Assert.AreEqual(e.GetType().Name, "NotFoundException");
            }
        }

        [TestMethod]
        public void GetByIdUsuarioAplicacionTest()
        {
            var result = _servicio.GetByIdUsuarioAplicacion("Cencosud\\EA0303", "ACC");

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");
            Assert.AreEqual(result.Perfiles.Count(), 2);
        }

        [TestMethod]
        public void GetByLegajoIdAplicacionTest()
        {
            var result = _servicio.GetByLegajoIdAplicacion("1", "ACC");

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");
            Assert.AreEqual(result.Perfiles.Count(), 2);
        }

        [TestMethod]
        public void GetxLegajoConPerfilesTest()
        {
            var result = _servicio.GetxLegajoConPerfiles("1");

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");
            Assert.AreEqual(result.id, 1);
        }

        [TestMethod]
        public void GetxUsuarioADTest()
        {
            var result = _servicio.GetxUsuarioAD("Cencosud\\EA0303");

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");
            Assert.AreEqual(result.id, 1);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var usuario = ListaUsuarios().First().ToModel();
            var result = _servicioConSeguridad.Update(usuario);

            Assert.AreEqual(1, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");


            var user = _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.Data.Single(x => x.id == 1);
            Assert.AreEqual(user.id, 1);
        }

        [TestMethod]
        public void CopiarUsuarioPerfilTest()
        {
            var result = _servicioConSeguridad.CopiarUsuarioPerfil("2", "1", "EA0344");

            Assert.AreEqual(1, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(3, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");

            var user = _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.Data.Single(x => x.id == 2);
            Assert.AreEqual(user.ACC_rdUsuarios_dPerfiles_dAcciones.Count(), 2);
        }

        [TestMethod]
        public void AsociarPerfilTest()
        {
            var result = _servicioConSeguridad.AsociarPerfil("1", new List<short>() { 3, 4 }, "344");

            Assert.AreEqual(1, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");
        }
    }
}
