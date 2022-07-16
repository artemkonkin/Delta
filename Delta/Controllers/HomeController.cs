using Delta.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using UserDomain;
using RepositoriesLib.Interfaces.Note;

namespace Delta.Controllers
{
    public class HomeController : BaseController
    {
        private readonly INoteRepository _noteRepository;

        public HomeController(INoteRepository noteRepository, UserManager<AppUser>? userManager) : base(userManager)
        {
            _noteRepository = noteRepository;
        }

        public IActionResult Index()
        {
            _noteRepository.GetUserNotes(GetUserId());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}