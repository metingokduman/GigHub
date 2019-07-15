﻿using GigHubWithM.Models;
using System.Collections.Generic;

namespace GigHubWithM.ViewModels
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }

        public bool ShowActions { get; set; }

        public string Heading { get; set; }

    }
}