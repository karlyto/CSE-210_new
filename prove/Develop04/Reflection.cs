using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : MindfulnessActivity
{
    
    private string[] prompts = new string[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you overcame a fear.",
        "Think of a time when you achieved a personal goal."
    };

    private string[] questions = new string[]
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private HashSet<int> askedQuestionIndices = new HashSet<int>();

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void PerformActivity()
    {
        Random random = new Random();
        int promptIndex = random.Next(prompts.Length);
        string prompt = prompts[promptIndex];
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine("__^^__ {0} __^^__ ", prompt);
        Console.WriteLine();
        Console.WriteLine("Press Enter when you have something in mind...");
        Console.ReadLine();
        Console.WriteLine();

        ShuffleQuestions();

        foreach (string question in questions)
        {
            Console.WriteLine(">> {0}", question);
            ShowCountdownSpinner(8);
        }
    }

    private void ShuffleQuestions()
    {
        askedQuestionIndices.Clear();
    }

    private void ShowCountdownSpinner(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write("\r{0} ", new string('.', i % 4 + 1));
            Thread.Sleep(1000);
        }
        Console.Write("\r          \r");
    }
}
