using BaseEntityLib;
using BaseRepositoryLib;
using DirectoryDomain.Directory;

namespace RepositoriesLib.Interfaces.Directory
{
    public interface IDirectoryRowRepository : IRepository<DirectoryRow>, IDirectoryRepository
    {
        /* ROWS */

        #region ROWS

        /// <summary>
        /// Get all directory rows
        /// </summary>
        /// <returns></returns>
        Response<IQueryable<DirectoryCol>> GetAllDirectoriesRows();

        /// <summary>
        /// Get directory row
        /// </summary>
        /// <param name="id"> Directory row id </param>
        /// <returns></returns>
        Response<DirectoryRow> GetDirectoryRow(Guid id);

        /// <summary>
        /// Get directory row data
        /// </summary>
        /// <param name="id"> Directory row id </param>
        /// <returns></returns>
        Response<DirectoryRow> GetDirectoryRowData(Guid id);

        /// <summary>
        /// Get directory row cols list
        /// </summary>
        /// <param name="id"> Directory row id </param>
        /// <returns></returns>
        Response<IQueryable<DirectoryCol>> GetDirectoryRowCols(Guid id);

        /// <summary>
        /// Add directory row
        /// </summary>
        /// <param name="directoryRowEntity"> Directory row entity </param>
        /// <returns></returns>
        Response<DirectoryRow> AddDirectoryRow(DirectoryRow directoryRowEntity);

        /// <summary>
        /// Add empty directory row
        /// </summary>
        /// <param name="name"> Directory row name </param>
        /// <returns></returns>
        Response<DirectoryRow> AddEmptyDirectoryRow(string name);

        /// <summary>
        /// Edit directory row
        /// </summary>
        /// <param name="directoryRowEntity"> Gudie entity </param>
        /// <returns></returns>
        Response<DirectoryRow> EditDirectoryRow(DirectoryRow directoryRowEntity);

        /// <summary>
        /// Rename directory row
        /// </summary>
        /// <param name="id"> Directory row id </param>
        /// <param name="name"> Directory row name </param>
        /// <returns></returns>
        Response<DirectoryRow> RenameDirectoryRow(Guid id, string name);

        /// <summary>
        /// Delete directory row
        /// </summary>
        /// <param name="id"> Directory row id </param>
        /// <returns></returns>
        Response<DirectoryRow> DeleteDirectoryRow(Guid id);

        #endregion
    }
}
