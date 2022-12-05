using FundamentosCSharpNetCore21.Entities;
using FundamentosCSharpNetCore21.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FundamentosCSharpNetCore21.Entities.KeyDictionary;

namespace FundamentosCSharpNetCore21.App
{
      class SchoolEngine
      {
            public School School { get; set; }

            public School Initializer()
            {
                  School = new School("ucla", 2022, TypeSchool.TypeSchools.University, "Venezuela", "Barquisimeto");
                  LoadCourseArray();
                  LoadCourseList();
                  LoadStudent();
                  LoadSubject();
                  LoadEvaluations();
                  return School;
            }

            private void LoadCourseArray()
            {
                  Course course1 = new Course("Nodejs", TypeWorkingDay.TypeWorkingDays.Morning);
                  Course course2 = new Course("Nestjs", TypeWorkingDay.TypeWorkingDays.Affternoon);
                  Course course3 = new Course("React", TypeWorkingDay.TypeWorkingDays.Nigth);
                  Course course4 = new Course("Angular", TypeWorkingDay.TypeWorkingDays.Morning);
                  Course[] courses = new Course[] { course1, course2, course3, course4 };
                  School.Courses = courses;
            }

            #region Load Data

            private void LoadCourseList()
            {
                  List<Course> courseList = new List<Course>()
            {
                new Course(".NetCore", TypeWorkingDay.TypeWorkingDays.Morning),
                new Course(".Net Framework", TypeWorkingDay.TypeWorkingDays.Affternoon),
                new Course("Asp.Net", TypeWorkingDay.TypeWorkingDays.Affternoon),
                new Course("C#", TypeWorkingDay.TypeWorkingDays.Morning),
            };
                  School.CourseList = courseList;
                  Course course1 = new Course("Nodejs", TypeWorkingDay.TypeWorkingDays.Morning);
                  Course course2 = new Course("Nestjs", TypeWorkingDay.TypeWorkingDays.Affternoon);
                  Course course3 = new Course("React", TypeWorkingDay.TypeWorkingDays.Nigth);
                  Course course4 = new Course("Angular", TypeWorkingDay.TypeWorkingDays.Morning);
                  Course[] courses = new Course[] { course1, course2, course3, course4 };
                  School.CourseList.AddRange(courses.ToList());
                  School.CourseList.Remove(course1);
                  School.CourseList.RemoveAll((Course course) => (course.TypeWorkingDays == TypeWorkingDay.TypeWorkingDays.Affternoon));
            }

            private void LoadStudent()
            {
                  Random rnd = new Random();
                  foreach (var course in School.CourseList)
                  {
                        int cantRandom = rnd.Next(5, 10);
                        course.Students = GenerateStudentRandom(cantRandom);
                  }
            }

            private List<Student> GenerateStudentRandom(int cant)
            {
                  string[] firstName = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
                  string[] firstName2 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
                  string[] lastName = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

                  var studentList = from n1 in firstName
                                    from n2 in firstName2
                                    from a1 in lastName
                                    select new Student { Name = $"{n1} {n2} {a1}", Evaluations = new List<Evaluation>() };

                  return studentList.OrderBy((al) => al.Id).Take(cant).ToList();
            }

            private void LoadSubject()
            {
                  foreach (var course in School.CourseList)
                  {
                        var subjectList = new List<Subject>()
                        {
                            new Subject{Name = "POO"} ,
                            new Subject{Name = "C#"},
                            new Subject{Name = "Frontend"},
                            new Subject{Name = "Backend"}
                        };
                        course.Subjects = subjectList;
                  }
            }

            public void LoadEvaluations()
            {
                  Random rnd = new Random();
                  foreach (var course in School.CourseList)
                  {
                        foreach (var student in course.Students)
                        {
                              foreach (var subject in course.Subjects)
                              {
                                    for (var i = 0; i < 5; i++)
                                    {
                                          Evaluation evaluation = new Evaluation
                                          {
                                                Name = $"{i}. {subject.Name}",
                                                Subject = subject,
                                                Student = student,
                                                Note = (float)(5 * rnd.NextDouble())
                                          };
                                          student.Evaluations.Add(evaluation);
                                    }
                              }
                        }
                  }
            }
            #endregion

