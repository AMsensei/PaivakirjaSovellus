public class DiaryEntry // on declare une nouvelle classe
{
    //proprietes de la classe - infos que chaque entree de journal va contenir
    public DateTime Date { get; set; } //get = lire la valeur, set = modifier la valeur
    public string Title { get; set; }    public string Content {get; set; }

    public DiaryEntry(DateTime date, string title, string content) // les parametres
    {
        Date = date; // valeur recu en parametres (date) mis dans la propriete de l'objet (Date)
        Title = title;
        Content = content;
    }    
    public override string ToString()
    {
        return $"[{Date.ToShortDateString()}] {Title}\n{Content}";
    }  
}

