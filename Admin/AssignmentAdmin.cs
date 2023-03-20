using TasksProject.Dtos.Common;
using TasksProject.Models;

namespace TasksProject.Admin
{
    public class AssignmentAdmin : BaseAdmin<int, Assignment, Dtos.Assignment, BaseFilter>
    {
        public override IQueryable GetQuery(BaseFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Assignment ToEntity(Dtos.Assignment dto)
        {
            throw new NotImplementedException();
        }
    }
}
