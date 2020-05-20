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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public MainWindow mainWindow;
        public AdminPage(MainWindow _mw)
        {
            InitializeComponent();
            mainWindow = _mw;
        }

        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            CategoryAdd add = new CategoryAdd();
            add.Show();
        }

        private void Prices_Click(object sender, RoutedEventArgs e)
        {
            addPrice addPrice = new addPrice();
            addPrice.Show();
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            ProductAdd add = new ProductAdd();
            add.Show();
        }
    }
}
