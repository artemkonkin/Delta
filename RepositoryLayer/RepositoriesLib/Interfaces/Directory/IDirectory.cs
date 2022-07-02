using DirectoryDomain.Directory;

namespace RepositoriesLib.Interfaces.Directory
{
    public interface IDirectory
    {
        /* GUIDES */

        #region DIRRECTORIES

        /// <summary>
        /// Get all directories
        /// </summary>
        /// <returns></returns>
        IQueryable<DirectoryEntity> GetAllDirectories();

        /// <summary>
        /// Get directory
        /// </summary>
        /// <param name="id"> Directory id </param>
        /// <returns></returns>
        DirectoryEntity GetDirectory(Guid id);

        /// <summary>
        /// Add directory
        /// </summary>
        /// <param name="directoryEntity"> Directory entity </param>
        /// <returns></returns>
        DirectoryEntity AddDirectory(DirectoryEntity directoryEntity);

        /// <summary>
        /// Add empty directory
        /// </summary>
        /// <param name="name"> Directory name </param>
        /// <returns></returns>
        DirectoryEntity AddEmptyDirectory(string name);

        /// <summary>
        /// Edit directory
        /// </summary>
        /// <param name="directoryEntity"> Directory entity </param>
        /// <returns></returns>
        DirectoryEntity EditDirectory(DirectoryEntity directoryEntity);

        /// <summary>
        /// Rename directory
        /// </summary>
        /// <param name="id"> Directory id </param>
        /// <param name="name"> Directory name </param>
        /// <returns></returns>
        DirectoryEntity RenameDirectory(Guid id, string name);

        /// <summary>
        /// Delete directory
        /// </summary>
        /// <param name="id"> Directory id </param>
        /// <returns></returns>
        IQueryable<DirectoryEntity> DeleteDirectory(Guid id);

        #endregion
    }
}
