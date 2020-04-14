using HomeDepotWepApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeDepotWepApp.Storage;
using System.Web.Mvc;

namespace HomeDepotWepApp.Controllers
{
    public class HomeController : Controller
    {

        private Customer customer;
        private Booking SelectedBooking;

        //virker ikke
        private HomeDepotContext context = new HomeDepotContext();

        public ActionResult LogIn()
        {


            return View();
        }


        [HttpPost]
        public ActionResult LogIn(Customer loggedInCustomer)
        {

            customer = context.customers.Where(c => c.Username == loggedInCustomer.Username && c.Password == loggedInCustomer.Password).FirstOrDefault();
            

            //explicit loading
            context.Entry(customer).Collection(c => c.Bookings).Load();
            

            List<SelectListItem> selectListItems = new List<SelectListItem>();


            foreach (Booking booking in customer.Bookings)
            {

                //explicit loading
                context.Entry(booking).Reference(b => b.Tool).Load();
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = booking.Tool.ToString(),
                    Value = booking.bookingId.ToString()
                };

                
                selectListItems.Add(selectListItem);
            }

            ViewBag.Bookings = new SelectList(selectListItems, "Value", "Text");

            BookingViewModel bvm = new BookingViewModel()
            {
                Bookings = selectListItems
            };

            return View("LogInDetails", bvm);
        }


        public ActionResult BookingView(BookingViewModel bookingValue)
        {
            SelectedBooking = context.bookings.Find(int.Parse(bookingValue.val));

            return View(SelectedBooking);
        }
        
        [HttpPost]
        public ActionResult DoneView(Booking booking, FormCollection formCollection)
        {

            //if (!ModelState.IsValid) { }

            context.bookings.Find(booking.bookingId).FromDate = DateTime.Parse(formCollection[1].ToString());
            context.bookings.Find(booking.bookingId).ToDate = DateTime.Parse(formCollection[0].ToString());

            context.bookings.Find(booking.bookingId).Status = Status.Reserved;

            context.SaveChanges();

            return View(context.bookings.Find(booking.bookingId));
        }

    }

}