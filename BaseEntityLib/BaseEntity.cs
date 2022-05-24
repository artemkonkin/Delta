using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseEntityLib
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
    }

    public interface IDeleteEntity
    {
        bool IsDeleted { get; set; }
    }

    public interface IDeleteBaseEntity<TKey> : IDeleteEntity, IBaseEntity<TKey>
    {
    }

    public interface IAuditEntity
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }
    public interface IAuditBaseEntity<TKey> : IAuditEntity, IDeleteBaseEntity<TKey>
    {
    }

    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; set; }
    }

    public abstract class DeleteBaseBaseEntity<TKey> : BaseEntity<TKey>, IDeleteBaseEntity<TKey>
    {
        public bool IsDeleted { get; set; }
    }

    public abstract class AuditBaseBaseEntity<TKey> : DeleteBaseBaseEntity<TKey>, IAuditBaseEntity<TKey>
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}