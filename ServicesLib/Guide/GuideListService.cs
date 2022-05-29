using BaseEntityLib;
using BaseServiceLib;
using GuideDomain;
using GuideDomain.ViewModels;
using Microsoft.AspNetCore.Identity;
using RepositoriesLib;
using UnitOfWorkLib;
using UserDomain;

namespace ServicesLib.Guide
{
    internal class GuideListService : BaseService
    {
        private readonly GuideRepository _guideRepository;

        public GuideListService(IUnitOfWork uow, UserManager<AppUser> userManager, GuideRepository guideRepository) : base(uow, userManager)
        {
            _guideRepository = guideRepository;
        }

        /// <summary>
        /// Get all guides lists
        /// </summary>
        /// <returns></returns>
        public IQueryable<GuidesList> GetAllGuidesLists()
        {
            return _guideRepository.GetAllGuidesLists();
        }

        /// <summary>
        /// Get guide list by id
        /// </summary>
        /// <param name="guideListId"> Guide list id </param>
        /// <returns></returns>
        public Response<GuidesList> GetGuideListById(Guid guideListId)
        {
            var guideList = _guideRepository.GetGuideListById(guideListId);
            return guideList;
        }

        /// <summary>
        /// Get guide list with data
        /// </summary>
        /// <param name="guideListId"> Guide list id </param>
        /// <returns></returns>
        public ReadGuideListVm GetGuideListWithData(Guid guideListId)
        {
            //todo Доделать
            var guideList = _guideRepository.GetGuideListById(guideListId);

            return new ReadGuideListVm
            {
                Id = guideList.Data.Id,
                Name = guideList.Data.Name,
                Guides = guideList.Data.GuideEntities
            };
        }

        /// <summary>
        /// Add guide list
        /// </summary>
        /// <param name="guideListEntity"> Guide list entity </param>
        /// <returns></returns>
        public Response<GuidesList> AddGuideList(GuidesList guideListEntity)
        {
            var result = _guideRepository.AddGuideList(guideListEntity);
            return result;
        }

        /// <summary>
        /// Update guide list
        /// </summary>
        /// <param name="guideListEntity"> Guide list entity </param>
        /// <returns></returns>
        public Response<GuidesList> UpdateGuideList(GuidesList guideListEntity)
        {
            var result = _guideRepository.UpdateGuidesList(guideListEntity);
            return result;
        }

        /// <summary>
        /// Rename guide list
        /// </summary>
        /// <param name="guideListId"> Guide list id </param>
        /// <param name="guideListName"> Guide list name </param>
        /// <returns></returns>
        public Response<GuidesList> UpdateGuideList(Guid guideListId, string guideListName)
        {
            var result = _guideRepository.RenameGuideList(guideListId, guideListName);
            return result;
        }

        /// <summary>
        /// Delete guide list
        /// </summary>
        /// <param name="guideListId"> Guide list id </param>
        /// <returns></returns>
        public Response<GuidesList> DeleteGuideList(Guid guideListId)
        {
            var result = _guideRepository.DeleteGuideList(guideListId);
            return result;
        }
    }
}
