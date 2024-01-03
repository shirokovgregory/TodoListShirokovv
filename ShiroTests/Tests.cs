using NUnit.Framework;
using TodoListShirokovv.Presenter;


namespace ShiroTests;

public class Tests
{
    [Theory]
    public void AddTask_ShouldCreateNewTagIfNotExist()
    {
        // Arrange
        var todoList = new TodoList();
        var tags = new List<string> { "NewTag" };
        var task = new TodoTask("TaskTitle", "TaskDescription", DateTime.Now, tags);

        // Act
        todoList.AddTask(task, tags);
        var retrievedTask = todoList.tasklist["NewTag"].FirstOrDefault();

        // Assert
        Assert.NotNull(retrievedTask);
        Assert.AreEqual(task, retrievedTask);
        
    }

    // Тест проверяет возвращение false при поиске несуществующего тега.
    [Theory]
    public void SearchTask_ShouldReturnFalseForNonExistingTag()
    {
        // Arrange
        var todoList = new TodoList();

        // Act
        var result = todoList.SearchTask("NonExistingTag");

        // Assert
        Assert.IsEmpty(result);
    }
}