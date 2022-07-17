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
        public DirectoryCol()
        {
            DirectoryRowColData = new List<DirectoryRowColData>();
        }

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
        public virtual ICollection<DirectoryRowColData> DirectoryRowColData { get; set; }
    }
}