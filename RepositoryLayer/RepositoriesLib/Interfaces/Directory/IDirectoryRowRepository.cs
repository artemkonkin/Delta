using BaseEntityLib;
using BaseRepositoryLib;
using DirectoryDomain.Directory;

namespace RepositoriesLib.Interfaces.Directory
{
    public interface IDirectoryRowRepository : IRepository<DirectoryRow>
    {
        /* ROWS */

        #region ROWS

        /// <summary>
        /// Get all directory rows
        /// </summary>
        /// <returns></returns>
        Response<IQueryable<DirectoryRow>> GetAllDirectoriesRows();

        /// <summary>
        /// Get directory row
        /// </summary>
        /// <param name="id"> Directory row id </param>
        /// <returns></returns>
        Response<DirectoryRow> GetDirectoryRow(Guid id);

        /// <summary>
        /// Add directory row
        /// </summary>
        /// <param name="directoryRowEntity"> Directory row entity </param>
        /// <returns></returns>
        Response<DirectoryRow> AddDirectoryRow(DirectoryRow directoryRowEntity);

        /// <summary>
        /// Edit directory row
        /// </summary>
        /// <param name="directoryRowEntity"> Gudie entity </param>
        /// <returns></returns>
        Response<DirectoryRow> EditDirectoryRow(DirectoryRow directoryRowEntity);

        /// <summary>
        /// Delete directory row
        /// </summary>
        /// <param name="id"> Directory row id </param>
        /// <returns></returns>
        Response<DirectoryRow> DeleteDirectoryRow(Guid id);

        #endregion
    }
}
