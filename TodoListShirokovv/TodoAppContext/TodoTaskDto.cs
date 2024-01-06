using TodoListShirokovv.Presenter;

public class TodoTaskDto
{
    public ulong id { get; set; }
    public string title { get; set; }
    
    public string description { get; set; }
    
    public string date { get; set; }
    
    public string tags { get; set; }

    public TodoTaskDto()
    {
    }

    public TodoTaskDto(TodoTask task)
    {
        title = task.title;
        description = task.description;
        date = task.date.ToString();
        tags = string.Join(", ", task.tags);
    }
}