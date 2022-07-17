using BaseEntityLib;
using DirectoryDomain;
using DirectoryDomain.ViewModels;
using DirectoryServiceLib.Interface;
using Microsoft.AspNetCore.Identity;
using RepositoriesLib.Interfaces.Directory;
using UnitOfWorkLib;
using UserDomain;

namespace DirectoryServiceLib
{
    public class DirectoryListService : IDirectoryListService
    {
        private readonly IUnitOfWork _uow;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDirectoryListRepository _directoryListRepository;

        public DirectoryListService(IUnitOfWork uow, UserManager<AppUser> userManager,
            IDirectoryListRepository directoryListRepository)
        {
            _uow = uow;
            _userManager = userManager;
            _directoryListRepository = directoryListRepository;
        }

        /// <summary>
        /// Get all directories lists
        /// </summary>
        /// <returns></returns>
        public IQueryable<DirectoriesList> GetAllDirectoriesLists()
        {
            return _directoryListRepository.GetAllDirectoriesLists();
        }

        /// <summary>
        /// Get directories list by id
        /// </summary>
        /// <param name="directoryListId"> Directory list id </param>
        /// <returns></returns>
        public Response<DirectoriesList> GetDirectoryListById(Guid directoryListId)
        {
            var guideList = _directoryListRepository.GetDirectoryListById(directoryListId);
            return guideList;
        }

        /// <summary>
        /// Get directories list with data
        /// </summary>
        /// <param name="directoryListId"> Directory list id </param>
        /// <returns></returns>
        public ReadDirectoryListVm GetDirectoryListWithData(Guid directoryListId)
        {
            //todo Доделать
            var guideList = _directoryListRepository.GetDirectoryListById(directoryListId);

            return new ReadDirectoryListVm
            {
                Id = guideList.Data.Id,
                Name = guideList.Data.Name,
                Directories = guideList.Data.DirectoryEntities
            };
        }

        /// <summary>
        /// Add directories list
        /// </summary>
        /// <param name="directoryListEntity"> Directory list entity </param>
        /// <returns></returns>
        public Response<DirectoriesList> AddDirectoryList(DirectoriesList directoryListEntity)
        {
            var result = _directoryListRepository.AddDirectoryList(directoryListEntity);
            return result;
        }

        /// <summary>
        /// Update directories list
        /// </summary>
        /// <param name="directoryListEntity"> Directory list entity </param>
        /// <returns></returns>
        public Response<DirectoriesList> UpdateDirectoryList(DirectoriesList directoryListEntity)
        {
            var result = _directoryListRepository.UpdateDirectoryList(directoryListEntity);
            return result;
        }

        /// <summary>
        /// Rename directories list
        /// </summary>
        /// <param name="directoryListId"> Directory list id </param>
        /// <param name="directoryListName"> Directory list name </param>
        /// <returns></returns>
        public Response<DirectoriesList> UpdateDirectoryList(Guid directoryListId, string directoryListName)
        {
            var result = _directoryListRepository.RenameDirectoryList(directoryListId, directoryListName);
            return result;
        }

        /// <summary>
        /// Delete directories list
        /// </summary>
        /// <param name="directoryListId"> Directory list id </param>
        /// <returns></returns>
        public Response<DirectoriesList> DeleteDirectoryList(Guid directoryListId)
        {
            var result = _directoryListRepository.DeleteDirectoryList(directoryListId);
            return result;
        }
    }
}