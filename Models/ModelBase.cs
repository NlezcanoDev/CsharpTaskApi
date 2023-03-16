using System.ComponentModel.DataAnnotations;

namespace TasksProject.Models
{
    public abstract class ModelBase<TId>
    {
        [Key]
        public virtual TId Id { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        public virtual bool Enabled { get; set; }
        public virtual bool Deleted { get; set; }
        public virtual TId CreatedBy { get; set; }
        public virtual TId UpdatedBy { get; set; }
    }
}
