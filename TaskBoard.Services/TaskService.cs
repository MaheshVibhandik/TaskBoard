
using TaskJob = TaskBoard.Models.TaskJob;
using TaskBoard.Repository;

namespace TaskBoard.Services
{
    public class TaskService : ITaskService
    {
        public IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateTask(TaskJob task)
        {
            if (task != null)
            {
                await _unitOfWork.Tasks.Add(task);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            if (taskId > 0)
            {
                var productDetails = await _unitOfWork.Tasks.GetById(taskId);
                if (productDetails != null)
                {
                    _unitOfWork.Tasks.Delete(productDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<TaskJob>> GetAllTask()
        {
            var taskList = await _unitOfWork.Tasks.GetAll();
            return taskList;
        }

        public Task<IEnumerable<TaskJob>> GetAllTasks()
        {
           var taskList = Task.Run(() => _unitOfWork.Tasks.GetAll()).Result;
            return Task.FromResult(taskList);
        }

        public async Task<TaskJob> GetTaskById(int taskId)
        {
            if (taskId > 0)
            {
                var task = await _unitOfWork.Tasks.GetById(taskId);
                if (task != null)
                {
                    return task;
                }
            }
            return null;
        }

        public async Task<bool> UpdateTask(TaskJob taskDetails)
        {
            if (taskDetails != null)
            {
                var task = await _unitOfWork.Tasks.GetById(taskDetails.Id);
                if (task != null)
                {
                    task.Subject = taskDetails.Subject;
                    task.Deadline = taskDetails.Deadline;
                    task.Reporter = taskDetails.Reporter;
                    task.Description = taskDetails.Description;
                    task.Assignee = taskDetails.Assignee;
                    task.Priority = taskDetails.Priority;
                    task.State = taskDetails.State;

                    _unitOfWork.Tasks.Update(task);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
