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

namespace Binding3_Solution {

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

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class MainWindow : Window {
        private MyDataContext dataContext;

        public MainWindow() {
            // dataContext = new MyDataContext(); // Solves dataContext==null problem
            InitializeComponent();

            dataContext = new MyDataContext();
            labelForDataBinding.DataContext = dataContext;
        }        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {
            if(dataContext!=null)
                dataContext.Author = ((TextBox)sender).Text;            
        }
    }
}
