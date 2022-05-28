using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserDomain;

namespace Delta.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser>? _userManager;
        public readonly string CurrentUserId = null!;

        protected BaseController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        protected BaseController(ILogger<HomeController> logger, UserManager<AppUser>? userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        /// <summary>
        /// Get cuttent user Id
        /// </summary>
        /// <returns> Current user Id </returns>
        public string GetCurrentUserId()
        {
            return _userManager.GetUserId(ClaimsPrincipal.Current);
        }
    }
}
