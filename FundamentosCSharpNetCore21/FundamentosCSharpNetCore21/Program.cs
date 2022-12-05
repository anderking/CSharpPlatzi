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

                  Printer.WriteTitle("ARRAYS");
                  PrintCourseSchool(school);

                  Printer.WriteTitle("LISTAS");
                  PrintCourseListSchool(school);

                  Printer.WriteTitle("POLIMORFISMOS");

                  Student student = new Student { Name = "Anderson Diaz" };
                  Console.WriteLine(student);

                  // El polimorfimos me permite trata un objeto hijo como un objeto padre pero no al reves a menos que se haga un conversion implicita
                  PropertyBase studentFather = student;
                  Console.WriteLine(studentFather);
                  student = (Student)studentFather; // Conversion implicita
                  Console.WriteLine(student);

                  PropertyBase propertyBase = new PropertyBase { Name = "Anderson Diaz" };
                  // PropertyBase propertyBase = student;
                  Console.WriteLine(propertyBase);

                  if (propertyBase is Student)
                  {
                        student = (Student)propertyBase;
                  }

                  student = propertyBase as Student;

                  Console.WriteLine(student);

                  Printer.WriteTitle("SOBRE CARGA ME METODOS");

                  var result = schoolEngine.GetPropertyBases();
                  foreach (var item in result)
                  {
                        Console.WriteLine(item);
                  }

                  Printer.WriteTitle("DICCIONARIOS");

                  var resultDictionary = schoolEngine.GetDictionaryBase();

                  schoolEngine.PrinterDictionary(resultDictionary, true);

                  Printer.WriteTitle("LINQ");

                  Reporter reporter = new Reporter(resultDictionary);
                  var evalList = reporter.GetListEvaluations();
                  var listaAsg = reporter.GetListSubject();
                  var listaEvalXAsig = reporter.GetDictionaryEvaluationBySubject();
                  var listaPromXAsig = reporter.GetCoverageBySubject();
                  var listaChallange = reporter.GetChallange(10);

                  Console.ReadLine();
            }

            private static void PrintCourseSchool(School school)
            {
                  Printer.WriteTitle("Courses School Array");
                  Console.WriteLine("\n");
                  if (school?.Courses != null && school?.Courses.Length > 0)
                  {
                        foreach (var course in school.Courses)
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
                  foreach (var student in course.Students)
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
                  while (i < courses.Length)
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
                  for (var i = 0; i < courses.Length; i++)
                  {
                        Course course = courses[i];
                        Console.WriteLine(course);
                  }
            }

            private static void PrintForeachCourses(Course[] courses)
            {
                  foreach (var course in courses)
                  {
                        Console.WriteLine(course);
                  }
            }
      }
}
