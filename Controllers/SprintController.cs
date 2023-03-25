using Microsoft.AspNetCore.Mvc;
using TasksProject.Admin;
using TasksProject.Context;
using TasksProject.Dtos.Common;

namespace TasksProject.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SprintController : BaseController<SprintAdmin, int, Models.Sprint, Dtos.Sprint, BaseFilter>
    {
        public SprintController(AssignmentContext context) : base(context)
        {
        }
    }
}
