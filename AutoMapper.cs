using AutoMapper;

namespace TasksProject
{
    public class AutoMapper
    {
        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void BootStrap()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                // TODO completar config AutoMapper
            });
        }
    }
}
