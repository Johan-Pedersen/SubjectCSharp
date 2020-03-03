using System;
using System.Collections.Generic;
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

namespace Binding {
    
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            Author = "Author name";
            BookTitle = "Title of book";

            textBox1.DataContext = this;
            textBox2.DataContext = this;
        }

        public string Author { set; get; }
        public string BookTitle { set; get; }

    }

    

}
