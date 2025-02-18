
using MyTodoList.DataAccess.DbContext;
using MyTodoList.DataAccess.Entities;
namespace MyTodoList.DataAccess.Repositories
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly MyToDoListDbContext _dbContext;

        public ToDoTaskRepository(MyToDoListDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));

            if (!_dbContext.Tasks.Any())
            {
                InsertDefaultTasks();
            }
        }

        private void InsertDefaultTasks()
        {
            _dbContext.Tasks.AddRange(
                new[]
                {
                    new ToDoTask { Title = "Do the dishes" },
                    new ToDoTask { Title = "Laundry" },
                    new ToDoTask { Title = "Grocery shopping" },
                    new ToDoTask { Title = "Bake cake" },
                    new ToDoTask { Title = "Mow the lawn" }
                }
            );

            _dbContext.SaveChanges();
        }

        public ICollection<ToDoTask> GetAllToDoTasks()
        {
            return _dbContext.Tasks.ToList();
        }

        public ToDoTask? GetTaskById(int id)
        {
            return _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public ToDoTask Create(ToDoTask task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
            return task;
        }

        public ToDoTask Update(ToDoTask task)
        {
            _dbContext.Tasks.Update(task);
            _dbContext.SaveChanges();
            return task;
        }

        public void Delete(ToDoTask task)
        {
            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();
        }
    }
}
