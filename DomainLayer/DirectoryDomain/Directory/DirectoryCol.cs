using BaseEntityLib;
using EnumsLib;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectoryDomain.Directory
{
    /// <summary>
    /// Directory col
    /// </summary>
    [Table("DirectoryCols")]
    public class DirectoryCol : IBaseEntity<Guid>
    {
        [Key]
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
        [ForeignKey("DirectoryColId")]
        public virtual ICollection<DirectoryRowColData> DirectoryRowColData { get; set; }
    }
}