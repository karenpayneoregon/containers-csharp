using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StudentsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new()
            {
                new () { Name = "John", SurName = "Doe" },
                new () { Name = "Alex", SurName = "Atkinson Lloyd" },
                new () { Name = "Lucy", SurName = "Novak" }
            };

            var studentsOrdered = students.OrderBy(student => student.SurName);
            foreach (var student in studentsOrdered)
            {
                Debug.WriteLine(student);
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public override string ToString() => $"{Name} {SurName}";
    }
}
