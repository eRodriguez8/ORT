using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz;
using Sua.Accesos.Test.Biz.Fakes;
using Corp.Cencosud.Supermercados.Sua_Accesos.Dal;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;

namespace Sua.Accesos.Test.Biz
{
    [TestClass]
    public class NotFoundExceptionTest
    {

        [TestInitialize]
        public void Init()
        {
        }

        
        [TestMethod]
        public void GetContextTest()
        {
            var result = new NotFoundException();
            Assert.AreEqual(result.GetType().Name, "NotFoundException");

            var result2 = new NotFoundException("mensaje");
            Assert.AreEqual(result2.GetType().Name, "NotFoundException");

            var result3 = new NotFoundException("mensaje", new Exception());
            Assert.AreEqual(result3.GetType().Name, "NotFoundException");
        }

    }
}