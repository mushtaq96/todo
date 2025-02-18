using Microsoft.Extensions.DependencyInjection;
using MyTodoList.DataAccess.Repositories;

namespace MyTodoList.DataAccess
{
    public static class DataAccessExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();
        }
    }
}
