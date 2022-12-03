using FundamentosCSharpNetCore21.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharpNetCore21.Entities
{
    class Subject
    {
        public string Id { get; private set; }
        public string Name { get; set; }

        public Subject()
        {
            Id = GenerateGuid.GenerateId();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
