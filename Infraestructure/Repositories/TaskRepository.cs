using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class TaskRepository : RepositoryBase<Domain.Entities.TaskEntity>, ITaskRepository
    {
        public TaskRepository(ManagementTaskDbContext dbContext) : base(dbContext)
        {

        }       
    }
}
