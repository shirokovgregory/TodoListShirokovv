using Microsoft.EntityFrameworkCore;
using TodoListShirokovv.Presenter;

namespace TodoListShirokovv.Repos;

public class Repo : IRepo
{
    private readonly ToDoListContext _context;

    public Repo(ToDoListContext context)
    {
        _context = context;
    }

    public async Task<List<TodoTask>> SearchTask(string tag)
    {
        var tasksFromDb = await _context.Tasks
            .Where(taskDto => taskDto.tags.Contains(tag))
            .ToListAsync();

        return tasksFromDb.Select(taskDto =>
            new TodoTask(taskDto.title, taskDto.description, DateTime.Parse(taskDto.date),
                taskDto.tags.Split(',').ToList())).ToList();
    }

    public Task? AddTask(TodoTaskDto task)
    {
        _context.Tasks.AddAsync(task);
        return _context.SaveChangesAsync();
    }

    public async Task<Dictionary<string, List<TodoTask>>> ShowAllTasks()
    {
        var tasksFromDb = await _context.Tasks.ToListAsync();

        var groupedTasks = tasksFromDb
            .OrderByDescending(taskDto => DateTime.Parse(taskDto.date)) 
            .Select(taskDto =>
                new TodoTask(taskDto.title, taskDto.description, DateTime.Parse(taskDto.date),
                    taskDto.tags.Split(',').ToList()))
            .SelectMany(t => t.tags.Select(tag => new { Tag = tag, Task = t }))
            .GroupBy(t => t.Tag)
            .ToDictionary(g => g.Key, g => g.Select(x => x.Task).ToList());

        return groupedTasks;
    }
    
}