using Microsoft.EntityFrameworkCore;
using TodoListShirokovv.DatabaseIntegration;
using TodoListShirokovv.Presenter;
using TodoListShirokovv.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ToDoListContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("myDB")));

builder.Services.AddTransient<IRepo, Repo>();
builder.Services.AddTransient<IMyRepository, MyRepository>();
builder.Services.AddTransient<ITodoList, TodoList>();


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();