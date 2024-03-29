﻿using GigHubWithM.Models;
using GigHubWithM.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
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

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Gigs
                .Where(g => g.ArtistId == userId && g.DateTime > DateTime.Now)
                .Include(g=>g.Genre)
                .ToList();
            return View(gigs);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a=>a.Gig)
                .Include(g=>g.Artist)
                .Include(g=>g.Genre)
                .ToList();
            var viewModel = new GigsViewModel()
            {
                UpcomingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading="Gigs I'm Attending"
            };
            return View("Gigs",viewModel);

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
        [ValidateAntiForgeryToken]//prevent for attack
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }
                
                        
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Mine", "Gigs");
        }
    }
}