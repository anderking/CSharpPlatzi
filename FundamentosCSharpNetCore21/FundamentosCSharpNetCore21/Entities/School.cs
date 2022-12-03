using System;
using System.Collections.Generic;
using System.Text;
using static FundamentosCSharpNetCore21.Entities.TypeSchool;

namespace FundamentosCSharpNetCore21.Entities
{
    class School: PropertyBase
    {
        public int YearCreated { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public TypeSchools TypeSchools { get; set; }
        public Course[] Courses { get; set; }
        public List<Course> CourseList { get; set; }

        public School(string name, int year, TypeSchools typeSchools, string country = "", string city = "")
        {
            Name = name;
            YearCreated = year;
            Country = country;
            City = city;
            TypeSchools = typeSchools;
        }

        public override string ToString()
        {
            return$"Id: {Id}, Name: {Name.ToUpper()}, YearCreated: {YearCreated}, Country: {Country}, City: {City}, TypeSchools: {TypeSchools}";
        }

    }
}
