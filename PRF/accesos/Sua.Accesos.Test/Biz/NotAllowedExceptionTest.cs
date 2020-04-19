using System;
using Corp.Cencosud.Supermercados.Sua.Accesos.Biz.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Sua.Accesos.Test.Biz
{
    [TestClass]
    public class NotAllowedExceptionTest
    {

        [TestInitialize]
        public void Init()
        {
        }

        
        [TestMethod]
        public void GetContextTest()
        {
            var result = new NotAllowedException();
            Assert.AreEqual(result.GetType().Name, "NotAllowedException");

            var result2 = new NotAllowedException("mensaje");
            Assert.AreEqual(result2.GetType().Name, "NotAllowedException");

            var result3 = new NotAllowedException("mensaje", new Exception());
            Assert.AreEqual(result3.GetType().Name, "NotAllowedException");
        }

    }
}