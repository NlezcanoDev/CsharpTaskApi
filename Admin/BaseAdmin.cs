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

        public BaseAdmin()
        {
            Mapper = new Mapper(Bootstrapper.MapperConfiguration);
        }

        public BaseAdmin(AssignmentContext context) : this()
        {
            AssignmentContext = context;
        }

        public virtual IList<TD> GetAll()
        {
            var entities = (IList<TE>)AssignmentContext.Set<TE>().AsQueryable().OfType<TE>().ToList();
            return Mapper.Map<IList<TE>, IList<TD>>(entities);
        }

        public virtual TD GetById(TID id)
        {
            var entity = AssignmentContext.Set<TE>().Find(id);
            return Mapper.Map<TE, TD>(entity);
        }

        public virtual PaginatedResponse<TD> GetByFilter(
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

            return new PaginatedResponse<TD>
            {
                Count = query.Count(),
                Data = Mapper.Map<IList<TE>, IList<TD>>(response)
            };
        }

        public virtual TD Create(TD dto)
        {
            var entity = ToEntity(dto);
            entity.CreateDate = DateTime.Now;

            AssignmentContext.Set<TE>().Add(entity);
            AssignmentContext.SaveChanges();

            return Mapper.Map<TE, TD>(entity);
        }

        public virtual TD Update(TD dto)
        {
            var entity = ToEntity(dto);

            entity.UpdateDate = DateTime.Now;

            AssignmentContext.Update<TE>(entity);
            AssignmentContext.SaveChanges();

            return Mapper.Map<TE, TD>(entity);
        }

        public virtual void Delete(TID id)
        {
            var entity = AssignmentContext.Set<TE>().Find(id);

            if (entity is null) throw new FileNotFoundException("No se pudo recuperar la Entidad");

            entity.UpdateDate = DateTime.Now;
            entity.Deleted = true;

            AssignmentContext.SaveChanges();
        }


        #region Abstract Methods

        public abstract TE ToEntity(TD dto);
        public abstract IQueryable GetQuery(TF filter);
        #endregion
    }
}
