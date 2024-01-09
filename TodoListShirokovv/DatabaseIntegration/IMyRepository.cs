using TodoListShirokovv.Presenter;

namespace TodoListShirokovv.DatabaseIntegration;

public interface IMyRepository
{
    void SaveToDB(TodoList list);
    Dictionary<string, List<TodoTask>> LoadFromDB();
}