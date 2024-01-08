﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_ClassLibrary
{
    public class ResponseAPI<T>
    {
        public bool EsCorrecto { get; set; }

        public string? Mensaje { get; set; }

        public T? Valor { get; set; }
    }
}
