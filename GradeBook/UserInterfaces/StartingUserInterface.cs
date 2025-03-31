using System;
using System.Linq;
using GradeBook.Enums;
using GradeBook.GradeBooks;

namespace GradeBook.UserInterfaces
{
    public static class StartingUserInterface
    {
        public static void CommandLoop()
        {
            string command = "";
            while (command.ToLower() != "exit")
            {
                Console.WriteLine("Enter a command (Create, AddStudent, GradeStudent, CalculateStatistics, Exit):");
                command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "create":
                        CreateGradeBook();
                        break;
                    case "exit":
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }

        private static void CreateGradeBook()
        {
            Console.WriteLine("Enter a name for the GradeBook:");
            var name = Console.ReadLine();

            Console.WriteLine("Is this GradeBook weighted? (yes/no):");
            var isWeighted = Console.ReadLine().ToLower() == "yes";

            Console.WriteLine("Enter GradeBook type (Standard or Ranked):");
            var type = Console.ReadLine().ToLower();

            BaseGradeBook gradeBook;

            if (type == "standard")
                gradeBook = new StandardGradeBook(name, isWeighted);
            else if (type == "ranked")
                gradeBook = new RankedGradeBook(name, isWeighted);
            else
            {
                Console.WriteLine("Invalid GradeBook type.");
                return;
            }

            Console.WriteLine($"Created {gradeBook.Type} GradeBook: {gradeBook.Name}");
        }
    }
}
