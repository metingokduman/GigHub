using GigHubWithM.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GigHubWithM.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FolloweesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Followees
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var artists = _context.Followings
                .Where(g => g.FolloweeId == userId)
                .Include(g=>g.Follower)
                .Include(g=>g.Followee)
                .ToList();
           
            return View(artists);


        }
    }