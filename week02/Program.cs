using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a new journal
        Journal journal = new Journal();
        
        // Create a list of prompts
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I most grateful for today?",
            "What did I learn today that I didn't know before?"
        };

        bool running = true;
        while (running)
        {
            // Display menu
            Console.WriteLine("\n===== Journal Program =====");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    // Get a random prompt
                    Random random = new Random();
                    int index = random.Next(prompts.Count);
                    string prompt = prompts[index];
                    
                    // Display the prompt and get response
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    
                    // Create a new entry and add it to the journal
                    Entry entry = new Entry
                    {
                        Date = DateTime.Now.ToShortDateString(),
                        Prompt = prompt,
                        Response = response
                    };
                    
                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added successfully!");
                    break;
                
                case "2":
                    // Display all entries
                    journal.DisplayAll();
                    break;
                
                case "3":
                    // Save journal to file
                    Console.Write("\nEnter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                
                case "4":
                    // Load journal from file
                    Console.Write("\nEnter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                
                case "5":
                    running = false;
                    break;
                
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
