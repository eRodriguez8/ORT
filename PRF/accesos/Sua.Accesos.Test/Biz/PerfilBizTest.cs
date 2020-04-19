using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz;
using System.Collections.Generic;
using System.Data.Entity;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using System.Linq;
using Moq;
using Sua.Accesos.Test.Biz.Fakes;
using Corp.Cencosud.Supermercados.Sua.Accesos.Entities;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Interfaces;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;

namespace Sua.Accesos.Test.Biz
{
    [TestClass]
    public class PerfilBizTest
    {
        private PerfilBiz _servicio;
        private FakeUOW_AccesosDB _FakeUOW_AccesosDB;
        private Mock<ISeguridadBiz> _SeguridadBizMock;

        [TestInitialize]
        public void Init()
        {
            _FakeUOW_AccesosDB = new FakeUOW_AccesosDB();
            _FakeUOW_AccesosDB.ACC_dPerfiles = ListaPerfiles();
            _FakeUOW_AccesosDB.ACC_dAcciones = ListaAcciones();
            _FakeUOW_AccesosDB.ACC_rdPerfil_dAcciones = ListaPerfilAcciones();
            _FakeUOW_AccesosDB.ACC_rdUsuarios_dPerfiles_dAcciones = ListaPerfilesxUsuario();
            _SeguridadBizMock = new Mock<ISeguridadBiz>();
            _servicio = new PerfilBiz(_FakeUOW_AccesosDB, _SeguridadBizMock.Object);
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

        private List<ACC_dAcciones>  ListaAcciones()
        {
            return new List<ACC_dAcciones>
            {
                new ACC_dAcciones
                {
                    id = 1,
                    descripcion="Accion",
                    idAplicacion = "ACC",
                    idEstado ="A",
                    ts = new DateTime(),
                    usuario = "EB2122"
                }
            };
        }

        private Perfil PerfilModel()
        {
            return new Perfil()
            {
                descripcion = "perfil 1",
                idEstado = "A",
                id = 1,
                idAplicacion = "ACC",
                ts = new DateTime(),
                usuario = "EB2122",
                idRegion = 1,
                Acciones = new List<Accion>()
                {
                    new Accion {
                        id = 1,
                        descripcion = "Accion",
                        idAplicacion = "ACC",
                        idEstado = "A",
                        ts = new DateTime(),
                        usuario = "EB2122"
                    }
                }
            };
        }

        private List<ACC_dPerfiles> ListaPerfiles()
        { return new List<ACC_dPerfiles>
            {
                new ACC_dPerfiles {
                    
                    idRegion = 1,
                               descripcion = "perfil 1",
                               idEstado = "A",
                               id = 1,
                               idAplicacion = "ACC",
                               ts = new DateTime(),
                               usuario = "EB2122",
                               
                               ACC_rdPerfil_dAcciones = new List<ACC_rdPerfil_dAcciones> {
                                   new ACC_rdPerfil_dAcciones() {
                                   id =1,
                                   idAccion = 1,
                                   idPerfil = 1,
                                   ts = DateTime.Now,
                                   usuario = @"Cencosud\\EA0344"
                                   }
                               }
                               },
                new ACC_dPerfiles { idRegion = 1,
                               descripcion = "perfil 2",
                               idEstado = "A",
                               id = 2,
                               idAplicacion = "ACC",
                               ts = new DateTime(),
                               usuario = "EB2122",
                               ACC_rdPerfil_dAcciones = new List<ACC_rdPerfil_dAcciones> {
                                   new ACC_rdPerfil_dAcciones() {
                                   id =2,
                                   idAccion = 2,
                                   idPerfil = 2,
                                   ts = DateTime.Now,
                                   usuario = @"Cencosud\\EA0344"
                                   }
                               }
                }
             };
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

        [TestMethod]
        public void GetAllxUsuarioTest()
        {
            var result = _servicio.GetAllxUsuarioApp(1, "");

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterGet, "FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterQuery, "FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterInsert, "FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterUpdate, "FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterDelete, "FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterDelete");


            var perfiles = _FakeUOW_AccesosDB.FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.Data.ToList();
            Assert.AreEqual(perfiles.Count(), 2);
            Assert.AreEqual(perfiles[0].idPerfilAccion, 1);
        }
        
        [TestMethod]
        public void GetAllxUsuarioAppTest()
        {
            var result = _servicio.GetAllxUsuarioApp(1,"ACC");

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterGet, "FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterQuery, "FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterInsert, "FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterUpdate, "FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterDelete, "FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.AccessCounterDelete");


            var perfiles = _FakeUOW_AccesosDB.FakeACC_rdUsuarios_dPerfiles_dAccionesRepository.Data.ToList();
            Assert.AreEqual(perfiles.Count(), 2);
            Assert.AreEqual(perfiles[0].idPerfilAccion, 1);
        }

