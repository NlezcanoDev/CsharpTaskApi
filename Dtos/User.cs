using TasksProject.Models.Enum;

namespace TasksProject.Dtos
{
    public class User
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Identification { get; set; }
        public ProfileEnum Profile { get; set; }
    }
}
