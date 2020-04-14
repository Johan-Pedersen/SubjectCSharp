using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeDepotWepApp.Storage;

namespace HomeDepotWepApp.Models
{
    public class BookingViewModel
    {
        public IEnumerable<SelectListItem> Bookings { get; set; }
        public string val { get; set; }
    }
}