        [TestMethod]
        public void GetTest()
        {
            var result = _servicio.Get(1);

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterGet, "FakeACC_dPerfilesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterQuery, "FakeACC_dPerfilesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterInsert, "FakeACC_dPerfilesRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterUpdate, "FakeACC_dPerfilesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterDelete, "FakeACC_dPerfilesRepository.AccessCounterDelete");


            var perfil = _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.Data.Single(x => x.id == 1);
            Assert.AreEqual(perfil.id, 1);
        }

        [TestMethod]
        public void GetByIdExceptionTest()
        {
            try
            {
                var result = _servicio.Get(8);

            }
            catch(NotFoundException e)
            {
                Assert.AreEqual(e.GetType().Name, "NotFoundException");
            }
        }
        [TestMethod]
        public void UpdateTest() {
            var perfiles = ListaPerfiles().First().ToModel();
            var result = _servicio.Update(perfiles);

            Assert.AreEqual(1, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterGet, "FakeACC_dPerfilesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterQuery, "FakeACC_dPerfilesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterInsert, "FakeACC_dPerfilesRepository.AccessCounterInsert");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterUpdate, "FakeACC_dPerfilesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterDelete, "FakeACC_dPerfilesRepository.AccessCounterDelete");


            var perfil = _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.Data.Single(x => x.id == 1);
            Assert.AreEqual(perfil.id, 1);
        }
        [TestMethod]
        public void CreateTest() {
            var perfiles = PerfilModel();
            perfiles.id = 0;
            var result = _servicio.Create(perfiles);

            Assert.AreEqual(1, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterGet, "FakeACC_dPerfilesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterQuery, "FakeACC_dPerfilesRepository.AccessCounterQuery");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterInsert, "FakeACC_dPerfilesRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterUpdate, "FakeACC_dPerfilesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterDelete, "FakeACC_dPerfilesRepository.AccessCounterDelete");


            var perfil = _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.Data.Single(x => x.id == 1);
            Assert.AreEqual(perfil.id, 1);
        }
        [TestMethod]
        public void DeleteTest()
        {
            var result = _servicio.Delete(1, "Cencosud\\EA0344");

            Assert.AreEqual(1, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterGet, "FakeACC_dPerfilesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterQuery, "FakeACC_dPerfilesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterInsert, "FakeACC_dPerfilesRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterUpdate, "FakeACC_dPerfilesRepository.AccessCounterUpdate");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterDelete, "FakeACC_dPerfilesRepository.AccessCounterDelete");


            var perfil = _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.Data.SingleOrDefault(x => x.id == 1);
            Assert.IsNull(perfil);
        }
        [TestMethod]
        public void GetAllTest()
        {
            var result = _servicio.GetAll();

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterGet, "FakeACC_dPerfilesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterQuery, "FakeACC_dPerfilesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterInsert, "FakeACC_dPerfilesRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterUpdate, "FakeACC_dPerfilesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterDelete, "FakeACC_dPerfilesRepository.AccessCounterDelete");
            Assert.AreEqual(result.Count(), 2);
        }
        [TestMethod]
        public void GetAllEmptyTest()
        {
            _FakeUOW_AccesosDB.ACC_dPerfiles = new List<ACC_dPerfiles>();
            var result = _servicio.GetAll();
            Assert.AreEqual(result.Count(), 0);

        }
        [TestMethod]
        public void GetAllWithParamsTest_OK()
        {
            var result = _servicio.GetAll(1, "ACC");

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterGet, "FakeACC_dPerfilesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterQuery, "FakeACC_dPerfilesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterInsert, "FakeACC_dPerfilesRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterUpdate, "FakeACC_dPerfilesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterDelete, "FakeACC_dPerfilesRepository.AccessCounterDelete");
            Assert.AreNotEqual(0, result.Count);
        }
        [TestMethod]
        public void GetAllWithParamsTest_NotOK()
        {
            var result = _servicio.GetAll(1, "SGT");

            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterSave, "FakeUOW_AccesosDB.AccessCounterSave");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.AccessCounterDispose, "FakeUOW_AccesosDB.AccessCounterDispose");
            Assert.AreEqual(1, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterGet, "FakeACC_dPerfilesRepository.AccessCounterGet");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterQuery, "FakeACC_dPerfilesRepository.AccessCounterQuery");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterInsert, "FakeACC_dPerfilesRepository.AccessCounterInsert");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterUpdate, "FakeACC_dPerfilesRepository.AccessCounterUpdate");
            Assert.AreEqual(0, _FakeUOW_AccesosDB.FakeACC_dPerfilesRepository.AccessCounterDelete, "FakeACC_dPerfilesRepository.AccessCounterDelete");
            Assert.AreEqual(0, result.Count);
        }
    }
}
