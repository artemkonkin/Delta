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

        /// <summary>
        /// Cols
        /// </summary>
        public virtual ICollection<GuideCol> Cols { get; set; }

        /// <summary>
        /// Guide
        /// </summary>
        [Required]
        [ForeignKey("GuideId")]
        public Guid GuideId { get; set; }
        public virtual GuideEntity Guide { get; set; }

        /// <summary>
        /// Row - Col data
        /// </summary>
        [ForeignKey("GuideRowId")]
        public virtual ICollection<GuideRowColData> GuideRowColData { get; set; }
    }
}