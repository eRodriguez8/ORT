﻿using Corp.Cencosud.Supermercados.Sua.Inventario.Entities;
using System;
using System.Runtime.Serialization;

namespace Corp.Cencosud.Supermercados.Sua.Inventario.Biz.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}