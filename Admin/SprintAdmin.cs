using Microsoft.EntityFrameworkCore;
using TasksProject.Dtos.Common;
using TasksProject.Models;

namespace TasksProject.Admin
{
    public class SprintAdmin : BaseAdmin<int, Sprint, Dtos.Sprint, BaseFilter>
    {
        public override IQueryable GetQuery(BaseFilter filter)
        {
            return AssignmentContext.Sprint
                .Where(s => string.IsNullOrEmpty(filter.SearchText) || s.Description.StartsWith(filter.SearchText, StringComparison.OrdinalIgnoreCase))
                .AsQueryable();
        }

        public override Sprint ToEntity(Dtos.Sprint dto)
        {
            Sprint sprint = new Sprint()
            {
                Description= dto.Description,
                StartDate= dto.StartDate,
                EndDate= dto.EndDate
            };
            return sprint;
        }
    }
}
