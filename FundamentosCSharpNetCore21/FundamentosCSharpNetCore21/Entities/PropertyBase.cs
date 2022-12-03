using System;
using System.Collections.Generic;
using System.Text;
using FundamentosCSharpNetCore21.Util;

namespace FundamentosCSharpNetCore21.Entities
{
    public class PropertyBase
    {
        public string Id { get; private set; }

        public string Name { get; set; }

        public PropertyBase()
        {
            Id = GenerateGuid.GenerateId();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
