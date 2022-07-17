using DirectoryDomain.Directory;

namespace DirectoryDomain.ViewModels;

/// <summary>
/// Directory item view model
/// </summary>
public class DirectoryItemViewModel
{
    /// <summary>
    /// Directory list
    /// </summary>
    public DirectoriesList DirectoriesList { get; set; }

    /// <summary>
    /// Directory entity
    /// </summary>
    public DirectoryEntity DirectoryEntity { get; set; }

    /// <summary>
    /// Directory row
    /// </summary>
    public DirectoryRow DirectoryRow { get; set; }

    /// <summary>
    /// Directory col
    /// </summary>
    public DirectoryCol DirectoryCol { get; set; }

    /// <summary>
    /// Directory row col data
    /// </summary>
    public DirectoryRowColData DirectoryRowColData { get; set; }
}