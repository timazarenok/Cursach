using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace moicursach
{
    /// <summary>
    /// Логика взаимодействия для addPrice.xaml
    /// </summary>
    public partial class addPrice : Window
    {
        MainWindow mw = new MainWindow();
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=Scales;Trusted_Connection=True;";
        public addPrice()
        {
            InitializeComponent();
            Products.ItemsSource = GetProductsId();
        }

        private List<string> GetProductsId()
        {
            DataTable products = mw.Select("select [name] from Products");
            List<string> ids = new List<string>();
            foreach(DataRow dr in products.Rows)
            {
                ids.Add(dr["name"].ToString());
            }
            return ids;
        }
        private int GetId(string name)
        {
            DataTable dt = mw.Select($"select id from Products where [name]='{name}'");
            int id = -1;
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    id = Convert.ToInt32(dr["id"]);
                }
                return id;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            return id;
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"insert into Prices values ({GetId(Products.SelectedItem.ToString())},'{DateIn.Text}','{DateOut.Text}', {Value.Text})";
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Успешно добавлено");
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void Products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
