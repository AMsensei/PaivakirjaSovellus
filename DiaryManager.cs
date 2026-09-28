using System.Collections.Generic;

public class DiaryManager
{
    private List<DiaryEntry> entries = new List<DiaryEntry>(); // The list that stores all entries in memory.

    public void AddEntry(DiaryEntry entry) // Adds a new entry at the end of the list.
    {
        entries.Add(entry);
        Console.WriteLine("Entry added.");
    }

    public void ShowAllEntries()
    {
        if (entries.Count == 0) // If the list is empty, tell the user and stop here.
        {
            Console.WriteLine("No entries yet.");
            return;
        }

        for (int i = 0; i < entries.Count; i++) 
        {
            Console.WriteLine($"--- Entry {i} ---");
            Console.WriteLine(entries[i]);
        }
    }
    // Deletes the entry at the given index.
    // Returns true if it worked, false if the index was invalid.
    public bool DeleteEntry(int index)
    {
        if (index < 0 || index >= entries.Count)
        {
            Console.WriteLine("Invalid index.");
            return false;
        }

        entries.RemoveAt(index);
        Console.WriteLine("Entry deleted.");
        return true;
    }
    // Changes the title and content of the entry at the given index.
    // Returns true if it worked, false if the index was invalid.
    public bool EditEntry(int index, string newTitle, string newContent)
    {
        if (index < 0 || index >= entries.Count)
        {
            Console.WriteLine("Invalid index.");
            return false;
        }

        // Get the entry at this position and update its properties.
        entries[index].Title = newTitle;
        entries[index].Content = newContent;
        Console.WriteLine("Entry updated.");
        return true;
    }
}