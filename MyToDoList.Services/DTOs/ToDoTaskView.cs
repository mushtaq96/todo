using MyTodoList.DataAccess.Entities;

namespace MyToDoList.Domain.DTOs
{
    public class ToDoTaskView
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; }

        public ToDoTaskView() { }

        public ToDoTaskView(ToDoTask task)
        {
            Id = task.Id;
            Title = task.Title;
            IsCompleted = task.IsCompleted;
        }
    }
}
