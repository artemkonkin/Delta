using BaseEntityLib;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EnumsLib;

namespace DirectoryDomain.Directory
{
    /// <summary>
    /// Directory col
    /// </summary>
    [Table("DirectoryCols")]
    public class DirectoryCol : IBaseEntity<Guid>
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
        [ForeignKey("DirectoryColId")]
        public virtual ICollection<ViewModels.DirectoryRowColData> DirectoryRowColData { get; set; }
    }
}