using System;
using System.Threading;

public class ListingActivity : MindfulnessActivity
{
    private string[] prompts = new string[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }
    protected override void PerformActivity()
    {
        Random random = new Random();
        int promptIndex = random.Next(prompts.Length);
        string prompt = prompts[promptIndex];

        Console.WriteLine("{0}", prompt);
        Console.WriteLine();

        Console.WriteLine("How many seconds you want to have to list your answer(s)?: ");
        int duration = ReadDuration();

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int itemCounter = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(">> ", itemCounter + 1);
            string item = Console.ReadLine();
            itemCounter++;
        }

        Console.WriteLine();
        Console.WriteLine("You listed {0} items.", itemCounter);
        Console.WriteLine();
    }
    private int ReadDuration()
    {
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.WriteLine("Invalid duration. Please enter a positive number.");
        }
        return duration;
    }
}
