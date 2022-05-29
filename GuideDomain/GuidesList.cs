using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseEntityLib;
using GuideDomain.Guide;

namespace GuideDomain
{
    /// <summary>
    /// Guides list
    /// </summary>
    [Table("GuidesLists")]
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
        [Required]
        [MaxLength(128)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Guides list
        /// </summary>
        [ForeignKey("GuideListId")]
        public virtual ICollection<GuideEntity> GuideEntities { get; set; }
    }
}