namespace TaskBoard.Models
{
    public class Attachment 
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string? Data { get; set; }

    }
}
