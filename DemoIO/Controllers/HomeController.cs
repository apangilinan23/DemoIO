using System.Diagnostics;
using DemoIO.Models;
using DemoIO.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoIO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            var result = new List<Contact>();
            var model = new ContactViewModel();
            using (StreamReader reader = new StreamReader(@"Assets/db.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var item = line.Split('|');
                    result.Add(new Contact 
                    {
                        Name = item[0],
                        Age = int.Parse(item[1]),
                        ContactNumber = item[2],
                        Address = item[3],
                        Email = item[4]
                    });
                }
            }

            model.Contacts = result;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
