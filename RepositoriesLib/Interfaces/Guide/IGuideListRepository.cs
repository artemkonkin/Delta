using BaseEntityLib;
using BaseRepositoryLib;
using GuideDomain;

namespace RepositoriesLib.Interfaces.Guide
{
    /// <summary>
    /// Guide list interface
    /// </summary>
    public interface IGuideListRepository : IRepository<GuidesList>
    {
        /// <summary>
        /// Get all guides lists
        /// </summary>
        /// <returns></returns>
        IQueryable<GuidesList> GetAllGuidesLists();

        /// <summary>
        /// Get guide list
        /// </summary>
        /// <param name="guideListId"> Guide list id </param>
        /// <returns></returns>
        Response<GuidesList> GetGuideListById(Guid guideListId);

        /// <summary>
        /// Add guide list with guides
        /// </summary>
        /// <param name="guideListEntity"> Guide list entity </param>
        /// <returns></returns>
        Response<GuidesList> AddGuideList(GuidesList guideListEntity);

        /// <summary>
        /// Add empty guides list
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Response<GuidesList> AddEmptyGuideList(string name);

        /// <summary>
        /// Edit guide list
        /// </summary>
        /// <param name="guideListEntity"> Guide list entity </param>
        /// <returns></returns>
        Response<GuidesList> UpdateGuidesList(GuidesList guideListEntity);

        /// <summary>
        /// Update guide list
        /// </summary>
        /// <param name="id"> Guide list id </param>
        /// <param name="name"> Guide list name </param>
        /// <returns></returns>
        Response<GuidesList> RenameGuideList(Guid id, string name);

        /// <summary>
        /// Delete guide list
        /// </summary>
        /// <param name="id"> Guide list id </param>
        /// <returns></returns>
        Response<GuidesList> DeleteGuideList(Guid id);
    }
}