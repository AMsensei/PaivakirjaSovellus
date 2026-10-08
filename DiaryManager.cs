using System.Collections.Generic;
using System.Globalization;
using System.IO;

// Manages the collection of diary entries (add, show, edit, delete)
// and saves them to / loads them from a text file.
public class DiaryManager
{
    private List<DiaryEntry> entries = new List<DiaryEntry>(); // The list that stores all entries in memory.

    // Path of the text file where entries are saved
    private string filePath;

    // Separator between the three fields of an entry on one line
    private const char Separator = '|';

    // Date format used in the file (same format for writing and reading)
    private const string DateFormat = "yyyy-MM-dd HH:mm:ss";

    // Constructor: remembers the file path and loads existing entries from it.
    public DiaryManager(string filePath)
    {
        this.filePath = filePath;
        LoadFromFile();
    }

    public void AddEntry(DiaryEntry entry) // Adds a new entry at the end of the list.
    {
        entries.Add(entry);
        SaveToFile();
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
        SaveToFile();
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
        SaveToFile();
        Console.WriteLine("Entry updated.");
        return true;
    }

    // Writes all entries to the file, one entry per line.
    private void SaveToFile()
    {
        // This list will hold one text line per entry
        List<string> lines = new List<string>();

        foreach (DiaryEntry entry in entries)
        {
            // Replace the separator inside the text so it cannot break the format
            string title = entry.Title.Replace(Separator, '/');
            string content = entry.Content.Replace(Separator, '/');

            // string.Join glues the three parts together with the separator
            string line = string.Join(Separator, entry.Date.ToString(DateFormat), title, content);
            lines.Add(line);
        }

        // Writes all lines to the file (creates it if needed, overwrites it otherwise)
        File.WriteAllLines(filePath, lines);
    }

    // Reads the file and fills the list with the entries found.
    private void LoadFromFile()
    {
        // First launch: the file does not exist yet, so there is nothing to load
        if (!File.Exists(filePath))
        {
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            // Cut the line at each separator, in at most 3 parts
            string[] parts = line.Split(Separator, 3);

            // A valid line must have exactly 3 parts, otherwise we skip it
            if (parts.Length != 3)
            {
                continue;
            }

            // Convert the first part back into a DateTime
            if (!DateTime.TryParseExact(parts[0], DateFormat, CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out DateTime date))
            {
                continue; // invalid date: skip this line
            }

            entries.Add(new DiaryEntry(date, parts[1], parts[2]));
        }
    }
}