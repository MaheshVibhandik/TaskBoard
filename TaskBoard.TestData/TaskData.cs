using TaskBoard.Models;

namespace TaskBoard.TestData
{
    public class TaskData
    {
        public static TaskJob GetTheTaskJobData(int taskid)
        {
            return new TaskJob
            {
                Id = taskid,
                Assignee = 1,
                Deadline = DateTime.Now.AddDays(10).ToString(),
                Description = "TestDescription",
                Priority = Priority.Low,
                Reporter = 101,
                State = IssueState.ToDo,
                Subject = "TestTask"
            };

        }

        public static IEnumerable<TaskJob> GetTaskJobList(int jobCount)
        {
            var jobList = new List<TaskJob>();
            for (int i = 0; i < jobCount; i++)
            {
                jobList.Add(GetTheTaskJobData(105 + i));
            }
            return jobList;
        }
    }
}