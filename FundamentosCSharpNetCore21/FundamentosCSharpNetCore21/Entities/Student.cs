using FundamentosCSharpNetCore21.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharpNetCore21.Entities
{
    class Student
    {
        public string Id { get; private set; }
        public string FullName { get; set; }
        public List<Evaluation> Evaluations { get; set; }

        public Student()
        {
            Id = GenerateGuid.GenerateId();
        }

        public override string ToString()
        {
            return $"Id: {Id}, FullName: {FullName}";
        }
    }
}
