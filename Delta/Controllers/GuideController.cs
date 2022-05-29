using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoriesLib.Interfaces.Guide;
using ServicesLib.Guide;
using UserDomain;

namespace Delta.Controllers
{
    public class GuideController : BaseController
    {
        private readonly IGuideListRepository _guideListRepository;
        private readonly IGuideListService _guideListService;

        public GuideController(IGuideListRepository guideListRepository, UserManager<AppUser>? userManager, IGuideListService guideListService) : base(userManager)
        {
            _guideListRepository = guideListRepository;
            _guideListService = guideListService;
        }

        public IActionResult Index()
        {
            var guidesList = _guideListRepository.GetAllGuidesLists();
            var gl = _guideListService.GetAllGuidesLists();

            guidesList = gl;

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
    }
}
