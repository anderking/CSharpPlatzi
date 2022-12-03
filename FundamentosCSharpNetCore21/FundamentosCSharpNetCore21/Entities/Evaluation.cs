using FundamentosCSharpNetCore21.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharpNetCore21.Entities
{
    class Evaluation
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public float Note { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public Evaluation()
        {
            Id = GenerateGuid.GenerateId();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Note: {Note}";
        }


    }
}
