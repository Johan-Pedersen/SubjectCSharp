using HomeDepotWepApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeDepotWepApp.Storage
{
    public class HomeDepotContext : DbContext
    {

        public HomeDepotContext() :base ("name = HomeDepotConnectionString")
        {
        }

        public DbSet<Tool> Tools { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Customer> customers { get; set; }
    }
}