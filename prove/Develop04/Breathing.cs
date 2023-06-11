using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }
    protected override void PerformActivity()
    {
        int breaths = duration / 6;
        for (int i = 1; i <= breaths; i++)
        {
            Console.WriteLine("Breathe in...");
            Countdown(3);
            Console.WriteLine("Hold your breath...");
            Countdown(3, true); // Display a different animation during breath hold
            Console.WriteLine("Now breathe out...");
            Countdown(3);
            Console.WriteLine();
        }
    }
    private void Countdown(int seconds, bool animate = false)
    {
        for (int i = seconds; i > 0; i--)
        {
            if (animate)
            {
                AnimateCountdown(i);
            }
            else
            {
                Console.Write("\r{0} ", i);
            }

            Thread.Sleep(1000);
        }

        Console.Write("\r          \r");
    }
    private void AnimateCountdown(int seconds)
    {
        string animation = "";
        for (int i = 0; i < seconds; i++)
        {
            animation += ".";
        }

        Console.Write("\r{0}  ", animation);
    }
}
