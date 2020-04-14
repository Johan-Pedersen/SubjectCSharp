using HomeDepotWepApp.Models;
using HomeDepotWepApp.Storage;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeDepotWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HomeDepotContext _context;

        private Customer _selectedCustomer;
        private Booking _currentBooking;

        public MainWindow()
        {
            InitializeComponent();

            _context = new HomeDepotContext();


            //Eager loading
            ListCustomers.DataContext = _context.customers.Include(c => c.Bookings).ToList();


        }

        private void ListBoxCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            _selectedCustomer = (Customer) ListCustomers.SelectedItem;

            SelectedCustomerLoad();



        }

        private void SelectedCustomerLoad()
        {
            tbName.DataContext = _selectedCustomer;
            tbAddress.DataContext = _selectedCustomer;
            tbEmail.DataContext = _selectedCustomer;



            //Explict loading
            foreach (Booking booking in _selectedCustomer.Bookings)
            {
                _context.Entry(booking).Reference(b => b.Tool).Load();
            }



            ListBookings.ItemsSource = _selectedCustomer.Bookings;

            ListBookings.Items.Refresh();
        }

        private void CreateCustomer_Click(object sender, RoutedEventArgs e)
        {

            if(tbEmail.Text.Length >0 && tbAddress.Text.Length > 0 && tbName.Text.Length > 0)
            {
                Customer c = new Customer(tbName.Text, tbAddress.Text, tbEmail.Text);

                _context.customers.Add(c);

                _context.SaveChanges();
                ListCustomers.DataContext = _context.customers.ToList();
                ListCustomers.Items.Refresh();

            }
            else
            {
                MessageBox.Show("Name, address and email field should be filled");
            }

        }

        private void FindCustomer_Click(object sender, RoutedEventArgs e)
        {
            _selectedCustomer = _context.customers.Find(int.Parse(tbFind.Text));

            SelectedCustomerLoad();
        }

        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCustomer != null)
            {

                _selectedCustomer.Name = tbName.Text;
                _selectedCustomer.Email = tbEmail.Text;
                _selectedCustomer.Address = tbAddress.Text;
                
                _context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Name, address and email field should be filled");
            }
        }

        private void btnReserve_Click(object sender, RoutedEventArgs e)
        {
            if (_currentBooking != null)
            {
                _currentBooking.Status = Status.Reserved;
                _context.SaveChanges();
            }
        }

        private void btnReturned_Click(object sender, RoutedEventArgs e)
        {

            if (_currentBooking != null)
            {
                _currentBooking.Status = Status.Returned;
                _context.SaveChanges();
            }

        }

        private void btnExtradited_Click(object sender, RoutedEventArgs e)
        {

            if (_currentBooking != null)
            {
                _currentBooking.Status = Status.Extradited;
                _context.SaveChanges();

            }
        }

        private void ListBookings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _currentBooking = (Booking)ListBookings.SelectedItem;

            tbTool.DataContext = _currentBooking.Tool;
            tbToDate.DataContext = _currentBooking;
            tbFromDate.DataContext = _currentBooking;
            tbStatus.DataContext = _currentBooking;

        }
    }
}
