using GuideDomain.Guide;

namespace RepositoriesLib.Interfaces.Guide
{
    public interface IGuideRowColData
    {
        /* GUIDE ROW - COL DATA VALUE */

        #region GUIDE ROW - COL DATA VALUE

        /// <summary>
        /// Get all row col data
        /// </summary>
        /// <returns></returns>
        IQueryable<GuideRowColData> GetAllGuideRowsColsData();

        /// <summary>
        /// Get row col data
        /// </summary>
        /// <param name="rowColId"> Row col id </param>
        /// <returns></returns>
        GuideRowColData GetGuideRowColColData(Guid rowColId);

        /// <summary>
        /// Get guide row col data value by row id
        /// </summary>
        /// <param name="rowId"> Guide row </param>
        /// <returns></returns>
        GuideRowColData GetGuideRowColDataValueByRow(Guid rowId);

        /// <summary>
        /// Get guide row col data value by col id
        /// </summary>
        /// <param name="colId"> Guide col id </param>
        /// <returns></returns>
        GuideRowColData GetGuideRowColDataValueByCol(Guid colId);

        /// <summary>
        /// Add empty row col data
        /// </summary>
        /// <param name="rowColName"> Row col name </param>
        /// <returns></returns>
        GuideRowColData AddEmptyGuideRowColData(string rowColName);

        /// <summary>
        /// Edit row col data
        /// </summary>
        /// <param name="guideRowColDataEntity"> Row col entity </param>
        /// <returns></returns>
        GuideRowColData EditGuideRowColColData(GuideRowColData guideRowColDataEntity);

        /// <summary>
        /// Edit guide row col data value
        /// </summary>
        /// <param name="rowColId"> Gudie row col id </param>
        /// <param name="value"> Guide row col data value </param>
        /// <returns></returns>
        GuideRowColData EditGuideRowColColDataValue(Guid rowColId, object value);

        /// <summary>
        /// Rename row col data
        /// </summary>
        /// <param name="rowColId"> Row col id </param>
        /// <param name="rowColName"> Row col name </param>
        /// <returns></returns>
        GuideRowColData RenameGuideRowColData(Guid rowColId, string rowColName);

        /// <summary>
        /// Delete row col data
        /// </summary>
        /// <param name="rowColId"> Row col id </param>
        /// <returns></returns>
        IQueryable<GuideRowColData> DeleteGuideRowColData(Guid rowColId);

        #endregion
    }
}
