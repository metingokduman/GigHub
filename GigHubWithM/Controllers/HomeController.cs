using GigHubWithM.Models;
using GigHubWithM.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GigHubWithM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g=>g.Genre)
                .Where(g => g.DateTime < DateTime.Now).ToList();

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading="Upcoming Gigs"
            };
            return View("Gigs",viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}