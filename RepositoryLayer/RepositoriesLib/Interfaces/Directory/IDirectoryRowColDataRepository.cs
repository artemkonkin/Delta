using BaseEntityLib;
using BaseRepositoryLib;
using DirectoryDomain.Directory;

namespace RepositoriesLib.Interfaces.Directory
{
    public interface IDirectoryRowColDataRepository : IRepository<DirectoryRowColData>, IDirectoryRepository
    {
        /* DIRECTORY ROW - COL DATA VALUE */

        #region GUIDE ROW - COL DATA VALUE

        /// <summary>
        /// Get all row col data
        /// </summary>
        /// <returns></returns>
        Response<IQueryable<DirectoryRowColData>> GetAllDirectoryRowsColsData();

        /// <summary>
        /// Get row col data
        /// </summary>
        /// <param name="rowColId"> Row col id </param>
        /// <returns></returns>
        Response<DirectoryRowColData> GetDirectoryRowColColData(Guid rowColId);

        /// <summary>
        /// Get directory row col data value by row id
        /// </summary>
        /// <param name="rowId"> Directory row </param>
        /// <returns></returns>
        Response<DirectoryRowColData> GetDirectoryRowColDataValueByRow(Guid rowId);

        /// <summary>
        /// Get directory row col data value by col id
        /// </summary>
        /// <param name="colId"> Directory col id </param>
        /// <returns></returns>
        Response<DirectoryRowColData> GetDirectoryRowColDataValueByCol(Guid colId);

        /// <summary>
        /// Add row col data
        /// </summary>
        /// <param name="directoryRowColDataEntity"> Row col entity </param>
        /// <returns></returns>
        Response<DirectoryRowColData> AddDirectoryRowColData(DirectoryRowColData directoryRowColDataEntity);

        /// <summary>
        /// Edit row col data
        /// </summary>
        /// <param name="directoryRowColDataEntity"> Row col entity </param>
        /// <returns></returns>
        Response<DirectoryRowColData> EditDirectoryRowColColData(DirectoryRowColData directoryRowColDataEntity);

        /// <summary>
        /// Edit directory row col data value
        /// </summary>
        /// <param name="rowColId"> Gudie row col id </param>
        /// <param name="value"> Directory row col data value </param>
        /// <returns></returns>
        Response<DirectoryRowColData> EditDirectoryRowColColDataValue(Guid rowColId, object value);

        /// <summary>
        /// Delete row col data
        /// </summary>
        /// <param name="rowColId"> Row col id </param>
        /// <returns></returns>
        Response<DirectoryRowColData> DeleteDirectoryRowColData(Guid rowColId);

        #endregion
    }
}
