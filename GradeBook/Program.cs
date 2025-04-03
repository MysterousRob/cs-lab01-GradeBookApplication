using System;
using GradeBook.UserInterfaces;

namespace GradeBook.UserInterfaces
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("#=======================#");
            Console.WriteLine("# Welcome to GradeBook! #");
            Console.WriteLine("#=======================#");

            StartingUserInterface.CommandLoop();

            Console.WriteLine("Thank you for using GradeBook!");
            Console.WriteLine("Have a nice day!");
            Console.Read();
        }
    }
}