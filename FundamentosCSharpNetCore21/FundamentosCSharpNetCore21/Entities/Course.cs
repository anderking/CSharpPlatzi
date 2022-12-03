using FundamentosCSharpNetCore21.Util;
using System;
using System.Collections.Generic;
using System.Text;
using static FundamentosCSharpNetCore21.Entities.TypeWorkingDay;

namespace FundamentosCSharpNetCore21.Entities
{
    class Course: PropertyBase
    {
        public TypeWorkingDays TypeWorkingDays { get; set; }
        public List<Student> Students { get; set; }
        public List<Subject> Subjects { get; set; }

        public Course(string name, TypeWorkingDays typeWorkingDays)
        {
            Name = name;
            TypeWorkingDays = typeWorkingDays;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, TypeWorkingDays: {TypeWorkingDays}";
        }
    }
}
