using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class ESNUGradingBook : BaseGradeBook
    {
        public ESNUGradingBook(string gradeBookName, bool weighted) : base(gradeBookName, weighted)
        {
            this.Type = GradeBookType.ESNU;
        }

        public override char GetLetterGrade(double avgGrade)
        {
            return avgGrade switch
            {
                >= 90 => 'E',
                >= 70 => 'S',
                >= 50 => 'N',
                _ => 'U'
            };
        }
    }
}