using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using System;
using System.Runtime.Serialization;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Exceptions
{
    [Serializable]
    public class NotAllowedException : Exception
    {
        public NotAllowedException()
        {
        }

        public NotAllowedException(string message) : base(message)
        {
        }

        public NotAllowedException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}