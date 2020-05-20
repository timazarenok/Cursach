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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public MainWindow mainWindow;
        public Main(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            InputListBox();
        }

        private void InputListBox()
        {
            DataTable products = mainWindow.Select("select Products.[name], Categories.[name] as category, [description], Prices.[value] as price from Products join Categories on Categories.id=categoryId join Prices on Prices.productId = Products.id");
            List<Product> items = new List<Product>();
            foreach(DataRow dr in products.Rows)
            {
                items.Add(new Product() { Name = dr["name"].ToString(), Category = dr["category"].ToString(), Description = dr["description"].ToString(), Price = dr["price"].ToString() });
            }
            Items.ItemsSource = items;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.login);
        }

        private void Cart(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.Pages.cart);
        }  

        private void Items_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Items.SelectedItem = sender;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CartAddWindow cartAdd = new CartAddWindow();
            cartAdd.Name.Content += (Items.SelectedItem as Product).Name;
            cartAdd.Price.Content += (Items.SelectedItem as Product).Price;
            cartAdd.Id = mainWindow.GetUserId();
            try
            {
                cartAdd.Show();
            }
            catch(Exception error)
            {
                MessageBox.Show("Выбирете продукт");
            }
        }
    }
}
