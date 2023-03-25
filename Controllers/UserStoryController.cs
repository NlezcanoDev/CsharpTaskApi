using Microsoft.AspNetCore.Mvc;
using TasksProject.Admin;
using TasksProject.Models;
using TasksProject.Dtos.Common;
using TasksProject.Context;

namespace TasksProject.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserStoryController : BaseController<UserStoryAdmin, int, UserStory, Dtos.UserStory, BaseFilter>
    {
        public UserStoryController(AssignmentContext context) : base(context)
        {
        }
    }
}
