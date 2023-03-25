using Microsoft.AspNetCore.Mvc;
using TasksProject.Admin;
using TasksProject.Context;
using TasksProject.Dtos.Common;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : BaseController<UserAdmin, int, User, Dtos.User, BaseFilter>
    {
        public UserController(AssignmentContext context) : base(context)
        {
        }
    }
}
