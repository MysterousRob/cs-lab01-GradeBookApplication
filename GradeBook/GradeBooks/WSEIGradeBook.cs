using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class WseiGradeBook : BaseGradeBook
    {
        public WseiGradeBook(string bookTitle, bool weighted) : base(bookTitle, weighted)
        {
            this.Type = GradeBookType.Wsei;
        }

        public override char GetLetterGrade(double avgGrade)
        {
            return avgGrade switch
            {
                >= 90 => '5',
                >= 80 => 'B',
                >= 70 => '4',
                >= 60 => 'C',
                >= 50 => '3',
                _ => '2'
            };
        }
    }
}