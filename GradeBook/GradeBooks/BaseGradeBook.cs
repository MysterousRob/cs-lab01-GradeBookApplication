using System;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public abstract class BaseGradeBook
    {
        public string Name { get; set; }
        public bool IsWeighted { get; set; }
        public GradeBookType Type { get; set; }
        public List<Student> Students { get; set; }

        public BaseGradeBook(string name, bool isWeighted)
        {
            Name = name;
            IsWeighted = isWeighted;
            Students = new List<Student>();
        }

        public abstract char GetLetterGrade(double averageGrade);

        public virtual void CalculateStatistics()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("No students available to calculate statistics.");
                return;
            }
            Console.WriteLine($"Overall Average Grade: {Students.Average(s => s.AverageGrade)}");
        }

        public virtual void CalculateStudentStatistics(string name)
        {
            var student = Students.FirstOrDefault(s => s.Name == name);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }
            Console.WriteLine($"Student: {student.Name}, Average Grade: {student.AverageGrade}");
        }
    }
}
