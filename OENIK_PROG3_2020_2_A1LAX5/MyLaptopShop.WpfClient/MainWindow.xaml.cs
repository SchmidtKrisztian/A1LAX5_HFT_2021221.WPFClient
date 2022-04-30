using MyLaptopShop.WpfClient.WindowTables;
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

namespace MyLaptopShop.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            BrandWindow win = new BrandWindow();
            win.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LaptopWindow win = new LaptopWindow();
            win.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SpecificationWindow win = new SpecificationWindow();
            win.Show();
            Close();
        }
    }
}
