using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace lektion7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Person p;
        public MainWindow()
        {
            InitializeComponent();

            p = new Person("Hej bo", 500, 13, 42, true);
            grid2.DataContext = p;
            /**
            NameLabel.DataContext = p;
            AgeLabel.DataContext = p;
            WeightLabel.DataContext = p;
            ScoreLabel.DataContext = p;
            AcceptedLabel.DataContext = p;
    */
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(p != null)
            {
                p.Name = ((TextBox)sender).Text;
                MessageBox.Show(p.ToString());
            }
        }

        private void Score_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (p != null)
            {
                Regex rx = new Regex(@"\d*");
                if (rx.IsMatch(((TextBox)sender).Text))
                {
                    int score;
                    Int32.TryParse(((TextBox)sender).Text, out score);
                    p.Score = score;

                    MessageBox.Show(p.ToString());
                }
            }

        }
    }

    class Person : INotifyPropertyChanged
    {
        private string name;
        private int score;
        public Person(string name, int weight, int age, int score, bool accepted)
        {
            Name = name;
            Weight = weight;
            Age = age;
            Score = score;
            Accepted = accepted;
        }

        public int Weight { get; set; }
        public int Age { get; set; }
        public bool Accepted { get; set; }

        public string Name {
            get
            {
                return name;
            }
            
            set {
                name = value;
                NotifyPropertyChanged("Name");
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
            return Name +" "+ Age+ " " + Weight + " "+ Accepted;
        } 
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
