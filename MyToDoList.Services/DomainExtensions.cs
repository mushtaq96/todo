using Microsoft.Extensions.DependencyInjection;
using MyTodoList.DataAccess;
using MyTodoList.DataAccess.DbContext;
using MyToDoList.Domain.Services;

namespace MyToDoList.Domain
{
    public static class DomainExtensions
    {
        public static void AddDomainServices(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddDbContext<MyToDoListDbContext>();
            serviceCollection.AddDataAccessServices();

            serviceCollection.AddScoped<IToDoTaskService, ToDoTaskService>();
        }
    }
}
