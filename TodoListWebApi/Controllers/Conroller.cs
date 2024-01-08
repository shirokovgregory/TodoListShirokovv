using Microsoft.AspNetCore.Mvc;
using TodoListShirokovv.Presenter;
using TodoListShirokovv.Repos;

namespace TodoListWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class Conroller
{
    private readonly IRepo _repository;
    
    public Conroller(IRepo repository)
    {
        _repository = repository;
    }
    
    [HttpGet] [Route("/search-task-by-tag")]
    public async Task<List<TodoTask>> Search([FromQuery] string tag)
    {
        return await _repository.SearchTask(tag);

    }

    [HttpPost]
    [Route("/add-new-task")]
    public Task AddTodoTask([FromBody] TodoTaskDto task)
    {
        return _repository.AddTask(task);
    }

    [HttpGet]
    [Route("/show-all-tasks")]
    public async Task<ActionResult<Dictionary<string, List<TodoTask>>>> LastTasks()
    {
        return await _repository.ShowAllTasks();
    }
}