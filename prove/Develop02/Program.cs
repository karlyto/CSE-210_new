using System;

namespace DailyJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine(" Please select one of the following choices:");
                Console.WriteLine("1- Write");
                Console.WriteLine("2- Display");
                Console.WriteLine("3- Load");
                Console.WriteLine("4- Save");
                Console.WriteLine("5- Quit");
                Console.Write("What would you like to do?: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        journal.AddEntry();
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        journal.LoadEntries();
                        break;
                    case "4":
                        journal.SaveEntries();
                        break;
                    case "5":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}