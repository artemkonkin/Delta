using BaseEntityLib;
using BaseRepositoryLib;
using DirectoryDomain.Directory;

namespace RepositoriesLib.Interfaces.Directory
{
    public interface IDirectoryEntityRepository : IRepository<DirectoryEntity>, IDirectoryRepository
    {
        /* GUIDES */

        #region DIRRECTORIES

        /// <summary>
        /// Get all directories
        /// </summary>
        /// <returns></returns>
        Response<IQueryable<DirectoryEntity>> GetAllDirectoriesEntities();

        /// <summary>
        /// Get directory
        /// </summary>
        /// <param name="id"> Directory id </param>
        /// <returns></returns>
        Response<DirectoryEntity> GetDirectoryEntity(Guid id);

        /// <summary>
        /// Add directory
        /// </summary>
        /// <param name="directoryEntity"> Directory entity </param>
        /// <returns></returns>
        Response<DirectoryEntity> AddDirectoryEntity(DirectoryEntity directoryEntity);

        /// <summary>
        /// Add empty directory
        /// </summary>
        /// <param name="name"> Directory name </param>
        /// <returns></returns>
        Response<DirectoryEntity> AddEmptyDirectoryEntity(string name);

        /// <summary>
        /// Edit directory
        /// </summary>
        /// <param name="directoryEntity"> Directory entity </param>
        /// <returns></returns>
        Response<DirectoryEntity> EditDirectory(DirectoryEntity directoryEntity);

        /// <summary>
        /// Rename directory
        /// </summary>
        /// <param name="id"> Directory id </param>
        /// <param name="name"> Directory name </param>
        /// <returns></returns>
        Response<DirectoryEntity> RenameDirectoryEntity(Guid id, string name);

        /// <summary>
        /// Delete directory
        /// </summary>
        /// <param name="id"> Directory id </param>
        /// <returns></returns>
        Response<DirectoryEntity> DeleteDirectoryEntity(Guid id);

        #endregion
    }
}
