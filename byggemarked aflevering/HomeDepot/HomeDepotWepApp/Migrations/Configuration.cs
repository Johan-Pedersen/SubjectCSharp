namespace HomeDepotWepApp.Migrations
{
    using HomeDepotWepApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeDepotWepApp.Storage.HomeDepotContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HomeDepotWepApp.Storage.HomeDepotContext context)
        {
            //Tilføjer nyt item til databasen

            //t => t.Name viser AddOrUpdate metoden hvilken attribut den skal tjekke på.
            //Man kan ikke bruge dens id til at tjekke på da dette bliver autogeneret



            //Tool ChainSaw = new Tool(3, "ChainSaw");
            //Tool Kultivator = new Tool(1, "Kultivator");

            var værktøjer = new List<Tool>
            {
                 new Tool(1, "Kultivator"),
                 new Tool(2, "ChainSaw"),
                  new Tool(3, "skovl")

            };
            værktøjer.ForEach(t => context.Tools.AddOrUpdate(i => i.ToolId, t));
            context.SaveChanges();
            //Models.Customer c1 = new Customer(1, "c1", "c1ad", "c1@c1.dk");

            //Booking b1 = new Booking();
            //Booking b2 = new Booking();
            //b1.Tool = context.Tools.Find(3);
            //c1.bookings.Add(b1);


            //context.customers.AddOrUpdate(c => c.CustomerId, new Customer(43, "c43", "c43ad", "c43@c43.dk"));

            //b1.Customer = context.customers.Find(1);
            //b2.Customer = context.customers.Find(43);
            //b2.CustomerId = b1.Customer.CustomerId;
            //b2.Tool = context.Tools.Find(42);

            context.customers.AddOrUpdate(c => c.CustomerId, new Customer(1, "c1", "c1ad", "c1@c1.dk"));
            context.SaveChanges();
            context.bookings.AddOrUpdate(b => b.bookingId, new Booking(1, DateTime.Now, new DateTime(2020, 4,20 )));
            context.SaveChanges();

            Booking b1 = context.bookings.Find(1);
            b1.Tool = context.Tools.Find(3);
            b1.ToolId = context.Tools.Find(3).ToolId;
            b1.Customer = context.customers.Find(1);
            b1.CustomerId = context.customers.Find(1).CustomerId;
            context.customers.Find(1).Bookings.Add(b1);
            context.customers.Find(1).Password = "password";
            context.customers.Find(1).Username = "username";
            context.SaveChanges();





            //context.bookings.AddOrUpdate(b => b.bookingId, new Booking(420, b2.Tool, b2.Customer));
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
