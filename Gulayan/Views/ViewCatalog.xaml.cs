using Gulayan.Models;
using System.Windows;
using System.Windows.Controls;

namespace Gulayan.Views
{
    public partial class ViewCatalog : UserControl
    {
        public List<Product> DatabaseProducts { get; private set; }

        public ViewCatalog()
        {
            InitializeComponent();
        }
        


        public void Read()
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                DatabaseProducts = context.Products.ToList();
                lstvwProduct.ItemsSource = DatabaseProducts;
            }
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }
    }
}