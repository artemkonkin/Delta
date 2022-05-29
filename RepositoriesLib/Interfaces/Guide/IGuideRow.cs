using GuideDomain.Guide;

namespace RepositoriesLib.Interfaces.Guide
{
    public interface IGuideRow
    {
        /* ROWS */

        #region ROWS

        /// <summary>
        /// Get all guide rows
        /// </summary>
        /// <returns></returns>
        IQueryable<GuideRow> GetAllGuidesRows();

        /// <summary>
        /// Get guide row
        /// </summary>
        /// <param name="id"> Guide row id </param>
        /// <returns></returns>
        GuideRow GetGuideRow(Guid id);

        /// <summary>
        /// Get guide row data
        /// </summary>
        /// <param name="id"> Guide row id </param>
        /// <returns></returns>
        GuideRow GetGuideRowData(Guid id);

        /// <summary>
        /// Get guide row cols list
        /// </summary>
        /// <param name="id"> Guide row id </param>
        /// <returns></returns>
        IQueryable<GuideCol> GetGuideRowCols(Guid id);

        /// <summary>
        /// Add guide row
        /// </summary>
        /// <param name="guideRowEntity"> Guide row entity </param>
        /// <returns></returns>
        GuideRow AddGuideRow(GuideRow guideRowEntity);

        /// <summary>
        /// Add empty guide row
        /// </summary>
        /// <param name="name"> Guide row name </param>
        /// <returns></returns>
        GuideRow AddEmptyGuideRow(string name);

        /// <summary>
        /// Edit guide row
        /// </summary>
        /// <param name="guideRowEntity"> Gudie entity </param>
        /// <returns></returns>
        GuideRow EditGuideRow(GuideRow guideRowEntity);

        /// <summary>
        /// Rename guide row
        /// </summary>
        /// <param name="id"> Guide row id </param>
        /// <param name="name"> Guide row name </param>
        /// <returns></returns>
        GuideRow RenameGuideRow(Guid id, string name);

        /// <summary>
        /// Delete guide row
        /// </summary>
        /// <param name="id"> Guide row id </param>
        /// <returns></returns>
        IQueryable<GuideRow> DeleteGuideRow(Guid id);

        #endregion
    }
}
