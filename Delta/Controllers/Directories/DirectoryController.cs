using DirectoryDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoriesLib.Interfaces.Directory;
using ServicesLib.Directory;
using UserDomain;

namespace Delta.Controllers.Directories
{
    [Authorize]
    public class DirectoryController : BaseController
    {
        private readonly IDirectoryListRepository _directoryListRepository;
        private readonly IDirectoryListService _directoryListService;

        public DirectoryController(IDirectoryListRepository directoryListRepository, UserManager<AppUser>? userManager, IDirectoryListService directoryListService) : base(userManager)
        {
            _directoryListRepository = directoryListRepository;
            _directoryListService = directoryListService;
        }

        /// <summary>
        /// Directories lists page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var guidesList = _directoryListService.GetAllDirectoriesLists();
            return View(guidesList);
        }

        public void Create()
        {
        }

        public void Edit()
        {
        }

        public void Delete()
        {
        }

        /// <summary>
        /// Get guide lists
        /// </summary>
        /// <returns> Directories lists </returns>
        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetDirectoriesLists()
        {
            var guidesList = _directoryListService.GetAllDirectoriesLists();
            return Json(guidesList.ToList());
        }

        /// <summary>
        /// Add guide list
        /// </summary>
        /// <param name="directoryListName"> Directories lists name </param>
        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateDirectoryList(string directoryListName)
        {
            var newDirectoryList = new DirectoriesList
            {
                Name = directoryListName
            };

            var response = _directoryListService.AddDirectoryList(newDirectoryList);

            return Json(response);
        }

        [HttpPost]
        public IActionResult DeleteDirectoriesList(Guid guid)
        {
            var response = _directoryListService.DeleteDirectoryList(guid);
            return Json(response);
        }

        [HttpPost]
        public IActionResult EditDirectoriesList(DirectoriesList entity)
        {
            var response = _directoryListService.UpdateDirectoryList(entity);
            return Json(response);
        }
    }
}
