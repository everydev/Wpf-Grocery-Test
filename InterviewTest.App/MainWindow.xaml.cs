using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace InterviewTest.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductStore _productStore;

        public MainWindow()
        {
            InitializeComponent();
            _productStore = ServiceProvider.Instance.ProductStore;
        }
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            ServiceProvider.Instance.ProductStore.LoadProducts();
            _type.ItemsSource = ServiceProvider.Instance.ProductTypes;
            _productList.ItemsSource = ServiceProvider.Instance.ProductStore;
        }
        private void _unitprice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");
            e.Handled = !regex.IsMatch(e.Text);
        }


        private void btAddProduct(object sender, RoutedEventArgs e)
        {
            String name = _name.Text;
            if (!String.IsNullOrEmpty(_type.Text) && int.TryParse(_unitprice.Text, out int up) && int.TryParse(_quantity.Text, out int qty))
            {
                var p = ServiceProvider.Instance.CreateOBject(_type.Text, _name.Text, qty, up);
                ServiceProvider.Instance.ProductStore.Add(p);
                _productList.Items.Refresh();
                //_productList.ItemsSource
            }
        }

        private void _quantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Load availbility of products
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckAvailbilities(object sender, RoutedEventArgs e)
        {
            ServiceProvider.Instance.CheckAvailibilities();
            bool anyError = ServiceProvider.Instance.messages.Count > 0;

            if (!anyError)
            {
                MessageBox.Show(this, "Everything is available.");
            }
            else
            {
                MessageBox.Show(this, string.Join(System.Environment.NewLine, ServiceProvider.Instance.messages.ToArray()));
            }
        }
    }
}
