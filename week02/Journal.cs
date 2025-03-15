using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// The Journal class manages a collection of entries and handles saving/loading from files
/// </summary>
class Journal
{
    private List<Entry> _entries;

    /// <summary>
    /// Constructor initializes an empty list of entries
    /// </summary>
    public Journal()
    {
        _entries = new List<Entry>();
    }

    /// <summary>
    /// Adds a new entry to the journal
    /// </summary>
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    /// <summary>
    /// Displays all entries in the journal
    /// </summary>
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

    /// <summary>
    /// Saves all entries to a file
    /// </summary>
    public void SaveToFile(string filename)
    {
        try
        {
            // Ensure the filename has a .txt extension
            if (!filename.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                filename += ".txt";
            }
            
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.ToFileString());
                }
            }
            Console.WriteLine($"Journal saved successfully to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads entries from a file, replacing any current entries
    /// </summary>
    public void LoadFromFile(string filename)
    {
        try
        {
            // Ensure the filename has a .txt extension
            if (!filename.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                filename += ".txt";
            }
            
            _entries.Clear();
            
            using (StreamReader reader = new StreamReader(filename))
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
            
            Console.WriteLine($"Journal loaded successfully from {filename}");
            Console.WriteLine($"Loaded {_entries.Count} entries");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File not found: {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
        }
    }
}
