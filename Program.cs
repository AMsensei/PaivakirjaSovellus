class Program
{
    static void Main() // Main is where the program starts.
    {
        DiaryManager manager = new DiaryManager(); // Create the manager that holds all our entries

        bool running = true; // The loop keeps running until this becomes false

        while (running)
        {
            ShowMenu();

            string choice = Console.ReadLine() ?? ""; // Read what the user typed

            switch (choice) // Run a different action depending on the choice
            {
                case "1":
                    AddNewEntry(manager);
                    break;
                case "2":
                    manager.ShowAllEntries();
                    break;
                case "3":
                    EditExistingEntry(manager);
                    break;
                case "4":
                    DeleteExistingEntry(manager);
                    break;
                case "5":
                    running = false; // Ends the while loop
                    Console.WriteLine("Bye! :)");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again."); // Run if the choice matches none of the cases above
                    break;  
            }
        }
    }

    static void ShowMenu() // Print the menu options
    {
        Console.WriteLine();
        Console.WriteLine("==== DIARY ====");
        Console.WriteLine("1. Add an entry");
        Console.WriteLine("2. Show all entries");
        Console.WriteLine("3. Edit an entry");
        Console.WriteLine("4. Delete an entry");
        Console.WriteLine("5. Quit");
        Console.WriteLine("Your choice: ");
    }

    static void AddNewEntry(DiaryManager manager) // Asks the user for a title and content, then adds the entry
    {
        Console.Write("Title: ");
        string title = Console.ReadLine() ?? "";

        Console.Write("Content: ");
        string content = Console.ReadLine() ?? "";

        DiaryEntry entry = new DiaryEntry(DateTime.Now, title, content); // DateTime.Now = today's date and current time
        manager.AddEntry(entry);  
    }

    static void EditExistingEntry(DiaryManager manager) // Asks which entry to edit and what the new values are
    {
        manager.ShowAllEntries();

        Console.Write("Index of the entry to edit: ");
        string input = Console.ReadLine() ?? "";

        if (!int.TryParse(input, out int index)) // TryParse converts text to a number without crashing if the text is not a number.
                                                 // It returns true if it worked, and puts the number in "index".
        {
            Console.WriteLine("Please enter a number.");
            return;
        }

        Console.Write("New title: ");
        string newTitle = Console.ReadLine() ?? "";

        Console.Write("New content: ");
        string newContent = Console.ReadLine() ?? "";

        manager.EditEntry(index, newTitle, newContent);
    }

    static void DeleteExistingEntry(DiaryManager manager) // Asks which entry to delete
    {
        manager.ShowAllEntries();

        Console.Write("Index of the entry to delete: ");
        string input = Console.ReadLine() ?? "";

        if(!int.TryParse(input, out int index))
        {
            Console.WriteLine("Please enter a number.");
            return;
        }

        manager.DeleteEntry(index);
    }
}