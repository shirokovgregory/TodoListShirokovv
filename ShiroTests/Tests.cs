using Moq;
using TodoListShirokovv.DatabaseIntegration;
using TodoListShirokovv.Presenter;
using Xunit;
using Assert = NUnit.Framework.Assert;


namespace ShiroTests;

public class Tests
{
    [Fact]
    public void AddTask_ShouldAddTaskToExistingTag()
    {
        // Arrange
        var mock = new Mock<IMyRepository>();
        mock.Setup(r => r.LoadFromDB())
            .Returns(new Dictionary<string, List<TodoTask>>()); 
        var todoList = new TodoList(mock.Object);
        var tags = new List<string> { "ExistingTag" };
        var task = new TodoTask("TaskTitle", "TaskDescription", DateTime.Now, tags);

        // Act
        todoList.AddTask(task, tags);
        var retrievedTask = todoList.tasklist["ExistingTag"].FirstOrDefault();

        // Assert
        Assert.NotNull(retrievedTask);
        Assert.Equals(task, retrievedTask);
    }

    // Тест проверяет создание нового тега при добавлении задачи.
    [Fact]
    public void AddTask_ShouldCreateNewTagIfNotExist()
    {
        // Arrange
        var mock = new Mock<IMyRepository>();
        mock.Setup(r => r.LoadFromDB())
            .Returns(new Dictionary<string, List<TodoTask>>()); 
        var todoList = new TodoList(mock.Object);
        var tags = new List<string> { "NewTag" };
        var task = new TodoTask("TaskTitle", "TaskDescription", DateTime.Now, tags);

        // Act
        todoList.AddTask(task, tags);
        var retrievedTask = todoList.tasklist["NewTag"].FirstOrDefault();

        // Assert
        Assert.NotNull(retrievedTask);
        Assert.Equals(task, retrievedTask);
    }
}