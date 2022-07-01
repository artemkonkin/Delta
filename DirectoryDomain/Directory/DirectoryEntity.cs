using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseEntityLib;

namespace DirectoryDomain.Directory
{
    /// <summary>
    /// Directory entity
    /// </summary>
    [Table("Directories")]
    public class DirectoryEntity : IBaseEntity<Guid>
    {
        public DirectoryEntity()
        {
            DirectoryRows = new List<DirectoryRow>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Directory name
        /// </summary>
        [Required]
        [MaxLength(128)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Directory list
        /// </summary>
        [Required]
        [ForeignKey("DirectoryListId")]
        public virtual Guid GuideListId { get; set; }
        public virtual DirectoriesList DirectoryList { get; set; }

        /// <summary>
        /// Rows
        /// </summary>
        [ForeignKey("DirectoryRowId")]
        public virtual ICollection<DirectoryRow> DirectoryRows { get; set; }
    }
}