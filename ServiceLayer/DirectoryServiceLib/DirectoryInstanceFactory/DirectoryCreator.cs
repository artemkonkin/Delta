using DirectoryDomain.Directory;
using DirectoryServiceLib.Interface.DirectoryInstanceFactory;

namespace DirectoryServiceLib.DirectoryInstanceFactory;

/// <summary>
/// Directory creator
/// </summary>
public class DirectoryCreator : DirectoryFactory
{
    public DirectoryCreator(IDirectoryInstance directoryInstance)
    {
        DirectoryInstance = directoryInstance;
        DirectoryEntity = new DirectoryEntity();
    }

    /// <summary>
    /// Directory instance
    /// </summary>
    private IDirectoryInstance DirectoryInstance { get; set; }

    /// <summary>
    /// Directory entity
    /// </summary>
    private DirectoryEntity DirectoryEntity { get; set; }

    /// <summary>
    /// Create directory factory method
    /// </summary>
    /// <returns></returns>
    public override IDirectoryInstance CreateDirectoryFactoryMethod(DirectoryEntity directoryEntity)
    {
        var newDirectoryEntity = new DirectoryEntity
        {
            Name = null,
            DirectoryListId = default,
            DirectoryList = null,
            DirectoryRows = null
        };

        DirectoryEntity = newDirectoryEntity;

        DirectoryInstance.SetCurrentDirectory(DirectoryEntity);

        return DirectoryInstance;
    }
}