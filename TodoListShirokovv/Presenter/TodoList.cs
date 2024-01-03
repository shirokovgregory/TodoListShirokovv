
namespace TodoListShirokovv.Presenter
{
    public class TodoList : ITodoList
    {
        public Dictionary<string, List<TodoTask>> tasklist { get; }

        public TodoList()
        {
            tasklist = new Dictionary<string, List<TodoTask>>();
        }
        

        public void AddTask(TodoTask task, IList<string> tagslist)
        {
            foreach (var tag in tagslist)
            {
                if (tasklist.ContainsKey(tag))
                {
                    tasklist[tag].Add(task);
                }
                else
                {
                    tasklist.Add(tag, new List<TodoTask> { task });
                }
            }
        }

        public List<TodoTask> SearchTask(string tag)
        {
            if (tasklist.ContainsKey(tag))
            {
                return tasklist[tag];
            }

            return new List<TodoTask>(); // Возвращаем пустой список, если тег не найден
        }

        public void ShowAllTasks()
        {
            HashSet<TodoTask> uniqueTasks = new HashSet<TodoTask>();

            foreach (var tagTasks in tasklist.Values)
            {
                foreach (var task in tagTasks)
                {
                    uniqueTasks.Add(task);
                }
            }

            foreach (var task in uniqueTasks)
            {
                task.PrintTask();
            }
        }
    }
}