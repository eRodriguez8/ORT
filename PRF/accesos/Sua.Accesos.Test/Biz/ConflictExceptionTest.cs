using System;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Sua.Accesos.Test.Biz
{
    [TestClass]
    public class ConflictExceptionTest
    {

        [TestInitialize]
        public void Init()
        {
        }

        
        [TestMethod]
        public void GetContextTest()
        {
            var result = new ConflictException();
            Assert.AreEqual(result.GetType().Name, "ConflictException");

            var result2 = new ConflictException("mensaje");
            Assert.AreEqual(result2.GetType().Name, "ConflictException");

            var result3 = new ConflictException("mensaje", new Exception());
            Assert.AreEqual(result3.GetType().Name, "ConflictException");
        }

    }
}