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
    /// Логика взаимодействия для CategoryAdd.xaml
    /// </summary>
    public partial class CategoryAdd : Window
    {
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=Scales;Trusted_Connection=True;";
        public CategoryAdd()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"insert into Categories values('{Content.Text}')";
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Успешно добавлено");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            Close();
        }
    }
}
