using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseEntityLib;
using GuideDomain.Guide;

namespace GuideDomain
{
    /// <summary>
    /// Guides list
    /// </summary>
    public class GuidesList : IBaseEntity<Guid>
    {
        public GuidesList()
        {
            GuideEntities = new List<GuideEntity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Guide name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Guides list
        /// </summary>
        public virtual IList<GuideEntity> GuideEntities { get; set; }
    }
}