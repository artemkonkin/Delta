using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuideDomain.Guide
{
    /// <summary>
    /// Guide row data
    /// </summary>
    public class GuideRowCollData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Row
        /// </summary>
        public virtual Guid RowId { get; set; }
        public virtual GuideRow GuideRow { get; set; }

        /// <summary>
        /// Col
        /// </summary>
        public virtual Guid CollId { get; set; }
        public virtual GuideCol GuideCol { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public virtual object Value { get; set; }

    }
}