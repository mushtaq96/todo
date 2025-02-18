
using MyTodoList.DataAccess.Entities;

namespace MyTodoList.DataAccess.Repositories
{
    public interface IToDoTaskRepository
    {
        ICollection<ToDoTask> GetAllToDoTasks();

        ToDoTask? GetTaskById(int id);

        ToDoTask Create(ToDoTask task);

        ToDoTask Update(ToDoTask task);

        void Delete(ToDoTask task);
    }
}
