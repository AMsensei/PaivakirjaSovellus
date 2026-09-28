DiaryManager manager = new DiaryManager();

manager.AddEntry(new DiaryEntry(DateTime.Now, "First entry", "My first diary entry."));
manager.AddEntry(new DiaryEntry(DateTime.Now, "Second entry", "Testing the manager."));

manager.ShowAllEntries();

manager.EditEntry(0, "First entry (edited)", "New content.");
manager.ShowAllEntries();

manager.DeleteEntry(1);
manager.ShowAllEntries();