using DirectoryDomain.Directory;

namespace RepositoriesLib.Interfaces.Directory
{
    public interface IDirectoryRowColData
    {
        /* DIRECTORY ROW - COL DATA VALUE */

        #region GUIDE ROW - COL DATA VALUE

        /// <summary>
        /// Get all row col data
        /// </summary>
        /// <returns></returns>
        IQueryable<DirectoryRowColData> GetAllDirectoryRowsColsData();

        /// <summary>
        /// Get row col data
        /// </summary>
        /// <param name="rowColId"> Row col id </param>
        /// <returns></returns>
        DirectoryRowColData GetDirectoryRowColColData(Guid rowColId);

        /// <summary>
        /// Get directory row col data value by row id
        /// </summary>
        /// <param name="rowId"> Directory row </param>
        /// <returns></returns>
        DirectoryRowColData GetDirectoryRowColDataValueByRow(Guid rowId);

        /// <summary>
        /// Get directory row col data value by col id
        /// </summary>
        /// <param name="colId"> Directory col id </param>
        /// <returns></returns>
        DirectoryRowColData GetDirectoryRowColDataValueByCol(Guid colId);

        /// <summary>
        /// Add empty row col data
        /// </summary>
        /// <param name="rowColName"> Row col name </param>
        /// <returns></returns>
        DirectoryRowColData AddEmptyDirectoryRowColData(string rowColName);

        /// <summary>
        /// Edit row col data
        /// </summary>
        /// <param name="directoryRowColDataEntity"> Row col entity </param>
        /// <returns></returns>
        DirectoryRowColData EditDirectoryRowColColData(DirectoryRowColData directoryRowColDataEntity);

        /// <summary>
        /// Edit directory row col data value
        /// </summary>
        /// <param name="rowColId"> Gudie row col id </param>
        /// <param name="value"> Directory row col data value </param>
        /// <returns></returns>
        DirectoryRowColData EditDirectoryRowColColDataValue(Guid rowColId, object value);

        /// <summary>
        /// Rename row col data
        /// </summary>
        /// <param name="rowColId"> Row col id </param>
        /// <param name="rowColName"> Row col name </param>
        /// <returns></returns>
        DirectoryRowColData RenameDirectoryRowColData(Guid rowColId, string rowColName);

        /// <summary>
        /// Delete row col data
        /// </summary>
        /// <param name="rowColId"> Row col id </param>
        /// <returns></returns>
        IQueryable<DirectoryRowColData> DeleteDirectoryRowColData(Guid rowColId);

        #endregion
    }
}
