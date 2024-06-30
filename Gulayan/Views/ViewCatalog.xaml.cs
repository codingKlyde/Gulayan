using Gulayan.Controls.Catalog;
using Gulayan.DataContexts;
using Gulayan.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Gulayan.Views
{
    public partial class ViewCatalog : UserControl
    {
        public ObservableCollection<Product> DatabaseProducts { get; set; }

        private UpdateProductModal updateProductModal; // Declare an instance variable

        public ViewCatalog()
        {
            InitializeComponent();
            ReadProduct();
        }

        // Refresh Product
        public void ReadProduct()
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                DatabaseProducts = new ObservableCollection<Product>(context.Products.ToList());
                dtgrdVegetable.ItemsSource = DatabaseProducts;
            }
        }
        private void bttnRefresh_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ReadProduct();
        }

        // Delete Product
        public void DeleteProduct()
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                Product selectedProduct = dtgrdVegetable.SelectedItem as Product;

                if (selectedProduct != null)
                {
                    Product product = context.Products.Single(x => x.ProductID == selectedProduct.ProductID);

                    context.Products.Remove(product);
                    context.SaveChanges();
                    ReadProduct();
                    MessageBox.Show("Product deleted successfully!");
                }
            }
        }
        private void bttnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteProduct();
        }

        // Add Product
        public void AddProduct(Product newProduct)
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
            }
            ReadProduct();
        }
        private void OpenAddProductModal_Click(object sender, RoutedEventArgs e)
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

        // Update Product
        private void OpenUpdateProductModal_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Product selectedProduct = button.CommandParameter as Product;
                if (selectedProduct != null)
                    UpdateProductControl.SetProductDetails(selectedProduct);
            }

            if (UpdateModalContent.Visibility == Visibility.Collapsed)
                UpdateModalContent.Visibility = Visibility.Visible;
            else
                UpdateModalContent.Visibility = Visibility.Collapsed;
        }


        private void UpdateProductModal_ProductUpdated(object sender, Product newProduct)
        {
            ReadProduct();
            ModalContent.Visibility = Visibility.Collapsed;
        }
        

    }
}