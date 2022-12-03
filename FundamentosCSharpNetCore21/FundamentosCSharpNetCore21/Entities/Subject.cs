using FundamentosCSharpNetCore21.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharpNetCore21.Entities
{
    class Subject: PropertyBase
    {
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
