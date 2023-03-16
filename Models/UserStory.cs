using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TasksProject.Models.Enum;

namespace TasksProject.Models
{
    public class UserStory : ModelBase<int>
    {
        [Required]
        [MaxLength(45)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey("sprintId")]
        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }

        public PriorityEnum Priority { get; set; }
    }
}
