namespace TasksProject.Dtos.Common
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Messages = new List<string>();
        }

        public IList<string> Messages { get; set; }
        public T Data { get; set; }
}
}
