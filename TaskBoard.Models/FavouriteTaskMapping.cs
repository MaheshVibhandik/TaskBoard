namespace TaskBoard.Models
{
    public class FavouriteTaskMapping : BaseEntity
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
    }
}
