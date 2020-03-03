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

namespace Binding4_TwoWay {

    public class MyDataContext : INotifyPropertyChanged {
        public MyDataContext() { Author = "Tom Clancy"; }

        private string author;
        public string Author {
            set {
                author = value;
                NotifyPropertyChanged("Author");
            }
            get { return author; }
        }

        public int rating;
        public int Rating {
            set {
                rating = value;
                NotifyPropertyChanged("Rating");
            }
            get { return rating; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class MainWindow : Window {
        private MyDataContext dataContext;

        public MainWindow() {
            InitializeComponent();

            dataContext = new MyDataContext();

            // Binding DataContext
            //labelForDataBinding.DataContext = dataContext;
            //textBoxLower.DataContext = dataContext;
            //slider.DataContext = dataContext;
            //ratingLabel.DataContext = dataContext;

            // Binding DataContext in enclosing element
            stackPanel.DataContext = dataContext;

            // Binding DataContext in other enclosing element
            // grid.DataContext = dataContext;
        }

        private void TextBoxUpper_TextChanged(object sender, TextChangedEventArgs e) {
            if (dataContext != null)
                dataContext.Author = ((TextBox)sender).Text;
        }
    }
}
