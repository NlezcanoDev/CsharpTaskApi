using Microsoft.EntityFrameworkCore;
using TasksProject.Context;
using TasksProject.Dtos.Common;
using TasksProject.Models;

namespace TasksProject.Admin
{
    public class UserStoryAdmin : BaseAdmin<int, UserStory, Dtos.UserStory, BaseFilter>
    {

        public override IQueryable GetQuery(BaseFilter filter)
        {
            return AssignmentContext.UserStory
                    .Include(us => us.Sprint)
                    .Where(us => string.IsNullOrEmpty(filter.SearchText) || us.Title.StartsWith(filter.SearchText))
                    .AsQueryable();
        }

        public override UserStory ToEntity(Dtos.UserStory dto)
        {
            UserStory userStory = new UserStory()
            {
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority,
                SprintId = dto.SprintId
            };

            return userStory;
        }
    }
}
