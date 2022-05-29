using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuideDomain.Guide
{
    /// <summary>
    /// Guide row data
    /// </summary>
    [Table("GuidesRowsColsData")]
    public class GuideRowColData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Row
        /// </summary>
        [Required]
        [ForeignKey("GuideRowId")]
        public virtual Guid GuideRowId { get; set; }
        public virtual GuideRow GuideRow { get; set; }

        /// <summary>
        /// Col
        /// </summary>
        [Required]
        [ForeignKey("GuideColId")]
        public virtual Guid GuideColId { get; set; }
        public virtual GuideCol GuideCol { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [Required]
        [Column("Value", TypeName = "sql_variant")]
        public virtual object Value { get; set; }

    }
}