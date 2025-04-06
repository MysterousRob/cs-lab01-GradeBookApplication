using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class ESNUGradeBook : BaseGradeBook
    {
        public ESNUGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.ESNU;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (averageGrade >= 90)
                return 'E';
            if (averageGrade >= 70)
                return 'S';
            if (averageGrade >= 50)
                return 'N';
            else
                return 'U';
        }
    }
}