using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Binding6_ObservableCollection {

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
        public override string ToString() {
            return BookTitle;
        }

        public string ListBoxToString {
            get {
                return BookTitle + " (" + Author + ")";
            }
        }
    }

    public partial class MainWindow : Window {        
        private ObservableCollection<MyDataClass> data;

        public MainWindow() {
            InitializeComponent();
            
            data = new ObservableCollection<MyDataClass>() {
                new MyDataClass("Tom Clancy","Jack Ryan: Shadow Recruit"),
                new MyDataClass("Stephen King","Carrie"),
                new MyDataClass("Stephen King","The Shining"),
                new MyDataClass("Edgar Allan Poe","The Raven"),
                new MyDataClass("Edgar Allan Poe","The Murders in the Rue Morgue"),
            };

            listBox.ItemsSource = data;
            gridOuter.DataContext = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            data.Add(new MyDataClass("Claude Shannon", "A Mathematical Theory of Communication"));
        }
    }
}
