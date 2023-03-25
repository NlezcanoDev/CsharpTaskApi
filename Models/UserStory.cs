using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TasksProject.Models.Enum;

namespace TasksProject.Models
{
    public class UserStory : ModelBase<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int SprintId { get; set; }

        public Sprint Sprint { get; set; }

        public PriorityEnum Priority { get; set; }
    }
}
