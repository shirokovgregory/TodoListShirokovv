namespace TodoListShirokovv.Presenter;

public class TodoTask
{
    public string title { get; set; }
    
    public string description { get; set; }
    
    public DateTime date { get; set; }
    
    public List<string> tags { get; set; }
    
    public TodoTask(string title, string description, DateTime date, List<string> tags)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.tags = tags;
    }


    public void PrintTask()
    {
        Console.WriteLine(title);
        
        Console.WriteLine(description);
        
        Console.WriteLine(date);
        
        Console.WriteLine("Tags:");
        for (var i = 0; i < tags.Count; i++)
        {
            Console.Write(tags[i] + " ");
        }

        Console.WriteLine();
    }
}