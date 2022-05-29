using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseEntityLib;

namespace GuideDomain.Guide
{
    /// <summary>
    /// Guide entity
    /// </summary>
    [Table("Guides")]
    public class GuideEntity : IBaseEntity<Guid>
    {
        public GuideEntity()
        {
            GuideRows = new List<GuideRow>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Guide name
        /// </summary>
        [Required]
        [MaxLength(128)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Guide list
        /// </summary>
        [Required]
        [ForeignKey("GuideListId")]
        public virtual Guid GuideListId { get; set; }
        public virtual GuidesList GuideList { get; set; }

        /// <summary>
        /// Rows
        /// </summary>
        [ForeignKey("GuideRowId")]
        public virtual ICollection<GuideRow> GuideRows { get; set; }
    }
}