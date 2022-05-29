using GuideDomain;

namespace RepositoriesLib.Interfaces.Guide
{
    public interface IGuidesList
    {
        #region GUIDES LISTS

        /// <summary>
        /// Get all guides lists
        /// </summary>
        /// <returns></returns>
        IQueryable<GuidesList> GetAllGuidesLists();

        /// <summary>
        /// Get guide list
        /// </summary>
        /// <param name="id"> Guide list id </param>
        /// <returns></returns>
        GuidesList GetGuideList(Guid id);

        /// <summary>
        /// Add guide list with guides
        /// </summary>
        /// <param name="guideListEntity"> Guide list entity </param>
        /// <returns></returns>
        GuidesList AddGuideList(GuidesList guideListEntity);

        /// <summary>
        /// Add empty guides list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        GuidesList AddEmptyGuideList(string name);

        /// <summary>
        /// Edit guide list
        /// </summary>
        /// <param name="guideListEntity"> Guide list entity </param>
        /// <returns></returns>
        GuidesList EditGuidesList(GuidesList guideListEntity);

        /// <summary>
        /// Update guide list
        /// </summary>
        /// <param name="id"> Guide list id </param>
        /// <param name="name"> Guide list name </param>
        /// <returns></returns>
        GuidesList RenameGuideList(Guid id, string name);

        /// <summary>
        /// Delete guide list
        /// </summary>
        /// <param name="id"> Guide list id </param>
        /// <returns></returns>
        IQueryable<GuidesList> DeleteGuideList(Guid id);

        #endregion
    }
}
