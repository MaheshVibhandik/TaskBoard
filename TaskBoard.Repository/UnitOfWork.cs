
using TaskBoard.Repository.Repos;

namespace TaskBoard.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;
        public ITaskRepository Tasks { get; }

        public UnitOfWork(DbContextClass dbContext,
                            ITaskRepository issueRepository)
        {
            _dbContext = dbContext;
            Tasks = issueRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}

