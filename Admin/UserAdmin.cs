﻿using TasksProject.Dtos.Common;
using TasksProject.Models;

namespace TasksProject.Admin
{
    public class UserAdmin : BaseAdmin<int, User, Dtos.User, BaseFilter>
    {
        public override IQueryable GetQuery(BaseFilter filter)
        {
            throw new NotImplementedException();
        }

        public override User ToEntity(Dtos.User dto)
        {
            throw new NotImplementedException();
        }
    }
}
