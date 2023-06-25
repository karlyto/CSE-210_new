using System;

class Program
{
    static GoalManager goalManager = new GoalManager();

    static void Main()
    {
        bool exitProgram = false;

        while (!exitProgram)
        {
            DisplayMenu();
            int choice = GetUserChoice();

            switch (choice)
            {
                case 1:
                    CreateNewGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    exitProgram = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu Option");
        Console.WriteLine("============");
        Console.WriteLine("1. Create new goal");
        Console.WriteLine("2. List goals");
        Console.WriteLine("3. Save goals");
        Console.WriteLine("4. Load goals");
        Console.WriteLine("5. Record event");
        Console.WriteLine("6. Exit");
    }

    static int GetUserChoice()
    {
        Console.Write("Select a choice from the menu: ");
        string input = Console.ReadLine();
        int choice;

        while (!int.TryParse(input, out choice))
        {
            Console.WriteLine("Invalid choice. Please enter a valid number.");
            Console.Write("Enter your choice: ");
            input = Console.ReadLine();
        }

        return choice;
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("Creating a new goal...");
        Console.Write("What is the name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Write short description of the goal: ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal: ");
        int points = GetPositiveIntegerInput();
        Console.Write("How many times this goal needs to be accomplished for a bonus: ");
        int requiredCount = GetPositiveIntegerInput();
        Console.Write("What is the bonus for accomplishing it that many times: ");
        int bonusPoints = GetPositiveIntegerInput();

        goalManager.CreateGoal(name, description, points, requiredCount, bonusPoints);
        Console.WriteLine("Goal created successfully!");
    }

    static void ListGoals()
    {
        Console.WriteLine("Listing goals...");
        goalManager.DisplayGoals();
    }

    static void SaveGoals()
    {
        Console.Write("What is the filename to save the goals: ");
        string filename = Console.ReadLine();
        goalManager.SaveGoals(filename);
        Console.WriteLine("Goals saved successfully!");
    }

    static void LoadGoals()
    {
        Console.Write("What is the filename to load the goals: ");
        string filename = Console.ReadLine();
        goalManager.LoadGoals(filename);
        Console.WriteLine("Goals loaded successfully!");
    }

    static void RecordEvent()
    {
        Console.WriteLine("Recording event...");
        Console.Write("What is the index of the goal to record event: ");
        int index = GetPositiveIntegerInput();

        if (goalManager.IsValidGoalIndex(index))
        {
            goalManager.RecordEvent(index);
            Console.WriteLine("Event recorded successfully!");
        }
        else
        {
            Console.WriteLine("Invalid goal index. Please try again.");
        }
    }

    static int GetPositiveIntegerInput()
    {
        int value;
        string input = Console.ReadLine();

        while (!int.TryParse(input, out value) || value <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
            input = Console.ReadLine();
        }

        return value;
    }
}
