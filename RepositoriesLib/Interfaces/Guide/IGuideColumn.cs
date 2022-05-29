using GuideDomain.Guide;

namespace RepositoriesLib.Interfaces.Guide
{
    public interface IGuideColumn
    {
        /* COLUMNS */

        #region COLUMNS

        /// <summary>
        /// Get all guide cols
        /// </summary>
        /// <returns></returns>
        IQueryable<GuideCol> GetAllGuidesCols();

        /// <summary>
        /// Get guide col
        /// </summary>
        /// <param name="id"> Col id </param>
        /// <returns></returns>
        GuideCol GetGuideCol(Guid id);

        /// <summary>
        /// Add guide col
        /// </summary>
        /// <param name="guideColEntity"> Guide col entity </param>
        /// <returns></returns>
        GuideCol AddGuideCol(GuideCol guideColEntity);

        /// <summary>
        /// Add emty guide col
        /// </summary>
        /// <param name="name"> Guide col name </param>
        /// <returns></returns>
        GuideCol AddEmptyGuideCol(string name);

        /// <summary>
        /// Edit guide col
        /// </summary>
        /// <param name="guideColEntity"> Guide col entity </param>
        /// <returns></returns>
        GuideCol EditGuideCol(GuideCol guideColEntity);

        /// <summary>
        /// Rename guide col
        /// </summary>
        /// <param name="id"> Guide col id </param>
        /// <param name="name"> Guide col name </param>
        /// <returns></returns>
        GuideCol RenameGuideCol(Guid id, string name);

        /// <summary>
        /// Delete guide col
        /// </summary>
        /// <param name="id"> Guide col id </param>
        /// <returns></returns>
        IQueryable<GuideCol> DeleteGuideCol(Guid id);

        #endregion
    }
}
