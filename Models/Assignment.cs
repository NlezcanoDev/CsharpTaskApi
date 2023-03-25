using TasksProject.Models.Enum;

namespace TasksProject.Models
{
    public class Assignment : ModelBase<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public CategoryEnum Category { get; set; }

        public int UserStoryId { get; set; }

        public UserStory UserStory { get; set; }

        public StatusEnum Status { get; set; }

        public int AssignTo { get; set; }

    }
}
