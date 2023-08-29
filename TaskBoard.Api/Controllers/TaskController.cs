using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services;
using TaskJob = TaskBoard.Models.TaskJob;


namespace TaskBoard.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        public readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Get the list of task
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTaskList()
        {
            var taskList = await _taskService.GetAllTasks();
            if (taskList == null)
            {
                return NotFound();
            }
            return Ok(taskList);
        }

        /// <summary>
        /// Get task by id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetTaskById(int taskId)
        {
            var taskDetails = await _taskService.GetTaskById(taskId);

            if (taskDetails != null)
            {
                return Ok(taskDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add a new task
        /// </summary>
        /// <param name="taskDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskJob taskDetails)
        {
            var isTaskCreated = await _taskService.CreateTask(taskDetails);

            if (isTaskCreated)
            {
                return Ok(isTaskCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update the task
        /// </summary>
        /// <param name="tasktDetails"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(TaskJob tasktDetails)
        {
            if (tasktDetails != null)
            {
                var isTasktCreated = await _taskService.UpdateTask(tasktDetails);
                if (isTasktCreated)
                {
                    return Ok(isTasktCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete task by id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(int productId)
        {
            var isTaskCreated = await _taskService.DeleteTask(productId);

            if (isTaskCreated)
            {
                return Ok(isTaskCreated);
            }
            else
            {
                return BadRequest();
            }
        }
    }


}
