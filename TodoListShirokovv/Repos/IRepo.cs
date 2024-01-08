using TodoListShirokovv.Presenter;

namespace TodoListShirokovv.Repos;

public interface IRepo
{
    Task<List<TodoTask>> SearchTask(string tag);
    Task? AddTask(TodoTaskDto task);
    Task<Dictionary<string, List<TodoTask>>> ShowAllTasks();
}