using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TasksProject.Models.Enum;

namespace TasksProject.Models
{
    public class Assignment : ModelBase<int>
    {
        [Required]
        [MaxLength(45)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public CategoryEnum Category { get; set; }

        [ForeignKey("userStoryId")]
        public int UserStoryId { get; set; }

        public UserStory UserStory { get; set; }

        [Required] 
        public StatusEnum Status { get; set; }

        public int AsignTo { get; set; }

    }
}
