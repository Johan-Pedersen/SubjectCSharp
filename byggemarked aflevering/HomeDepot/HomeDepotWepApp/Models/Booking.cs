using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeDepotWepApp.Models
{
    public class Booking : INotifyPropertyChanged
    {

        public int bookingId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Nullable<int> ToolId { get; set; }
        public Tool Tool { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        private Status status;
        public Status Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                NotifyPropertyChanged("Status");
            }
            }



        public Booking()
        {

        }

        public Booking(int id, DateTime fromDate, DateTime toDate)
        {

            bookingId = id;
            /**
            Tool = t;
            ToolId = t.ToolId;
            Customer = c;
            CustomerId = c.CustomerId;
            */        
            Status = Status.Reserved;
            FromDate = fromDate;
            ToDate = toDate;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        override
        public string ToString()
        {
            return "___"+ Customer.Name + " "+ Tool.ToString();
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public enum Status
    {
        Reserved,
        Returned,
        Extradited
    }
}