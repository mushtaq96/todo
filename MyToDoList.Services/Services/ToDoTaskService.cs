using MyTodoList.DataAccess.Entities;
using MyTodoList.DataAccess.Repositories;
using MyToDoList.Domain.DTOs;
using System.Threading.Tasks;

namespace MyToDoList.Domain.Services
{
    public class ToDoTaskService: IToDoTaskService
    {
        private readonly IToDoTaskRepository _taskRepository;

        public ToDoTaskService(IToDoTaskRepository taskRepository)
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
        }

        public ICollection<ToDoTaskView> GetAllToDoTasks()
        {
            var tasks = _taskRepository.GetAllToDoTasks();

            var taskViews = new List<ToDoTaskView>();
            foreach (var task in tasks)
            {
                taskViews.Add(new ToDoTaskView(task));
            }

            return taskViews;
        }

public ToDoTaskView MarkTaskAsCompleted(int taskId)
{
        if (taskId<= 0)
        {
                     throw 
                         new ArgumentException("The task id must be greater than 0");
}

    var task = _taskRepository.GetTaskById(taskId);

    if (task is null)
    {
throw new Exception($"Task {taskId} not found");
}

task.IsCompleted = true;

    _taskRepository.Update(task);

    return 
    new
    ToDoTaskView(task);
}

        public ToDoTaskView CreateNewTask(ToDoTaskDraft taskDraft)
        {
            if (taskDraft is null)
            {
                throw new ArgumentNullException(nameof(taskDraft));
            }

            if (String.IsNullOrEmpty(taskDraft.Title) || String.IsNullOrWhiteSpace(taskDraft.Title))
            {
                throw new ArgumentException("The task title can not be empty");
            }

            var task = new ToDoTask { Title = taskDraft.Title };
            _taskRepository.Create(task);
            return new ToDoTaskView(task);
        }

        public void DeleteTask(int taskId)
        {
            if (taskId <= 0)
            {
                throw new ArgumentException("The task id must be greater than 0");
            }

            var task = _taskRepository.GetTaskById(taskId);
            if (task is null)
            {
                throw new Exception($"Task {taskId} not found");
            }

            _taskRepository.Delete(task);
        }
    }
}
