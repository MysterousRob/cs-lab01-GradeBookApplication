using System;
using GradeBook.StartingUserinterface;
//did proj to best of my abilities and didnt get 19 of them to work but 5 are passing if you couould give me an extra 2 to 4 days to complete it would be great
namespace GradeBook
{
     class Program
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