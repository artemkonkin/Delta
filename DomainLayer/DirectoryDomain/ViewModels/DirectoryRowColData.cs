using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DirectoryDomain.Directory;

namespace DirectoryDomain.ViewModels
{
    /// <summary>
    /// Directory row data
    /// </summary>
    [Table("DirectoriesRowsColsData")]
    public class DirectoryRowColData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Row
        /// </summary>
        [Required]
        [ForeignKey("DirectoryRowId")]
        public virtual Guid DirectoryRowId { get; set; }
        public virtual DirectoryRow DirectoryRow { get; set; }

        /// <summary>
        /// Col
        /// </summary>
        [Required]
        [ForeignKey("DirectoryColId")]
        public virtual Guid DirectoryColId { get; set; }
        public virtual DirectoryCol DirectoryCol { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [Required]
        [Column("Value", TypeName = "sql_variant")]
        public virtual object Value { get; set; }

    }
}