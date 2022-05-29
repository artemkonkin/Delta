using BaseEntityLib;
using GuideDomain;
using GuideDomain.ViewModels;

namespace ServicesLib.Guide
{
    public interface IGuideListService
    {
        IQueryable<GuidesList> GetAllGuidesLists();
        Response<GuidesList> GetGuideListById(Guid guideListId);
        ReadGuideListVm GetGuideListWithData(Guid guideListId);
        Response<GuidesList> AddGuideList(GuidesList guideListEntity);
        Response<GuidesList> UpdateGuideList(GuidesList guideListEntity);
        Response<GuidesList> UpdateGuideList(Guid guideListId, string guideListName);
        Response<GuidesList> DeleteGuideList(Guid guideListId);
    }
}
