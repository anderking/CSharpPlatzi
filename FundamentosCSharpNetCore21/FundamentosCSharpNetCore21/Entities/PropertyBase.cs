using System;
using System.Collections.Generic;
using System.Text;
using FundamentosCSharpNetCore21.Util;

namespace FundamentosCSharpNetCore21.Entities
{
    class PropertyBase
    {
        public string Id { get; private set; }

        public string Name { get; set; }

        public PropertyBase()
        {
            Id = GenerateGuid.GenerateId();
        }
    }
}
