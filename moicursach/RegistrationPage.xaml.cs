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

namespace moicursach
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public MainWindow mainWindow;
        public RegistrationPage(MainWindow _mw)
        {
            InitializeComponent();
            mainWindow = _mw;
        }

        private void ConrirmClick(object sender, RoutedEventArgs e)
        {
            if(mainWindow.RegexLogin(Login.Text))
            {
                if(mainWindow.RegexPassword(Password.Password))
                {
                    if (RepeatPassword.Password.Equals(Password.Password))
                    {
                        if(mainWindow.Add($"insert into Users values('{Login.Text}', '{Password.Password}')"))
                        {
                            MessageBox.Show("Успешно создан");
                            mainWindow.OpenPage(MainWindow.Pages.main);
                        }
                    } 
                    else MessageBox.Show("Пароли не совпадают");
                }
                else MessageBox.Show("Пароль обязан быть 8-20 символовв");
            }
            else MessageBox.Show("Логин обязан быть 4-15 символов");
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.login);
        }
    }
}
