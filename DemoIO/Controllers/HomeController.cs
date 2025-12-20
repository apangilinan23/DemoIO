using DemoIO.Database;
using DemoIO.Models;
using DemoIO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DemoIO.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly MockDbContext _mockDbContext;

        public HomeController(ILogger<HomeController> logger, MockDbContext mockDbContext)
        {
            _logger = logger;
            _mockDbContext = mockDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }

        public IActionResult About()
        {
            var author = new Author();
            author.Name = "Adrian Pangilinan";
            author.Age = 31;

            var educationList = new List<Education>();
            educationList.Add(new Education { Year = 2014, SchoolName = "SLU College" });
            educationList.Add(new Education { Year = 2010, SchoolName = "SLU High school" });

            var aboutViewModel = new AboutViewModel();
            aboutViewModel.Author = author;
            aboutViewModel.EducationList = educationList;

            return View(aboutViewModel);
        }

        public IActionResult GetSum(int number1, int number2)
        {
            ViewBag.Sum = number1 + number2;
            return View();
        }

        public IActionResult Contacts()
        {

            var contacts = _mockDbContext.ClientAddress.Include(c => c.Address).ToList();


            return null;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
