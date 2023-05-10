using System;
using System.Collections.Generic;
using System.IO;

namespace JournalProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1- Write");
                Console.WriteLine("2- Display");
                Console.WriteLine("3- Load");
                Console.WriteLine("4- Save as CSV");
                Console.WriteLine("5- Save to database");
                Console.WriteLine("6- Quit");

                Console.Write("\nEnter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        journal.WriteEntry();
                        break;
                    case 2:
                        journal.DisplayEntries();
                        break;
                    case 3:
                        journal.LoadEntries();
                        break;
                    case 4:
                        journal.SaveToCSV();
                        break;
                    case 5:
                        journal.SaveToDatabase();
                        break;
                    case 6:
                        Console.WriteLine("\nGoodbye!");
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice!");
                        break;
                }
            }
        }
    }
}
