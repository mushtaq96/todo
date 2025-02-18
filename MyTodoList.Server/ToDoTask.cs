namespace MyTodoList.Server
{
    public class ToDoTask
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public bool IsCompleted { get; set; }
    }
}
