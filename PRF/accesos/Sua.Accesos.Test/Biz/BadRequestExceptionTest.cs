using System;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Sua.Accesos.Test.Biz
{
    [TestClass]
    public class BadRequestExceptionTest
    {

        [TestInitialize]
        public void Init()
        {
        }

        
        [TestMethod]
        public void GetContextTest()
        {
            var result = new BadRequestException();
            Assert.AreEqual(result.GetType().Name, "BadRequestException");

            var result2 = new BadRequestException("mensaje");
            Assert.AreEqual(result2.GetType().Name, "BadRequestException");

            var result3 = new BadRequestException("mensaje", new Exception());
            Assert.AreEqual(result3.GetType().Name, "BadRequestException");
        }

    }
}