using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace moicursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string connectionString = @"Server=localhost\SQLEXPRESS;Database=Scales;Trusted_Connection=True;";
        public string login { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(Pages.login);
        }
        public enum Pages
        {
            login,
            regin,
            main,
            admin,
            cart
        }

        public void OpenPage(Pages page)
        {
            if(page == Pages.login)
            {
                frame.Navigate(new LoginPage(this));
            }else if(page == Pages.regin)
            {
                frame.Navigate(new RegistrationPage(this));
            }
            else if(page == Pages.main)
            {
                frame.Navigate(new Main(this));
            }
            else if(page == Pages.admin)
            {
                frame.Navigate(new AdminPage(this));
            }
        }

        public bool RegexLogin(string login)
        {
            return new Regex("[A-Za-z0-9]{4,15}").IsMatch(login);
        }
        public bool RegexPassword(string password)
        {
            return new Regex("[A-Za-z0-9]{8,20}").IsMatch(password);
        }
        public bool RegexAdmin(string login, string password)
        {
            return new Regex("adminadmin").IsMatch(login + password);
        }
        public bool Add(string expression)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int number = 0;
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = expression;
                number = command.ExecuteNonQuery();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            if (number > 0)
            {
                return true;
            }
            return false;
        }
        public int GetUserId()
        {
            DataTable dt = Select($"select id from Users where login='{login}'");
            int id = -1;
            foreach(DataRow dr in dt.Rows)
            {
                id = Convert.ToInt32(dr["id"]);
            }
            return id;
        }
        public DataTable Select(string selectString)
        {
            DataTable dataTable = new DataTable("database");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = selectString;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
