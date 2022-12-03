using FundamentosCSharpNetCore21.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharpNetCore21.Entities
{
    class Evaluation: PropertyBase
    {
        public float Note { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Note: {Note}";
        }


    }
}
