using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace lektion8_opg7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users = new List<User>();
        private User selectedUser;

        public MainWindow()
        {
            InitializeComponent();


            /**
             * huske at sætte data konteksten for grid
             */

            userListBox.ItemsSource = users;
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
                }

                userListBox.Items.Refresh();
            }
        }

        /**
         * returner user-id for den user man har trykket på
         */
        private void selectUser(ListBox sender)
        {
           int userID = int.Parse(sender.SelectedItem.ToString().Split(' ')[0]);

            foreach (User u in users)
            {
                if(userID == u.Id)
                {
                    selectedUser = u;
                    break;
                }
            }

            gridName.DataContext = selectedUser;
        }
        

        private void lBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            selectUser((ListBox)sender);

                    txBoxName.Text = selectedUser.Name;
                    txBoxAge.Text = selectedUser.Age.ToString();
                    txBoxId.Text = selectedUser.Id.ToString();
                    txBoxScore.Text = selectedUser.Score.ToString();

        }

        private void changeAttribute_Click(object sender, RoutedEventArgs e)
        {
            if(selectedUser != null)
            {
                selectedUser.Name = txBoxName.Text;
                selectedUser.Age= int.Parse(txBoxAge.Text);
                MessageBox.Show(txBoxName.Text);
                selectedUser.Score = int.Parse(txBoxScore.Text);

                MessageBox.Show("Cannot change ID");

                userListBox.Items.Refresh();
            }


        }


    }


    public class User : INotifyPropertyChanged

    {
        private int id;
        private string name;
        private int age;
        private int score;

        public User(int id, string name, int age, int score)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.score = score;
        }

        public int Id {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
                
                }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                NotifyPropertyChanged("Age");
            }
        }
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                NotifyPropertyChanged("Score");
            }
        }



        public override string ToString()
        {
            return Id + " " + Name;
        }

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
}
