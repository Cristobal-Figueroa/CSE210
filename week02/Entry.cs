using System;

class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public string GetDate()
    {
        return _date;
    }

    public void SetDate(string date)
    {
        _date = date;
    }

    public string GetPromptText()
    {
        return _promptText;
    }

    public void SetPromptText(string promptText)
    {
        _promptText = promptText;
    }

    public string GetEntryText()
    {
        return _entryText;
    }

    public void SetEntryText(string entryText)
    {
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine();
    }

    public string ToFileString()
    {
        return $"{_date}~|~{_promptText}~|~{_entryText}";
    }

    public static Entry FromFileString(string fileString)
    {
        string[] parts = fileString.Split("~|~");
        
        if (parts.Length != 3)
        {
            throw new FormatException("Invalid entry format in file");
        }

        Entry entry = new Entry();
        entry.SetDate(parts[0]);
        entry.SetPromptText(parts[1]);
        entry.SetEntryText(parts[2]);
        return entry;
    }
}
