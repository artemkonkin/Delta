using DirectoryDomain.Directory;
using DirectoryServiceLib.Interface.DirectoryInstanceFactory;

namespace DirectoryServiceLib.DirectoryInstanceFactory;

/// <summary>
/// Directory factory
/// </summary>
public abstract class DirectoryFactory
{
    /// <summary>
    /// Create directory factory method
    /// </summary>
    /// <returns></returns>
    public abstract IDirectoryInstance CreateDirectoryFactoryMethod(DirectoryEntity directoryEntity);
}