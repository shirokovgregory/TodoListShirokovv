using System.Collections.ObjectModel;
using System.Linq;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Views;
using DynamicData;
using ReactiveUI;
using TodoListShirokovv.DatabaseIntegration;

namespace AvaloniaApplication1.ViewModels;

public class TodoVM : ViewModelBase
{
    private ToDoListContext _context;
    private MyRepository _dbConnection;
    public ObservableCollection<TodoTaskDto> TaskList { get; set; } = new ObservableCollection<TodoTaskDto>();

    public bool _isSelected;
    public bool IsSelected
    {
        get { return _isSelected; }
        set
        {
            this.RaiseAndSetIfChanged(ref _isSelected, value);
        }
    }
    private TodoTaskDto _selectedTask;
    public TodoTaskDto SelectedTask
    {
        get => _selectedTask;
        set
        { 
            this.RaiseAndSetIfChanged(ref _selectedTask, value);
            IsSelected = SelectedTask != null;
        } 
    }
    
    

    public TodoVM()
    {
        _context = new ToDoListContext();
        _dbConnection = new MyRepository(_context);
        var t = _context.Tasks.ToList();
        TaskList.AddRange(t); 
    }

    public void ShowAddTaskDialog(ActionType actionType)
    {
        var dialog = new DialogWindow();
        dialog.DataContext = new DialogVM(this, dialog, actionType);
        
        dialog.Show();
    }

    public void AddTask(string Title, string Description, string Date, string Tags)
    {
        var newTask = new TodoTaskDto
        {
            title = Title,
            description = Description,
            date = Date,
            tags = Tags,
            id = (ulong) (TaskList.Count() + 1)
        };
        TaskList.Add(newTask);
        _dbConnection.SaveToDB(TaskList);
        SelectedTask = newTask;
    }
    
    public void EditTask(string Title, string Description, string Date, string Tags)
    {
        SelectedTask.title = Title;
        SelectedTask.description = Description;
        SelectedTask.date = Date;
        SelectedTask.tags = Tags;
        _dbConnection.SaveToDB(TaskList);
    }
    
    public void DeleteTask()
    {
        TaskList.Remove(SelectedTask);
        _dbConnection.SaveToDB(TaskList);
    }
}