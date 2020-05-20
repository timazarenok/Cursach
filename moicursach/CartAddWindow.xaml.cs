using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для CartAddWindow.xaml
    /// </summary>
    public partial class CartAddWindow : Window
    {
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=Scales;Trusted_Connection=True;";
        public int Id { get; set; }
        public CartAddWindow()
        {
            InitializeComponent();
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private string ChangeComa(string text) => text.Replace(',', '.');

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand select = connection.CreateCommand();
                select.CommandText = $"select Products.id from Products where [name]='{Name.Content.ToString().Substring(10)}'";
                int productId = -1;
                SqlDataReader reader = select.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        productId = Convert.ToInt32(reader["id"]);
                    }
                }
                reader.Close();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = $"insert into Cart values({Id}, {productId}, null, null)";
                MessageBox.Show(command.ExecuteNonQuery().ToString());
            }
        }
    }
}
