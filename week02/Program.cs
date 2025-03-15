using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        bool running = true;
        while (running)
        {
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
                    string prompt = promptGenerator.GetRandomPrompt();
                    
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    
                    Entry entry = new Entry();
                    entry.SetDate(DateTime.Now.ToShortDateString());
                    entry.SetPromptText(prompt);
                    entry.SetEntryText(response);
                    
                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added successfully!");
                    break;
                
                case "2":
                    journal.DisplayAll();
                    break;
                
                case "3":
                    Console.Write("\nEnter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                
                case "4":
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
