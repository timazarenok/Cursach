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
    /// Логика взаимодействия для ProductAdd.xaml
    /// </summary>
    public partial class ProductAdd : Window
    {
        MainWindow mw = new MainWindow();
        public ProductAdd()
        {
            InitializeComponent();
            Categories.ItemsSource = GetCategories();
        }
        private int GetId(string name)
        {
            DataTable dt = mw.Select($"select id from Categories where [name]='{name}'");
            int id = -1;
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    id = Convert.ToInt32(dr["id"]);
                }
                return id;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            return id;
        }
        private List<string> GetCategories()
        {
            DataTable dt = mw.Select("select [name] from Categories");
            List<string> categories = new List<string>();
            foreach(DataRow dr in dt.Rows)
            {
                categories.Add(dr["name"].ToString());
            }
            return categories;
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)    
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mw.connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"insert into Products values({GetId(Categories.SelectedItem.ToString())},'{Name.Text}','{Description.Text}')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Успешно добавлено");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
