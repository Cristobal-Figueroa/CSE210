using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Exercise Tracking Program");
        Console.WriteLine("------------------------");

        List<Activity> activities = new List<Activity>();

        DateTime today = DateTime.Now;
        
        Running running = new Running(today, 30, 3.0);
        activities.Add(running);
        
        Cycling cycling = new Cycling(today, 45, 15.0);
        activities.Add(cycling);
        
        Swimming swimming = new Swimming(today, 60, 20);
        activities.Add(swimming);

        Console.WriteLine("\nActivity Summaries:");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}