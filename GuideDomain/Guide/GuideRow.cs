using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseEntityLib;

namespace GuideDomain.Guide
{
    /// <summary>
    /// Guide row
    /// </summary>
    [Table("GuidesRows")]
    public class GuideRow : IBaseEntity<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public ICollection<GuideCol> Colls { get; set; }
        public virtual Guid GuideEntityId { get; set; }

        public virtual GuideEntity GuideEntity { get; set; }

        public virtual GuideRowCollData GuideRowCollData { get; set; }
    }
}