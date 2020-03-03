using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace lektion8_opg_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string user in File.ReadAllLines(openFileDialog.FileName))
                {
                    string[] userArr = user.Split(';');
                    User u = new User(int.Parse(userArr[0]), userArr[1], int.Parse(userArr[2]), int.Parse(userArr[3]));

                    userListBox.Items.Add(u.ToString());
                }
            }
        }

    }

    public class User
    {
        int id;
        string name;
        int age;
        int score;

        public User(int id, string name, int age, int score)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.score = score;
        }


        public override string ToString()
        {
            return id + " " + name;
        }
    }
}
