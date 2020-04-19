using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz;
using Sua.Accesos.Test.Biz.Fakes;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using System.Collections.Generic;
using System.Linq;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;

namespace Sua.Accesos.Test.Biz
{
    [TestClass]
    public class AppContextBizTest
    {
        private AppContextBiz _servicio;
        private FakeUOW_AccesosDB _FakeUOW_AccesosDB;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_AccesosDB = new FakeUOW_AccesosDB();
            _FakeUOW_AccesosDB.ACC_dUsuarios = ListaUsuarios();
            _FakeUOW_AccesosDB.ACC_dPerfiles = ListaPerfiles();
            _FakeUOW_AccesosDB.ACC_rdUsuarios_dPerfiles_dAcciones = ListaPerfilesxUsuario();
            _FakeUOW_AccesosDB.ACC_dMenu = ListaMenu();
            _servicio = new AppContextBiz(_FakeUOW_AccesosDB);
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

        public List<ACC_dPerfiles> ListaPerfiles()
        {
            return new List<ACC_dPerfiles>
            {
                new ACC_dPerfiles { idRegion = 1,
                               descripcion = "perfil 1",
                               idEstado = "A",
                               id = 1,
                               idAplicacion = "ACC",
                               ts = new DateTime(),
                               usuario = "EB2122" },
                new ACC_dPerfiles { idRegion = 1,
                               descripcion = "perfil 2",
                               idEstado = "A",
                               id = 2,
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
                    ACC_rdUsuarios_dPerfiles_dAcciones = new List<ACC_rdUsuarios_dPerfiles_dAcciones>
                    {
                        new ACC_rdUsuarios_dPerfiles_dAcciones
                        {
                            idPerfilAccion = 1,
                            usuario = "Cencosud\\EA0303",
                            idUsuario = 1,
                            ts = DateTime.Now
                        }
                    }
                }
            };
        }
        public List<ACC_dMenu> ListaMenu()
        {
            return new List<ACC_dMenu>
            {
                new ACC_dMenu {
                    id = 1,
                     descripcion = "menu",
                     idAplicacion = "ACC",
                     idEstado ="A",
                     imagen = "",
                     idMenu_Precede = null,
                     nombre = "adsfadsf",
                     orden = 1,
                     tooltip = "adsfads",
                     ts = DateTime.Now,
                     url = "",
                     usuario = "EA234",
                     usuariosMaximos = 10,
                     ACC_dAplicaciones = new ACC_dAplicaciones(),
                     ACC_sEstados = new ACC_sEstados()
                     },
                    new ACC_dMenu
                    {
                        id = 2,
                        descripcion = "menu 2",
                        idAplicacion = "ACC",
                        idEstado = "A",
                        imagen = "",
                        idMenu_Precede = null,
                        nombre = "adsfadsfaaa",
                        orden = 1,
                        tooltip = "adsfads",
                        ts = DateTime.Now,
                        url = "",
                        usuario = "EA234",
                        usuariosMaximos = 10,
                        ACC_dAplicaciones = new ACC_dAplicaciones(),
                        ACC_sEstados = new ACC_sEstados()
                    },
                    new ACC_dMenu
                    {
                        id = 5,
                        descripcion = "menu 2",
                        idAplicacion = "ACC",
                        idEstado = "A",
                        imagen = "",
                        idMenu_Precede = 1,
                        nombre = "adsfadsfaaa",
                        orden = 1,
                        tooltip = "adsfads",
                        ts = DateTime.Now,
                        url = "",
                        usuario = "EA234",
                        usuariosMaximos = 10,
                        ACC_dAplicaciones = new ACC_dAplicaciones(),
                        ACC_sEstados = new ACC_sEstados()
                    }
            };
        }
        [TestMethod]
        public void GetContextTest()
        {
            var result = _servicio.GetContext("Cencosud\\EA0303", "ACC");

            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dMenuRepository.AccessCounterGet, "FakeACC_dMenuRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dMenuRepository.AccessCounterQuery, "FakeACC_dMenuRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dMenuRepository.AccessCounterInsert, "FakeACC_dMenuRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dMenuRepository.AccessCounterUpdate, "FakeACC_dMenuRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dMenuRepository.AccessCounterDelete, "FakeACC_dMenuRepository.AccessCounterDelete");


            Assert.AreEqual(result.usuario.id, 1);
            Assert.AreEqual(result.menu.First().id, 1);
        }
        [TestMethod]
        public void GetContextTest_Exe()
        {
            try
            {
                _FakeUOW_AccesosDB.ACC_dUsuarios = null;
                _FakeUOW_AccesosDB.ACC_dPerfiles = null;
                _FakeUOW_AccesosDB.ACC_rdUsuarios_dPerfiles_dAcciones = null;
                _FakeUOW_AccesosDB.ACC_dMenu = null;
                var result = _servicio.GetContext("Cencosud\\EA0303", "ACC");
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(NotAllowedException), e.GetType());
            }
        }

    }
}