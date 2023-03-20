namespace TasksProject.Dtos.Common
{
    public class BaseFilter
    {
        public string SearchText { get; set; }
        public int? PageSize { get; set; }
        public int? CurrentPage { get; set; }
    }
}
