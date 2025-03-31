using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");

            var threshold = (int)Math.Ceiling(Students.Count * 0.2); // 20% of students
            var sortedGrades = Students
                .Select(s => s.AverageGrade)
                .OrderByDescending(g => g)
                .ToList();

            if (sortedGrades.IndexOf(averageGrade) < threshold)
                return 'A';
            if (sortedGrades.IndexOf(averageGrade) < threshold * 2)
                return 'B';
            if (sortedGrades.IndexOf(averageGrade) < threshold * 3)
                return 'C';
            if (sortedGrades.IndexOf(averageGrade) < threshold * 4)
                return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}

