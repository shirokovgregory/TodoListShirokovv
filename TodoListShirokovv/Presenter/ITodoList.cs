namespace TodoListShirokovv.Presenter;

public interface ITodoList
{
    void AddTask(TodoTask task, IList<string> tagslist);
    List<TodoTask> SearchTask(string tag);
    void ShowAllTasks();
}
