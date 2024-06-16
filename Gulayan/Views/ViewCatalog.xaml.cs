using Gulayan.Models;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Product> OCDatabaseProducts { get; set; }


        public void Read()
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                OCDatabaseProducts = new ObservableCollection<Product>(context.Products.ToList());
                dtgrdVegetable.ItemsSource = OCDatabaseProducts;
            }
        }
        private void bttnRefresh_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Read();
        }

        public void Delete()
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                Product selectedProduct = dtgrdVegetable.SelectedItem as Product;

                if (selectedProduct != null)
                {
                    Product product = context.Products.Single(x => x.ProductID == selectedProduct.ProductID);

                    context.Products.Remove(product);
                    context.SaveChanges();

                    Read();
                }
            }
        }
        private void bttnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }


        public void AddProduct(Product newProduct)
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
            }

            Read();
        }

        private void OpenAddProductControl_Click(object sender, RoutedEventArgs e)
        {

            if (ModalContent.Visibility == Visibility.Collapsed)
                ModalContent.Visibility = Visibility.Visible;
            else
                ModalContent.Visibility = Visibility.Collapsed;
        }

        // This method executes during runtime
        private void AddProductControl_ProductAdded(object sender, Product newProduct)
        {
            AddProduct(newProduct);
            ModalContent.Visibility = Visibility.Collapsed;
        }
    }
}