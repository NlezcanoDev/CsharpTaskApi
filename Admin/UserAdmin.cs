using Microsoft.EntityFrameworkCore;
using TasksProject.Dtos.Common;
using TasksProject.Models;

namespace TasksProject.Admin
{
    public class UserAdmin : BaseAdmin<int, User, Dtos.User, BaseFilter>
    {
        public override IQueryable GetQuery(BaseFilter filter)
        {
            return AssignmentContext.User
                .Where(u => string.IsNullOrEmpty(filter.SearchText) ||
                    (u.Name.StartsWith(filter.SearchText, StringComparison.OrdinalIgnoreCase)
                        || u.Lastname.StartsWith(filter.SearchText, StringComparison.OrdinalIgnoreCase)
                    ))
                .AsQueryable();
        }

        public override User ToEntity(Dtos.User dto)
        {
            User user = new User()
            {
                Name = dto.Name,
                Lastname= dto.Lastname,
                Identification = dto.Identification,
                Profile = dto.Profile
            };

            return user;
        }
    }
}
