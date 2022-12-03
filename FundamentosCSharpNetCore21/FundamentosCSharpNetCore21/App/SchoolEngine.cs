using FundamentosCSharpNetCore21.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                              select new Student { Name = $"{n1} {n2} {a1}" ,Evaluations = new List<Evaluation>() };

            return studentList.OrderBy((al) => al.Id).Take(cant).ToList();
        }

        private void LoadSubject()
        {
            foreach (var course in School.CourseList)
            {
                var subjectList = new List<Subject>(){
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
            foreach(var course in School.CourseList)
            {
                foreach (var student in course.Students)
                {
                    foreach(var subject in course.Subjects)
                    {
                        Random rnd = new Random(System.Environment.TickCount);
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
    }
}
