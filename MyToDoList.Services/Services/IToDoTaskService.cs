
using MyTodoList.DataAccess.Entities;
using MyToDoList.Domain.DTOs;

namespace MyToDoList.Domain.Services
{
    public interface IToDoTaskService
    {
        ICollection<ToDoTaskView> GetAllToDoTasks();

        ToDoTaskView MarkTaskAsCompleted(int taskId);

        ToDoTaskView CreateNewTask(ToDoTaskDraft taskDraft);

        void DeleteTask(int taskId);
    }
}
