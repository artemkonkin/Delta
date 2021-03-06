using DirectoryDomain;
using DirectoryServiceLib.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserDomain;

namespace Delta.Controllers.Directories
{
    [Authorize]
    public class DirectoryListController : BaseController
    {
        private readonly IDirectoryListService _directoryListService;

        public DirectoryListController(UserManager<AppUser>? userManager, IDirectoryListService directoryListService) : base(userManager)
        {
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

        /// <summary>
        /// Get directories lists
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
        /// Add directories list
        /// </summary>
        /// <param name="directoriesListName"> Directories lists name </param>
        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateDirectoriesList(string directoriesListName)
        {
            var newDirectoriesList = new DirectoriesList
            {
                Name = directoriesListName
            };

            var response = _directoryListService.AddDirectoryList(newDirectoriesList);

            return Json(response);
        }

        /// <summary>
        /// Delete directories list
        /// </summary>
        /// <param name="guid"> Directories lists guid </param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteDirectoriesList(Guid guid)
        {
            var response = _directoryListService.DeleteDirectoryList(guid);
            return Json(response);
        }

        /// <summary>
        /// Edit directories list
        /// </summary>
        /// <param name="entity"> Directories lists entiry </param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditDirectoriesList(DirectoriesList entity)
        {
            var response = _directoryListService.UpdateDirectoryList(entity);
            return Json(response);
        }
    }
}
