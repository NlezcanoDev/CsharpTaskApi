using TasksProject.Models.Enum;

namespace TasksProject.Dtos
{
    public class UserStory
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int SprintId { get; set; }

        public Sprint Sprint { get; set; }

        public PriorityEnum Priority { get; set; }
    }
}
