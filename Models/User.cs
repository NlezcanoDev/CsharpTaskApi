using TasksProject.Models.Enum;

namespace TasksProject.Models
{
    public class User : ModelBase<int>
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Identification { get; set; } 
        public ProfileEnum Profile { get; set; }
    }
}
