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

namespace lektion8_opg6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users = new List<User>();

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
                    users.Add(u);
                    userListBox.Items.Add(u.ToString());
                }
            }
        }

        private void lBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;

            int userID = int.Parse(item.SelectedItem.ToString().Split(' ')[0]);


            foreach(User u in users)
            {
                if(u.Id == userID)
                {
                    txBoxName.Text = u.Name;
                    txBoxAge.Text = u.Age.ToString();
                    txBoxId.Text = u.Id.ToString();
                    txBoxScore.Text = u.Score.ToString();
                }
            }

          

        }
    }


    public class User
    {

        public User(int id, string name, int age, int score)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Score = score;
        }

        public int Id { get; set; }
        public string Name { get ; set ; }
        public int Age { get ; set ; }
        public int Score { get ; set ; }

        //Lav properites af attributter



        public override string ToString()
        {
            return Id + " " + Name;
        }
    }
}