            #region Dictionary
            public Dictionary<KeysDictionary, IEnumerable<PropertyBase>> GetDictionaryBase()
            {
                  var dictionary = new Dictionary<KeysDictionary, IEnumerable<PropertyBase>>();

                  dictionary.Add(KeysDictionary.School, new[] { School });
                  dictionary.Add(KeysDictionary.Course, School.CourseList.Cast<PropertyBase>());

                  var listatmp = new List<Evaluation>();
                  var listatmpas = new List<Subject>();
                  var listatmpal = new List<Student>();

                  foreach (var cur in School.CourseList)
                  {
                        listatmpas.AddRange(cur.Subjects);
                        listatmpal.AddRange(cur.Students);

                        foreach (var alum in cur.Students)
                        {
                              listatmp.AddRange(alum.Evaluations);
                        }
                  }
                  dictionary.Add(KeysDictionary.Evaluation,
                                          listatmp.Cast<PropertyBase>());
                  dictionary.Add(KeysDictionary.Subject,
                                          listatmpas.Cast<PropertyBase>());
                  dictionary.Add(KeysDictionary.Student,
                                          listatmpal.Cast<PropertyBase>());
                  return dictionary;
            }

            public void PrinterDictionary(Dictionary<KeysDictionary, IEnumerable<PropertyBase>> dic, bool imprEval = false)
            {
                  foreach (var objdic in dic)
                  {
                        Printer.WriteTitle(objdic.Key.ToString());

                        foreach (var val in objdic.Value)
                        {
                              switch (objdic.Key)
                              {
                                    case KeysDictionary.Evaluation:
                                          if (imprEval)
                                                Console.WriteLine(val);
                                          break;
                                    case KeysDictionary.School:
                                          Console.WriteLine("Escuela: " + val);
                                          break;
                                    case KeysDictionary.Student:
                                          Console.WriteLine("Alumno: " + val.Name);
                                          break;
                                    case KeysDictionary.Course:
                                          var curtmp = val as Course;
                                          if (curtmp != null)
                                          {
                                                int count = curtmp.Students.Count;
                                                Console.WriteLine("Curso: " + val.Name + " Cantidad Alumnos: " + count);
                                          }
                                          break;
                                    default:
                                          Console.WriteLine(val);
                                          break;
                              }
                        }
                  }
            }
            #endregion

            #region OverLoad Method
            public IReadOnlyList<PropertyBase> GetPropertyBases()
            {
                  int dummy = 0;
                  return GetPropertyBases(out dummy, out dummy, out dummy, out dummy);
            }

            public IReadOnlyList<PropertyBase> GetPropertyBases(out int cantEvaluations, out int cantCourses, out int cantSubjects, out int cantStudents, bool hasEvaluations = true, bool hasStudents = true, bool hasSubjects = true, bool hasCorses = true
            )
            {
                  cantStudents = cantSubjects = cantEvaluations = 0;

                  List<PropertyBase> result = new List<PropertyBase>();
                  result.Add(School);

                  if (hasCorses)
                        result.AddRange(School.CourseList);

                  cantCourses = School.CourseList.Count;
                  foreach (var curso in School.CourseList)
                  {
                        cantSubjects += curso.Subjects.Count;
                        cantStudents += curso.Students.Count;

                        if (hasSubjects)
                              result.AddRange(curso.Subjects);

                        if (hasStudents)
                              result.AddRange(curso.Students);

                        if (hasEvaluations)
                        {
                              foreach (var alumno in curso.Students)
                              {

                                    result.AddRange(alumno.Evaluations);
                                    cantEvaluations += alumno.Evaluations.Count;
                              }
                        }
                  }

                  return result.AsReadOnly();
            }
            #endregion
      }
}
