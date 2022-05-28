using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseEntityLib;

namespace GuideDomain.Guide
{
    /// <summary>
    /// Guide col
    /// </summary>
    public class GuideCol : IBaseEntity<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Coll name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Coll data type
        /// </summary>
        public virtual ItemParameterDataType DataType { get; set; }

        /// <summary>
        /// Guide id
        /// </summary>
        public virtual Guid GuideEntityId { get; set; }
        public virtual GuideEntity GuideEntity { get; set; }

        /// <summary>
        /// CollData
        /// </summary>
        public virtual GuideRowCollData GuideRowCollData { get; set; }
    }
}