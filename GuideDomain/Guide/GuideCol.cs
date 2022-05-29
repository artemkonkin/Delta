using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseEntityLib;

namespace GuideDomain.Guide
{
    /// <summary>
    /// Guide col
    /// </summary>
    [Table("GuidesCols")]
    public class GuideCol : IBaseEntity<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Coll name
        /// </summary>
        [Required]
        [MaxLength(64)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Coll data type
        /// </summary>
        public virtual ItemParameterDataType DataType { get; set; }

        /// <summary>
        /// CollData
        /// </summary>
        [ForeignKey("GuideColId")]
        public virtual ICollection<GuideRowColData> GuideRowColData { get; set; }
    }
}