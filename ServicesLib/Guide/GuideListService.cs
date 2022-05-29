using BaseEntityLib;
using GuideDomain;
using GuideDomain.ViewModels;
using Microsoft.AspNetCore.Identity;
using RepositoriesLib.Interfaces.Guide;
using UnitOfWorkLib;
using UserDomain;

namespace ServicesLib.Guide
{
    public class GuideListService : IGuideListService
    {
        private readonly IUnitOfWork _uow;
        private readonly UserManager<AppUser> _userManager;
        private readonly IGuideListRepository _guideListRepository;

        public GuideListService(IUnitOfWork uow, UserManager<AppUser> userManager, IGuideListRepository guideListRepository)
        {
            _uow = uow;
            _userManager = userManager;
            _guideListRepository = guideListRepository;
        }

        /// <summary>
        /// Get all guides lists
        /// </summary>
        /// <returns></returns>
        public IQueryable<GuidesList> GetAllGuidesLists()
        {
            return _guideListRepository.GetAllGuidesLists();
        }

        /// <summary>
        /// Get guide list by id
        /// </summary>
        /// <param name="guideListId"> Guide list id </param>
        /// <returns></returns>
        public Response<GuidesList> GetGuideListById(Guid guideListId)
        {
            var guideList = _guideListRepository.GetGuideListById(guideListId);
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
            var guideList = _guideListRepository.GetGuideListById(guideListId);

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
            var result = _guideListRepository.AddGuideList(guideListEntity);
            return result;
        }

        /// <summary>
        /// Update guide list
        /// </summary>
        /// <param name="guideListEntity"> Guide list entity </param>
        /// <returns></returns>
        public Response<GuidesList> UpdateGuideList(GuidesList guideListEntity)
        {
            var result = _guideListRepository.UpdateGuidesList(guideListEntity);
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
            var result = _guideListRepository.RenameGuideList(guideListId, guideListName);
            return result;
        }

        /// <summary>
        /// Delete guide list
        /// </summary>
        /// <param name="guideListId"> Guide list id </param>
        /// <returns></returns>
        public Response<GuidesList> DeleteGuideList(Guid guideListId)
        {
            var result = _guideListRepository.DeleteGuideList(guideListId);
            return result;
        }
    }
}
