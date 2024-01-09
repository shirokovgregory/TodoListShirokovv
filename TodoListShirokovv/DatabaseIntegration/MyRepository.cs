using System.Collections.ObjectModel;
using TodoListShirokovv.Presenter;

namespace TodoListShirokovv.DatabaseIntegration;

public class MyRepository : IMyRepository
{
    private readonly ToDoListContext _context;

    public MyRepository(ToDoListContext context)
    {
        _context = context;
    }

    public void SaveToDB(TodoList list)
    {
        _context.Tasks.RemoveRange(_context.Tasks);
         _context.SaveChanges();

        var _tasks = list.tasklist;
        
        var localTasks = _tasks.SelectMany(x => x.Value).Distinct().ToArray();
        _context.Tasks.AddRange(localTasks.Select(x => ReVisualise(x)));

        _context.SaveChanges();
    }
    
    public async Task SaveToDB(ObservableCollection<TodoTaskDto> list)
    {
        // Удаление старых задач
        _context.Tasks.RemoveRange(_context.Tasks);
        await _context.SaveChangesAsync();

        // Добавление новых задач
        _context.Tasks.AddRange(list);
        await _context.SaveChangesAsync();
    }

    public Dictionary<string, List<TodoTask>> LoadFromDB()
    {
        var tasks = _context.Tasks.ToList(); 
        
        var taskslist = tasks
            .Select(taskDto => new TodoTask(taskDto.title, taskDto.description, DateTime.Parse(taskDto.date), taskDto.tags.Split(',').ToList()))
            .SelectMany(t => t.tags.Select(tag => new { Tag = tag, Task = t }))
            .GroupBy(t => t.Tag)
            .ToDictionary(g => g.Key, g => g.Select(x => x.Task).ToList());

        return taskslist;
    }


    private TodoTaskDto ReVisualise(TodoTask t)
    {
        return new TodoTaskDto(t);
    }
}