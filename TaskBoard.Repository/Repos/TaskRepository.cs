

using TaskBoard.Models;

namespace TaskBoard.Repository.Repos
{
    public class TaskRepository : Repository<TaskJob>, ITaskRepository
    {
        public TaskRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
