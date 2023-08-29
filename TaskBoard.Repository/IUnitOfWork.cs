
using TaskBoard.Repository.Repos;

namespace TaskBoard.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository Tasks { get; }

        int Save();
    }
}
