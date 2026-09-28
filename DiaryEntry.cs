public class DiaryEntry // declares a new class
{
    // class properties: the info each diary entry will contain
    public DateTime Date { get; set; } // get = read the value, set = change the value
    public string Title { get; set; }
    public string Content { get; set; }

    // constructor: runs when we create an entry with "new DiaryEntry(...)"
    public DiaryEntry(DateTime date, string title, string content)
    {
        Date = date;       // value received as a parameter (date) is stored in the property (Date)
        Title = title;
        Content = content;
    }

    // replaces the default ToString() to control how an entry is displayed
    public override string ToString()
    {
        return $"[{Date.ToShortDateString()}] {Title}\n{Content}";
    }
}