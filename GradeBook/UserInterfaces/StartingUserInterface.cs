using GradeBook.GradeBooks;
using System;

namespace GradeBook.UserInterfaces
{
    public static class StartingUserInterface
    {
        public static bool IsRunning = true;

        public static void StartCommandLoop()
        {
            while (IsRunning)
            {
                Console.WriteLine("\n>> What would you like to do?");
                var input = Console.ReadLine()?.ToLower();
                ProcessCommand(input);
            }
        }

        public static void ProcessCommand(string input)
        {
            if (input.StartsWith("create"))
                CreateCommand(input);
            else if (input.StartsWith("load"))
                LoadCommand(input);
            else if (input == "help")
                HelpCommand();
            else if (input == "quit")
                IsRunning = false;
            else
                Console.WriteLine($"{input} was not recognized, please try again.");
        }

        public static void CreateCommand(string input)
        {
            var arguments = input.Split(' ');
            if (arguments.Length != 4)
            {
                Console.WriteLine("Command not valid, Create requires a name, type of gradebook, if it's weighted (true / false).");
                return;
            }

            var name = arguments[1];
            var type = arguments[2].ToLower();
            if (!bool.TryParse(arguments[3], out bool isWeighted))
            {
                Console.WriteLine("Invalid value for 'Weighted'. Use 'true' or 'false'.");
                return;
            }

            BaseGradeBook gradeBook = type switch
            {
                "standard" => new StandardGradeBook(name, isWeighted),
                "ranked" => new RankedGradeBook(name, isWeighted),
                "wsei" => new WseiGradeBook(name, isWeighted),
                "esnu" => new ESNUGradeBook(name, isWeighted),
                "one2four" => new OneToFourGradeBook(name, isWeighted),
                "sixpoint" => new SixPointGradeBook(name, isWeighted),
                _ => null
            };

            if (gradeBook == null)
            {
                Console.WriteLine($"{type} is not a supported gradebook type.");
                return;
            }

            Console.WriteLine($"Created gradebook {name}.");
            GradeBookUserInterface.CommandLoop(gradeBook);
        }

        public static void LoadCommand(string input)
        {
            var parts = input.Split(' ');
            if (parts.Length != 2)
            {
                Console.WriteLine("Invalid command. Usage: Load 'Name'.");
                return;
            }

            var name = parts[1];
            var gradeBook = BaseGradeBook.Load(name);

            if (gradeBook == null)
                return;

            GradeBookUserInterface.CommandLoop(gradeBook);
        }

        public static void HelpCommand()
        {
            Console.WriteLine("\nAvailable commands:");
            Console.WriteLine("Create 'Name' 'Type' 'Weighted' - Creates a new gradebook where 'Name' is the name of the gradebook, 'Type' is what type of grading it should use, and 'Weighted' is whether or not grades should be weighted (true or false).");
            Console.WriteLine("Load 'Name' - Loads an existing gradebook.");
            Console.WriteLine("Help - Displays available commands.");
            Console.WriteLine("Quit - Exits the application.");
        }
    }
}