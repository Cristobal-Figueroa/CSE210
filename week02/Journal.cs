using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nJournal is empty. Add some entries first!");
            return;
        }

        Console.WriteLine("\n===== Journal Entries =====");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        try
        {
            if (!file.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                file += ".txt";
            }
            
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.ToFileString());
                }
            }
            Console.WriteLine($"Journal saved successfully to {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }

    public void LoadFromFile(string file)
    {
        try
        {
            if (!file.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                file += ".txt";
            }
            
            _entries.Clear();
            
            using (StreamReader reader = new StreamReader(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Entry entry = Entry.FromFileString(line);
                        _entries.Add(entry);
                    }
                }
            }
            
            Console.WriteLine($"Journal loaded successfully from {file}");
            Console.WriteLine($"Loaded {_entries.Count} entries");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File not found: {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
        }
    }
}
