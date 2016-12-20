using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.LabelManager.UserControls
{
    /// <summary>
    /// Interaction logic for OrderProducts.xaml
    /// </summary>
    public partial class OrderProducts : Window
    {
        public List<CutItem> CutProducts { get; set; }
        private readonly CustomerBagGrid _customerBagGrid;

        public OrderProducts()
        {
        }

        public OrderProducts(List<CutItem> cutProducts, CustomerBagGrid customerBagGrid)
        {
            InitializeComponent();
            OrderProductsWindow.Height = 150 + cutProducts.Count*55;
            OrderProductsWindow.MaxHeight = 150 + ((cutProducts.Count/3) +1) * 50;
            CutProducts = cutProducts;
            _customerBagGrid = customerBagGrid;
            Products.ItemsSource = cutProducts;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var id = (int)button.Tag;
                _customerBagGrid.CutItem = CutProducts.FirstOrDefault(x=>x.ProductId == id);
                Close();
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            _customerBagGrid.BackOrderProducts(this);
        }
        

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
