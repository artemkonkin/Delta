using DirectoryDomain.Directory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseEntityLib;

namespace DirectoryDomain;

/// <summary>
/// Directories list
/// </summary>
[Table("DirectoriesLists")]
public class DirectoriesList : IBaseEntity<Guid>
{
    public DirectoriesList()
    {
        DirectoryEntities = new List<DirectoryEntity>();
    }

    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Directory name
    /// </summary>
    [Required]
    [MaxLength(128)]
    public virtual string Name { get; set; }

    /// <summary>
    /// Directories list
    /// </summary>
    [ForeignKey("DirectoryListId")]
    public virtual ICollection<DirectoryEntity> DirectoryEntities { get; set; }
}