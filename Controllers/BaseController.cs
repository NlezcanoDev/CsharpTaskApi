using Microsoft.AspNetCore.Mvc;
using TasksProject.Admin;
using TasksProject.Context;
using TasksProject.Dtos.Common;
using TasksProject.Models;

namespace TasksProject.Controllers
{
    public abstract class BaseController<TA, TID, TE, TD, TF> : ControllerBase
        where TA : BaseAdmin<TID, TE, TD, TF>, new()
        where TF : BaseFilter
        where TE : ModelBase<TID>
        {
            #region Properties

            protected TA _admin;

            #endregion

            public BaseController(AssignmentContext context, IHttpContextAccessor accessor)
            {
                _admin = new TA();
                _admin.AssignmentContext = context;
                _admin.ContextAccessor = accessor;
            }

            //[HttpGet]
            //public ActionResult<PagedListResponse<TD>> Get([FromQuery] TF filter)
            //{
            //    return _admin.GetByFilter(filter);
            //}

            [HttpGet("{id}")]
            public ActionResult<TD> Get(TID id)
            {
                return _admin.GetById(id);
            }

            [HttpPost]
            public virtual TD Post([FromBody] TD dto)
            {
                return _admin.Create(dto);
            }

            [HttpPut]
            public virtual TD Put(TD dto)
            {
                return _admin.Update(dto);
            }

            [HttpDelete("{id}")]
            public void Delete(TID id)
            {
                _admin.Delete(id);
            }

            [HttpGet("init/dataEdit")]
            public ActionResult<object> DataEdit()
            {
                return _admin.GetDataEdit();
            }
    }
}
