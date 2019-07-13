using GigHubWithM.Models;
using System;
using System.Collections.Generic;

namespace GigHubWithM.ViewModels
{
    public class GigFormViewModel
    {
       public DateTime DateTime
        {
            get
            {
                return DateTime.Parse(string.Format("{0} {1}", Date, Time));
            }

        }

        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}