using FundamentosCSharpNetCore21.Util;
using System;
using System.Collections.Generic;
using System.Text;
using static FundamentosCSharpNetCore21.Entities.TypeWorkingDay;

namespace FundamentosCSharpNetCore21.Entities
{
    class Course
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public TypeWorkingDays TypeWorkingDays { get; set; }
        public List<Student> Students { get; set; }
        public List<Subject> Subjects { get; set; }

        public Course(string name, TypeWorkingDays typeWorkingDays)
        {
            Id = GenerateGuid.GenerateId();
            Name = name;
            TypeWorkingDays = typeWorkingDays;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, TypeWorkingDays: {TypeWorkingDays}";
        }
    }
}
