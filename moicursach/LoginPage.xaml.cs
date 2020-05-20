using System;
using System.Collections.Generic;
using System.Data;
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

namespace moicursach
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public MainWindow mainWindow;
        public LoginPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }
        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.regin);
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            if (mainWindow.RegexAdmin(Login.Text, Password.Password))
            {
                mainWindow.OpenPage(MainWindow.Pages.admin);
            }
            else if (mainWindow.RegexLogin(Login.Text))
            {
                if (mainWindow.RegexPassword(Password.Password))
                {
                    DataTable find = mainWindow.Select($"select * from Users where login='{Login.Text}' and password='{Password.Password}'");
                    if (find.Rows.Count > 0)
                    {
                        mainWindow.OpenPage(MainWindow.Pages.main);
                        mainWindow.login = Login.Text;
                        MessageBox.Show("Пользователь авторизовался");
                    }
                    else MessageBox.Show("Такого пользователя не существует");
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите логин");
        }
    }
}
