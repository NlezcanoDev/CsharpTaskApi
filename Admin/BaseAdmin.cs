using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using TasksProject.Context;
using TasksProject.Dtos.Common;
using TasksProject.Models;

namespace TasksProject.Admin
{
    public abstract class BaseAdmin<TID, TE, TD, TF>
        where TF : BaseFilter
        where TE : ModelBase<TID>
    {
        public AssignmentContext AssignmentContext;
        public IMapper Mapper;
        public IHttpContextAccessor ContextAccessor;

        public BaseAdmin()
        {
            Mapper = new Mapper(AutoMapper.MapperConfiguration);
        }

        public BaseAdmin(AssignmentContext context) : this()
        {
            AssignmentContext = context;
        }

        public virtual TD GetById(TID id)
        {
            var entity = AssignmentContext.Set<TE>().Find(id);
            return Mapper.Map<TE, TD>(entity);
        }

        public virtual IList<TD> GetAll()
        {
            var entities = (IList<TE>)AssignmentContext.Set<TE>().AsQueryable().OfType<TE>().ToList();
            return Mapper.Map<IList<TE>, IList<TD>>(entities);
        }

        /*public virtual PagedListResponse<TD> GetByFilter(
            TF filter,
            Func<IQueryable<TE>, IIncludableQueryable<TE, object>> include = null,
            Func<IQueryable<TE>, IOrderedQueryable<TE>> orderBy = null)
        {
            var query = GetQuery(filter).OfType<TE>();
            int pageSize = filter.PageSize ??= 10;
            int currentPage = filter.CurrentPage ??= 1;

            List<TE> response = query.Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();

            if (include != null) query = include(query);
            if (orderBy != null) query = orderBy(query);

            return new PagedListResponse<TD>
            {
                Count = query.Count(),
                Data = Mapper.Map<IList<TE>, IList<TD>>(response)
            };
        }*/

        public virtual TD Create(TD dto)
        {
            var entity = ToEntity(dto);
            throw new NotImplementedException();
        }

        public virtual TD Update(TD dto)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TID id)
        {
            throw new NotImplementedException();
        }

        public virtual object GetDataEdit() => null;

        #region Abstract Methods

        public abstract TE ToEntity(TD dto);
        public abstract IQueryable GetQuery(TF filter);
        #endregion
    }
}
