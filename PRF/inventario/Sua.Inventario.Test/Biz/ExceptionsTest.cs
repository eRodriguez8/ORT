using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Exceptions;

namespace Corp.Cencosud.Supermercados.Inventario.Test.Biz
{
    [TestClass]
    public class ExceptionsTest
    {

        [TestInitialize]
        public void Init()
        {
        }

        
        [TestMethod]
        public void GetContextTest()
        {
            var result = new NotFoundException();
            Assert.AreEqual("NotFoundException", result.GetType().Name);

            var result2 = new NotFoundException("mensaje");
            Assert.AreEqual("NotFoundException", result2.GetType().Name);

            var result3 = new NotFoundException("mensaje", new Exception());
            Assert.AreEqual("NotFoundException", result3.GetType().Name);
        }

        [TestMethod]
        public void GetConflictExceptiontTest()
        {
            var result = new ConflictException();
            Assert.AreEqual("ConflictException", result.GetType().Name);

            var result2 = new ConflictException("mensaje");
            Assert.AreEqual("ConflictException", result2.GetType().Name);

            var result3 = new ConflictException("mensaje", new Exception());
            Assert.AreEqual("ConflictException", result3.GetType().Name);
        }

        [TestMethod]
        public void GetNotAllowedExceptiontTest()
        {
            var result = new NotAllowedException();
            Assert.AreEqual("NotAllowedException", result.GetType().Name);

            var result2 = new NotAllowedException("mensaje");
            Assert.AreEqual("NotAllowedException", result2.GetType().Name);

            var result3 = new NotAllowedException("mensaje", new Exception());
            Assert.AreEqual("NotAllowedException", result3.GetType().Name);
        }

        [TestMethod]
        public void GetBadRequestExceptionTest()
        {
            var result = new BadRequestException();
            Assert.AreEqual("BadRequestException", result.GetType().Name);

            var result2 = new BadRequestException("mensaje");
            Assert.AreEqual("BadRequestException", result2.GetType().Name);

            var result3 = new BadRequestException("mensaje", new Exception());
            Assert.AreEqual("BadRequestException", result3.GetType().Name);
        }

    }
}