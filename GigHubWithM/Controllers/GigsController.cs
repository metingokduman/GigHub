﻿using GigHubWithM.Models;
using GigHubWithM.ViewModels;
using Microsoft.AspNet.Identity;
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
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var viewmodel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewmodel);

        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.DateTime,
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}