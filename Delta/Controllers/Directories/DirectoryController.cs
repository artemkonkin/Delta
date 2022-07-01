using DirectoriesLib.Directory;
using DirectoryDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoriesLib.Interfaces.Directory;
using UserDomain;

namespace Delta.Controllers.Directories
{
    [Authorize]
    public class DirectoryController : BaseController
    {
        private readonly IDirectoryListRepository _directoryListRepository;
        private readonly IDirectoryListService _guideListService;

        public DirectoryController(IDirectoryListRepository directoryListRepository, UserManager<AppUser>? userManager, IDirectoryListService guideListService) : base(userManager)
        {
            _directoryListRepository = directoryListRepository;
            _guideListService = guideListService;
        }

        /// <summary>
        /// Directories lists page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var guidesList = _guideListService.GetAllDirectoriesLists();
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
        public IActionResult GetGuidesLists()
        {
            var guidesList = _guideListService.GetAllDirectoriesLists();
            return Json(guidesList.ToList());
        }

        /// <summary>
        /// Add guide list
        /// </summary>
        /// <param name="guideListName"> Directories lists name </param>
        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateGuideList(string guideListName)
        {
            var newGuideList = new DirectoriesList
            {
                Name = guideListName
            };

            var response = _guideListService.AddDirectoryList(newGuideList);

            return Json(response);
        }

        [HttpPost]
        public IActionResult DeleteGuidesList(Guid guid)
        {
            var response = _guideListService.DeleteDirectoryList(guid);
            return Json(response);
        }

        [HttpPost]
        public IActionResult EditGuidesList(DirectoriesList entity)
        {
            var response = _guideListService.UpdateDirectoryList(entity);
            return Json(response);
        }
    }
}
