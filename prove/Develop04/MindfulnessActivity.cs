using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    private string name;
    private string description;
    protected int duration;

    public MindfulnessActivity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void Start()
    {
        Console.WriteLine("__^^__ Welcome to the {0} Activity __^^__", name);
        Console.WriteLine();
        Console.WriteLine(description);

        Console.Write(" In this session, how many seconds you likely want to spend? : ");
        duration = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Get ready...");
        Pause(5);
        PerformActivity();
        Console.WriteLine("Great job! You have completed the {0} activity.", name);
        Console.WriteLine("Duration: {0} seconds", duration);
        Pause(5);

    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write("\r{0} ", GetSpinnerAnimation(i));
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected string GetSpinnerAnimation(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        int index = (seconds % 4);
        return spinner[index];
    }

    protected abstract void PerformActivity();
}
