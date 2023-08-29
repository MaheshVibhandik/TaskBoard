using TaskJob = TaskBoard.Models.TaskJob;

namespace TaskBoard.Services
{
    public interface ITaskService
    {
        Task<bool> CreateTask(TaskJob task);

        Task<IEnumerable<TaskJob>> GetAllTasks();

        Task<TaskJob> GetTaskById(int productId);

        Task<bool> UpdateTask(TaskJob task);

        Task<bool> DeleteTask(int taskId);

    }
}