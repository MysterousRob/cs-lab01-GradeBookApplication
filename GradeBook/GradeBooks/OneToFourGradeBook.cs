using System;
using GradeBook.Enums;
using GradeBook.UserInterfaces;

namespace GradeBook.GradeBooks
{
    public class OneToFourGradeBook : BaseGradeBook
    {
        public OneToFourGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.OneToFour;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (averageGrade >= 90)
                return '4';
            if (averageGrade >= 75)
                return '3';
            if (averageGrade >= 60)
                return '2';
            else
                return '1';
        }
    } 