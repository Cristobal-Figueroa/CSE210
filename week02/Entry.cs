using System;

/// <summary>
/// The Entry class represents a single journal entry with a date, prompt, and response.
/// </summary>
class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    /// <summary>
    /// Displays the entry in a formatted way
    /// </summary>
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine();
    }

    /// <summary>
    /// Converts the entry to a string format for file storage
    /// Using a custom separator that's unlikely to appear in content
    /// </summary>
    public string ToFileString()
    {
        return $"{Date}~|~{Prompt}~|~{Response}";
    }

    /// <summary>
    /// Creates an Entry object from a string that was previously formatted for file storage
    /// </summary>
    public static Entry FromFileString(string fileString)
    {
        string[] parts = fileString.Split("~|~");
        
        if (parts.Length != 3)
        {
            throw new FormatException("Invalid entry format in file");
        }

        return new Entry
        {
            Date = parts[0],
            Prompt = parts[1],
            Response = parts[2]
        };
    }
}
