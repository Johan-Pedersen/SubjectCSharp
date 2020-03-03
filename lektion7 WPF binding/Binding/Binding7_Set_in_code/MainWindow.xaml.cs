using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Binding6_Set_in_code {

    public class MyDataClass : INotifyPropertyChanged {
        public MyDataClass(string author, string bookTitle) { Author = author; BookTitle = bookTitle; }
        private string author;
        public string Author {
            set {
                author = value;
                NotifyPropertyChanged(nameof(Author));
            }
            get { return author; }
        }
        private string bookTitle;
        public string BookTitle {
            set {
                bookTitle = value;
                NotifyPropertyChanged(nameof(BookTitle));
            }
            get { return bookTitle; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }        
    }

    public partial class MainWindow : Window {
        private MyDataClass data;
        public MainWindow() {
            InitializeComponent();

            data = new MyDataClass("Edgar Allan Poe", "The Raven");
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            //grid.DataContext = data;

            Binding binding = new Binding();
            binding.Source = data; // or grid.DataContext = data;
            binding.Path = new PropertyPath("Author");
            binding.Mode = BindingMode.OneWay;
            authorTextBox.SetBinding(TextBox.TextProperty, binding);

            binding = new Binding();
            binding.Source = data; // or grid.DataContext = data;
            binding.Path = new PropertyPath("BookTitle");
            binding.Mode = BindingMode.OneWay;
            bookTitleTextBox.SetBinding(TextBox.TextProperty, binding);
        }
    }
}
