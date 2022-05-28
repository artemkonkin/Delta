using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseEntityLib;

namespace GuideDomain.Guide
{
    /// <summary>
    /// Guide entity
    /// </summary>
    public class GuideEntity : IBaseEntity<Guid>
    {
        public GuideEntity()
        {
            GuideRows = new List<GuideRow>();
            GuideCols = new List<GuideCol>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Guide name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Guide list
        /// </summary>
        public virtual Guid GuidesListId { get; set; }
        public virtual GuidesList GuidesList { get; set; }

        /// <summary>
        /// Rows
        /// </summary>
        public virtual IList<GuideRow> GuideRows { get; set; }

        /// <summary>
        /// Colls
        /// </summary>
        public virtual IList<GuideCol> GuideCols { get; set; }
    }
}