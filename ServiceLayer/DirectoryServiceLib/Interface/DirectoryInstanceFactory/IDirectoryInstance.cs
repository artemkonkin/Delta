using DirectoryDomain.Directory;

namespace DirectoryServiceLib.Interface.DirectoryInstanceFactory;

/// <summary>
/// Directory interface
/// </summary>
public interface IDirectoryInstance
{
    /// <summary>
    /// Get current directory
    /// </summary>
    /// <returns></returns>
    DirectoryEntity GetCurrentDirectory();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="directoryEntity"></param>
    /// <returns></returns>
    DirectoryEntity SetCurrentDirectory(DirectoryEntity directoryEntity);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="directoryEntity"></param>
    /// <returns></returns>
    DirectoryEntity EditCurrentDirectory(DirectoryEntity directoryEntity);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    DirectoryEntity ClearCurrentDirectory(Guid id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="directoryEntity"></param>
    /// <returns></returns>
    DirectoryEntity SaveDirectoryEntityToDataBase(DirectoryEntity directoryEntity);
}