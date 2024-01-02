using TodoListShirokovv.Presenter;

class Program
{
    static void Main()
    {
        TodoList todoList = new TodoList();

        while (true)
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("-a: Add a task");
            Console.WriteLine("-s: Search tasks by tag");
            Console.WriteLine("-shwall: Show all tasks");
            Console.WriteLine("-q: Quit");

            string command = Console.ReadLine();

            switch (command)
            {
                case "-a":
                    Console.WriteLine("Enter task title:");
                    string? title = Console.ReadLine();

                    Console.WriteLine("Enter task description:");
                    string? description = Console.ReadLine();

                    Console.WriteLine("Enter task date (yyyy-MM-dd):");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    {
                        Console.WriteLine("Invalid date format.");
                        continue;
                    }

                    Console.WriteLine("Enter tags (separated by spaces):");
                    List<string> tags = new List<string>(Console.ReadLine().Split());

                    TodoTask newTask = new TodoTask(title, description, date, tags);
                    todoList.AddTask(newTask, tags);
                    Console.WriteLine("Task added successfully!");
                    break;

                case "-s":
                    Console.WriteLine("Enter tag to search:");
                    string? searchTag = Console.ReadLine();
                    List<TodoTask> searchResults = todoList.SearchTask(searchTag);

                    Console.WriteLine($"Tasks with tag '{searchTag}':");
                    foreach (var task in searchResults)
                    {
                        task.PrintTask();
                    }
                    break;

                case "-shwall":
                    todoList.ShowAllTasks();
                    break;

                case "-q":
                    return;

                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
