using GuideDomain.Guide;

namespace RepositoriesLib.Interfaces.Guide
{
    public interface IGuide
    {
        /* GUIDES */

        #region GUIDES

        /// <summary>
        /// Get all guides
        /// </summary>
        /// <returns></returns>
        IQueryable<GuideEntity> GetAllGuides();

        /// <summary>
        /// Get guide
        /// </summary>
        /// <param name="id"> Guide id </param>
        /// <returns></returns>
        GuideEntity GetGuide(Guid id);

        /// <summary>
        /// Add guide
        /// </summary>
        /// <param name="guideEntity"> Guide entity </param>
        /// <returns></returns>
        GuideEntity AddGuide(GuideEntity guideEntity);

        /// <summary>
        /// Add empty guide
        /// </summary>
        /// <param name="name"> Guide name </param>
        /// <returns></returns>
        GuideEntity AddEmptyGuide(string name);

        /// <summary>
        /// Edit guide
        /// </summary>
        /// <param name="guideEntity"> Guide entity </param>
        /// <returns></returns>
        GuideEntity EditGuide(GuideEntity guideEntity);

        /// <summary>
        /// Rename guide
        /// </summary>
        /// <param name="id"> Guide id </param>
        /// <param name="name"> Gudie name </param>
        /// <returns></returns>
        GuideEntity RenameGuide(Guid id, string name);

        /// <summary>
        /// Delete guide
        /// </summary>
        /// <param name="id"> Guide id </param>
        /// <returns></returns>
        IQueryable<GuideEntity> DeleteGuide(Guid id);

        #endregion
    }
}
