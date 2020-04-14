using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDepotWepApp.Models
{
    public class Customer : INotifyPropertyChanged
    {
        public int CustomerId { get; set; }
        private string name;
        private string address;
        private string email;
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Booking> Bookings {get; set;}

        public string Name { get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                NotifyPropertyChanged("Address");
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public Customer(int id ,string name, string address, string email)
        {
            Bookings = new List<Booking>();
            CustomerId = id;
            Name = name;
            Address = address;
            Email = email;
        }

        public Customer(string name, string address, string email)
        {
            Bookings = new List<Booking>();
            Name = name;
            Address = address;
            Email = email;

        }
        public Customer()
        {
            Bookings = new List<Booking>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        override
        public string ToString()
        {
            return "*** "+ Name+ " " + CustomerId.ToString();
        }
        
    }
}