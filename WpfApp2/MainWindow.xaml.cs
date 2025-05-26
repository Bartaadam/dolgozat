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
using System.IO;
using MySql.Data.MySqlClient;
namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection kapcs = new MySqlConnection("server = localhost;database = bartaa; uid =root ; password = ''");
         

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                kapcs.Open();
                var reader = new MySqlCommand($"SELECT * FROM filmek", kapcs).ExecuteReader();

                while (reader.Read())
                {
                    lbAdatok.Items.Add($"{reader["filmazon"]};{reader["cim"]};{reader["ev"]};{reader["szines"]};{reader["mufaj"]};{reader["hossz"]}");
                }
                kapcs.Close();



        }

        private void lbAdatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (lbAdatok.SelectedItem != null)
            {
                string[] data = lbAdatok.SelectedItem.ToString().Split(';');
                lbFilmAzon.Content = data[0];
                tb1.Text = data[1];
                tb2.Text = data[2];
                tb3.Text = data[3];
                tb4.Text = data[4];
                tb5.Text = data[5];
            }
        }
    }
}