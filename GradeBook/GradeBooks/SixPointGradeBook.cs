using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class SixPointGradeBook : BaseGradeBook
    {
        public SixPointGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            this.Type = GradeBookType.OneToFour;
        }

        public override char GetLetterGrade(double avgGrade)
        {
            return avgGrade switch
            {
                >= 90 => '4',
                >= 75 => '3',
                >= 60 => '2',
                _ => '1'
            };
        }
    }
}