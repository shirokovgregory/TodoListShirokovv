using System;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Views;
using ReactiveUI;
//
namespace AvaloniaApplication1.ViewModels;

public class DialogVM : ViewModelBase
{
    private string _title = "Задача";
    private string _description = "Description";
    private string _date = "01.01.2023";
    private string _tags = "Tag1, Tag2, Tag3";

    private TodoVM _TodoVM;
    private DialogWindow _dialog;
    private ActionType _actionType;

    public DialogVM(TodoVM todoVM, DialogWindow dialog, ActionType actionType)
    {
        _TodoVM = todoVM;
        _dialog = dialog;
        _actionType = actionType;
        
        if (_actionType == ActionType.edit && _TodoVM.SelectedTask != null)
        {
            Title = _TodoVM.SelectedTask.title;
            Description = _TodoVM.SelectedTask.description;
            Date = _TodoVM.SelectedTask.date;
            Tags = _TodoVM.SelectedTask.tags;
        }
    }
    

    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }
    
    public string Date
    {
        get => _date;
        set
        {
            if (DateTime.TryParse(value, out DateTime parsedDate))
            {
                // Форматируем дату в нужный вид
                _date = parsedDate.ToString("dd.MM.yyyy");
                this.RaiseAndSetIfChanged(ref _date, _date);
            }
        }
    }
    
    public string Tags
    {
        get => _tags;
        set => this.RaiseAndSetIfChanged(ref _tags, value);
    }
    
    public void AddTask()
    {
        switch (_actionType)
        {
            case ActionType.add: 
                _TodoVM.AddTask(_title, _description, _date, _tags);
                break;
            case ActionType.edit:
                _TodoVM.EditTask(_title, _description, _date, _tags);
                break;
        }
        _dialog.Close();
        
    }
}