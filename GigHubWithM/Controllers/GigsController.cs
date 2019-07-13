using GigHubWithM.Models;
using GigHubWithM.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace GigHubWithM.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Gigs
        public ActionResult Create()
        {
            var viewmodel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewmodel);
        }
    }
}