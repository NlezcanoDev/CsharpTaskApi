namespace TasksProject.Dtos.Common
{
    public class PaginatedResponse<T> : BaseResponse<IList<T>>
    {
        public int Count { get; set; }
    }
}
