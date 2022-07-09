using DirectoryDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServicesLib.Directory;
using UserDomain;

namespace Delta.Controllers.Directories
{
    [Authorize]
    public class DirectoryController : BaseController
    {
        private readonly IDirectoryListService _directoryListService;

        public DirectoryController(UserManager<AppUser>? userManager, IDirectoryListService directoryListService) : base(userManager)
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
