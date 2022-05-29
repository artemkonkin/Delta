using BaseRepositoryLib;
using GuideDomain;

namespace RepositoriesLib.Interfaces.Guide
{
    /// <summary>
    /// Guide list interface
    /// </summary>
    public interface IGuideRepository : IGuidesList, IGuide, IGuideColumn, IGuideRow, IGuideRowColData, IRepository<GuidesList>
    {
        // 
    }
}