using AutoMapper;
using TasksProject.Models;

namespace TasksProject
{
    public class Bootstrapper
    {
        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void BootStrap()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                // TODO completar config AutoMapper
                cfg.CreateMap<Assignment, Dtos.Assignment>();

                cfg.CreateMap<User, Dtos.User>();

                cfg.CreateMap<UserStory, Dtos.UserStory>();

                cfg.CreateMap<Sprint, Dtos.Sprint>();
            });
        }
    }
}
