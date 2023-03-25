using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksProject.Admin;
using TasksProject.Context;
using TasksProject.Dtos.Common;

namespace TasksProject.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AssignmentController : BaseController<AssignmentAdmin, int, Models.Assignment, Dtos.Assignment, BaseFilter>
    {
        public AssignmentController(AssignmentContext context) : base(context)
        {
        }

    }
}
