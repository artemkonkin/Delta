using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AppUser = UserDomain.AppUser;

namespace Delta.Controllers
{
    /// <summary>
    /// Base controller
    /// </summary>
    public abstract class BaseController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        protected BaseController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public string GetUserId() => _userManager.GetUserId(User);
        public Task<AppUser> GetUser() => _userManager.GetUserAsync(User);
    }
}