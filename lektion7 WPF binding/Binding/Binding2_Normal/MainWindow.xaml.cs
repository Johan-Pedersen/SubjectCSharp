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

namespace Binding2_Normal {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private bool useStupidSolution;

        public MainWindow() {
            InitializeComponent();
            useStupidSolution = false;
                        
            Author = "Tom Clancy";
            BookTitle = "Jack Ryan: Shadow Recruit";

            labelForDataBinding.DataContext = this;
        }

        public string Author { set; get; }
        public string BookTitle { set; get; }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

            Author = ((TextBox)sender).Text;

            if (useStupidSolution && labelForDataBinding != null) {
                labelForDataBinding.DataContext = null; // remove old DataContext
                labelForDataBinding.DataContext = this; // set new DataContext
            }
        }

        private void CheckBox_CheckedChanged(object sender, RoutedEventArgs e) {
            var b = ((CheckBox)sender).IsChecked;
            useStupidSolution = b.HasValue ? b.Value : false;
        }
    }
}
