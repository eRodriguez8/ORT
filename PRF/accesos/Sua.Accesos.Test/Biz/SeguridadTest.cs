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
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Helpers;

namespace Sua.Accesos.Test.Biz
{
    [TestClass]
    public class SeguridadBizTest
    {
        private SeguridadBiz _servicio;
        private FakeUOW_AccesosDB _FakeUOW_AccesosDB;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_AccesosDB = new FakeUOW_AccesosDB();
            _FakeUOW_AccesosDB.ACC_dUsuarios = ListaUsuarios();
            _FakeUOW_AccesosDB.ACC_dPerfiles = ListaPerfiles();
            _FakeUOW_AccesosDB.ACC_rdUsuarios_dPerfiles_dAcciones = ListaPerfilesxUsuario();
            //_FakeUOW_AccesosDB.ACC_rdUsuarios_dPerfiles_dAcciones = ListaPerfilesxUsuario();
            //_FakeUOW_AccesosDB.ACC_dPerfiles = ListaPerfiles();
            //_FakeUOW_AccesosDB.ACC_dAplicaciones = ListaApps();
            //_FakeUOW_AccesosDB.ACC_rdPerfil_dAcciones = ListaPerfilAcciones();
            _servicio = new SeguridadBiz(_FakeUOW_AccesosDB);
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
                            descripcion = "Administrador",
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
                    usuarioAD =  Security.GetUser(),
                    fhBaja = null,
                    ACC_rdUsuarios_dPerfiles_dAcciones = new List<ACC_rdUsuarios_dPerfiles_dAcciones>() {
                        new ACC_rdUsuarios_dPerfiles_dAcciones()
                    {
                        idPerfilAccion = 1,
                        idUsuario = 1,
                        ACC_rdPerfil_dAcciones = new ACC_rdPerfil_dAcciones()
                        {
                            
                            id = 1,
                            idAccion = 1,
                            idPerfil = 1,
                            ACC_dAcciones = new ACC_dAcciones()
                            {
                                id = 1,
                                descripcion = "Administrador"
                            }
                        }
                        }
                    }
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
                    fhBaja = null
                }
            };
        }

        [TestMethod]
        public void GetUsuarioTest()
        {
            var result = _servicio.GetUsuario();
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterGet, "FakeACC_dUsuariosRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterQuery, "FakeACC_dUsuariosRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterInsert, "FakeACC_dUsuariosRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterUpdate, "FakeACC_dUsuariosRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dUsuariosRepository.AccessCounterDelete, "FakeACC_dUsuariosRepository.AccessCounterDelete");
        }

        [TestMethod]
        public void ValidatePermissionsTest()
        {
            _servicio.ValidatePermissions();
        }

        [TestMethod]
        public void ValidatePermissionsCatchNotFoundTest()
        {
            try
            {
                _FakeUOW_AccesosDB.ACC_dUsuarios = new List<ACC_dUsuarios>();
                _servicio.ValidatePermissions();
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.GetType().Name, "NotFoundException");
            }
        }


        [TestMethod]
        public void ValidatePermissionsCatchNotAllowedTest()
        {
            try
            {
                _FakeUOW_AccesosDB.ACC_dUsuarios.First().ACC_rdUsuarios_dPerfiles_dAcciones = new List<ACC_rdUsuarios_dPerfiles_dAcciones>();
                _servicio.ValidatePermissions();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.GetType().Name, "NotAllowedException");
            }
        }

    }
}