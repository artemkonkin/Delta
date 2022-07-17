using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseEntityLib;

namespace DirectoryDomain.Directory
{
    /// <summary>
    /// Directory row
    /// </summary>
    [Table("DirectoriesRows")]
    public class DirectoryRow : IBaseEntity<Guid>
    {
        public DirectoryRow()
        {
            DirectoryRowColData = new List<DirectoryRowColData>();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Cols
        /// </summary>
        public virtual ICollection<DirectoryCol> Cols { get; set; }

        /// <summary>
        /// Directory
        /// </summary>
        [Required]
        [ForeignKey("DirectoryId")]
        public Guid DirectoryId { get; set; }
        public virtual DirectoryEntity Directory { get; set; }

        /// <summary>
        /// Row - Col data
        /// </summary>
        [ForeignKey("DirectoryRowColId")]
        public virtual ICollection<DirectoryRowColData> DirectoryRowColData { get; set; }
    }
}