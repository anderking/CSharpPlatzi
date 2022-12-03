using FundamentosCSharpNetCore21.App;
using FundamentosCSharpNetCore21.Entities;
using FundamentosCSharpNetCore21.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FundamentosCSharpNetCore21
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolEngine schoolEngine = new SchoolEngine();
            School school = schoolEngine.Initializer();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            Console.WriteLine(school);
            Console.WriteLine("\n");
            // Printer.Beep(10000, cant: 10);
            // PrintCourseSchool(school);
            PrintCourseListSchool(school);
            Console.ReadLine();
        }

        private static void PrintCourseSchool(School school)
        {
            Printer.WriteTitle("Courses School Array");
            Console.WriteLine("\n");
            if (school?.Courses != null && school?.Courses.Length > 0)
            {
                foreach(var course in school.Courses)
                {
                    Console.WriteLine(course);
                }
            }
        }

        private static void PrintCourseListSchool(School school)
        {
            Printer.WriteTitle("Courses School List");
            Console.WriteLine("\n");
            if ((bool)(school?.CourseList.Any()))
            {
                foreach (var course in school.CourseList)
                {
                    Console.WriteLine(course);
                    Console.WriteLine("\n");
                    PrintStudentListSchool(course);
                }
            }
        }

        private static void PrintStudentListSchool(Course course)
        {
            Printer.WriteTitle("Student List");
            Console.WriteLine("\n");
            foreach(var student in course.Students)
            {
                Console.WriteLine("\n");
                Console.WriteLine("     " + student);
                Console.WriteLine("\n");
                PrintStudentEvaluationsListSchool(student.Evaluations);
            }
        }

        private static void PrintStudentEvaluationsListSchool(List<Evaluation> evaluations)
        {
            Printer.WriteTitle("Evaluations List");
            Console.WriteLine("\n");
            foreach (var evaluation in evaluations)
            {
                Console.WriteLine("         " + evaluation);
            }
        }

        private static void PrintWhileCoures(Course[] courses)
        {
            int i = 0;
            while(i < courses.Length)
            {
                Course course = courses[i];
                i++;
                Console.WriteLine(course);
            }
        }

        private static void PrintDoWhileCoures(Course[] courses)
        {
            int i = 0;
            do
            {
                Course course = courses[i];
                i++;
                Console.WriteLine(course);
            }
            while (i < courses.Length);
        }

        private static void PrintForCourses(Course[] courses)
        {
            for(var i = 0; i < courses.Length; i++)
            {
                Course course = courses[i];
                Console.WriteLine(course);
            }
        }

        private static void PrintForeachCourses(Course[] courses)
        {
            foreach(var course in courses)
            {
                Console.WriteLine(course);
            }
        }
    }
}
