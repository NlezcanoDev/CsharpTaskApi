using System.ComponentModel.DataAnnotations;

namespace TasksProject.Models
{
    public class Sprint : ModelBase<int>
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
