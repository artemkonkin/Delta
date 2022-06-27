using BaseEntityLib;
using GuideDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoriesLib.Interfaces.Guide;
using ServicesLib.Guide;
using UserDomain;

namespace Delta.Controllers.Guides
{
    [Authorize]
    public class GuideController : BaseController
    {
        private readonly IGuideListRepository _guideListRepository;
        private readonly IGuideListService _guideListService;

        public GuideController(IGuideListRepository guideListRepository, UserManager<AppUser>? userManager, IGuideListService guideListService) : base(userManager)
        {
            _guideListRepository = guideListRepository;
            _guideListService = guideListService;
        }

        /// <summary>
        /// Guides lists page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var guidesList = _guideListService.GetAllGuidesLists();
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
        /// <returns> Guides lists </returns>
        public IActionResult GetGuidesLists()
        {
            var guidesList = _guideListService.GetAllGuidesLists();
            return Ok(guidesList);
        }

        /// <summary>
        /// Add guide list
        /// </summary>
        /// <param name="guideListName"> Guides lists name </param>
        [HttpGet]
        [Produces("application/json")]
        public IActionResult CreateGuideList(string guideListName)
        {
            var newGuideList = new GuidesList
            {
                Name = guideListName
            };

            var response = _guideListService.AddGuideList(newGuideList);

            return Ok(response);
        }
    }
}
