using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Models
{
    public class TaskJob
    {
        public int Id { get; set; }
        [Required]
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        [Required]
        public int Reporter { get; set; }
        public int Assignee { get; set; }
        public IssueState State { get; set; }
        public string Deadline { get; set; }       
    }
}
