using Delta.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Delta.Controllers.Base;
using Newtonsoft.Json;

namespace Delta.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            var friendsList = new List<VueUser>
            {
                new VueUser
                {
                    LastName = "Ford",
                    Name = "Henry",
                    Username = "henryford121"
                },
                new VueUser
                {
                    LastName = "Montgo",
                    Name = "Suzzie",
                    Username = "mongosus"
                },
                new VueUser
                {
                    LastName = "Rivera",
                    Name = "Luis",
                    Username = "starraiden"
                }
            };

            TempData["TempDataFriendsList"] = JsonConvert.SerializeObject(friendsList);
            var model = new IndexViewModel
            {
                User = new VueUser
                {
                    LastName = "Rivera",
                    Name = "Genesis",
                    Username = "genesisrrios"
                },
                FriendList = friendsList
            };

            return View(model);
		}

        [HttpPost]
        public bool InsertNewFriendInMemory([FromBody] VueUser friend)
        {
            if (friend == default || !TempData.ContainsKey("TempDataFriendsList")) return false;
            var tempData = TempData["TempDataFriendsList"];
            var deserializedData = JsonConvert.DeserializeObject<List<VueUser>>((string)tempData);
            deserializedData.Add(friend);
            TempData["TempDataFriendsList"] = JsonConvert.SerializeObject(deserializedData);
            return true;
        }

        public List<VueUser> GetFriendsList()
        {
            var tempData = TempData["TempDataFriendsList"];
            TempData.Keep();
            var deserializedData = JsonConvert.DeserializeObject<List<VueUser>>((string)tempData);
            return deserializedData;
        }

        [HttpDelete]
        public bool RemoveFriend([FromBody] VueUser friend)
        {
            if (friend == default || !TempData.ContainsKey("TempDataFriendsList")) return false;
            var tempData = TempData["TempDataFriendsList"];
            var deserializedData = JsonConvert.DeserializeObject<List<VueUser>>((string)tempData);
            deserializedData.Remove(friend);
            TempData["TempDataFriendsList"] = JsonConvert.SerializeObject(deserializedData);
            return true;
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