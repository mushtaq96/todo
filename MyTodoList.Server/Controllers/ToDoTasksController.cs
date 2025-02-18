using Microsoft.AspNetCore.Mvc;
using MyToDoList.Domain.DTOs;
using MyToDoList.Domain.Services;

namespace MyTodoList.Server.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class ToDoTasksController : ControllerBase
    {
        private readonly IToDoTaskService _taskService;

        public ToDoTasksController(IToDoTaskService taskService)
        {
            _taskService = taskService ?? throw new ArgumentException(nameof(taskService));
        }

        [HttpGet]
        public ICollection<ToDoTaskView> GetAllTasks()
        {
            return _taskService.GetAllToDoTasks();
        }

        [HttpPost("completed/{taskId}")]
        public ToDoTaskView MarkTaskAsCompleted(int taskId)
        {
            return _taskService.MarkTaskAsCompleted(taskId);
        }

        [HttpPost]
        public ToDoTaskView CreateNewTask([FromBody] ToDoTaskDraft draft)
        {
            return _taskService.CreateNewTask(draft);
        }

        [HttpDelete("{taskId}")]
        public void DeleteTask(int taskId)
        {
            _taskService.DeleteTask(taskId);
        }
    }
}
