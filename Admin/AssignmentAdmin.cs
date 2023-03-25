using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using TasksProject.Dtos.Common;
using TasksProject.Models;

namespace TasksProject.Admin
{
    public class AssignmentAdmin : BaseAdmin<int, Assignment, Dtos.Assignment, BaseFilter>
    {
        public override IQueryable GetQuery(BaseFilter filter)
        {
           return AssignmentContext.Assignment
                .Include(a => a.UserStory)
                .Where(a => string.IsNullOrEmpty(filter.SearchText) || a.Title.StartsWith(filter.SearchText, StringComparison.OrdinalIgnoreCase))
                .AsQueryable();
        }

        public override Assignment ToEntity(Dtos.Assignment dto)
        {
            Assignment assignment = new Assignment()
            {
                Title= dto.Title,
                Description= dto.Description,
                Category= dto.Category,
                UserStoryId= dto.UserStoryId,
                Status= dto.Status,
                AssignTo = dto.AssignTo,
            };

            return assignment;
        }
    }
}
