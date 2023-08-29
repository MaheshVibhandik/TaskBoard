
using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Models
{
    public class BaseEntity
    {
        [Required]
        public int Id
        {
            get;
            set;
        }
        public DateTime AddedDate
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
    }
}
