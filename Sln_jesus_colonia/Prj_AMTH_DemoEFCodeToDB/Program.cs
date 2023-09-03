using Prj_AMTH_DemoEFCodeToDB.DataContext;
using Prj_AMTH_DemoEFCodeToDB.Models;
using System;
using System.Linq;

namespace Prj_AMTH_DemoEFCodeToDB
{
    class Program
    {
        public static SchoolDbContext context = new SchoolDbContext();
        static void Main(String[] args)
        {
            LimpiarModelos();
            CrearCursoConEstudiantes();
            MostrarModelosPorPantalla();
        }
        private static void MostrarModelosPorPantalla()
        {
            foreach (var course in context.Courses)
            {
                Console.WriteLine("- Course: " + course.Name + " Section: " + course.Section);
                foreach (var student in course.Students)
                {
                    Console.WriteLine("\t- Student: " + student.Name);
                }
            }
        }
        private static void LimpiarModelos()
        {
            var allStudents = from c in context.Students select c;
            context.Students.RemoveRange(allStudents);
            context.SaveChanges();
            var allCourses = from c in context.Courses select c;
            context.Courses.RemoveRange(allCourses);
            context.SaveChanges();
        }
        private static void CrearCursoConEstudiantes()
        {
            for (int i = 0; i < 5; i++)
            {            
                Course course1 = new Course { Name = "Curso" + i, Section = "ING" };
                Course courseInserted = context.Courses.Add(course1).Entity;
                context.SaveChanges();
                for (int j = 0; j < 10; j++)
                {
                    Student student1 = new Student { Name = "Estudiante " + j, Course = courseInserted };
                    context.Students.Add(student1);
                    context.SaveChanges();
                }
            }
        }
    }
}