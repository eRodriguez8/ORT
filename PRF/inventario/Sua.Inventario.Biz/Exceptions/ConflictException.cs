using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Exceptions
{
    public class ConflictException : ApplicationException
    {
        public ConflictException()
        {
        }

        public ConflictException(string message) : base(message)
            {
        }

        public ConflictException(string message, Exception innerException) : base(message, innerException)
            {
        }
    }
}