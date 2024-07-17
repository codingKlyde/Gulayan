using Gulayan.Controls.Catalog;
using Gulayan.DataContexts;
using Gulayan.Models;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Gulayan.Views
{
    public partial class ViewCatalog : UserControl
    {
        public ObservableCollection<Product> DatabaseProducts { get; set; }
        private UpdateProductModal updateProductModal; 

        public ViewCatalog()
        {
            InitializeComponent();
        }

        private void bttnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
        
                try
                {
                    // Read from the text file
                    string[] lines = File.ReadAllLines(filePath);

                    // Process each line 
                    foreach (string line in lines)
                    {
                        string[] data = line.Split('|');

                        // Create a  object and populate properties
                        Product newProduct = new Product
                        {
                            ProductBatchNumber = data[0],
                            ProductCategory = data[1],
                            ProductDescription = data[2],
                            ProductExpirationDate = DateTime.Parse(data[3]),
                            ProductName = data[4],
                            ProductRecievedDate = DateTime.Parse(data[5]),
                            ProductSupplier = data[6],
                            ProductStock = int.Parse(data[7]),
                        };
                        AddProduct(newProduct); 
                    }
                    MessageBox.Show("Import successful!");
                    //ReadProduct();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error importing data: {ex.Message}");
                }
            }
        }

        // SEARCH BAR
        private void txtblckSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtblckSearchBar.Text.ToLower();

            var filteredProducts = DatabaseProducts.Where(find =>
                find.ProductBatchNumber.ToLower().Contains(searchText) ||
                find.ProductCategory.ToLower().Contains(searchText) ||
                find.ProductName.ToLower().Contains(searchText) ||
                find.ProductStock.ToString().ToLower().Contains(searchText)
                // DATE FILTER DOESN'T WORK
                // || find.ProductRecievedDate.ToString("MM/dd/yyyy").ToLower().Contains(searchText) ||
                // find.ProductExpirationDate.ToString("MM/dd/yyyy").ToLower().Contains(searchText)
            ).ToList();

            dtgrdVegetable.ItemsSource = filteredProducts;
        }

     

        // ADD
        public void AddProduct(Product newProduct)
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
            }
            //ReadProduct();
        }
        private void OpenAddProductModal_Click(object sender, RoutedEventArgs e)
        {
            if (ModalContent.Visibility == Visibility.Collapsed)
                ModalContent.Visibility = Visibility.Visible;
            else
                ModalContent.Visibility = Visibility.Collapsed;
        }
        // Executes during runtime
        private void AddProductControl_ProductAdded(object sender, Product newProduct)
        {
            AddProduct(newProduct);
            ModalContent.Visibility = Visibility.Collapsed;
        }

        // UPDATE
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
            //ReadProduct();
            ModalContent.Visibility = Visibility.Collapsed;
        }
    }
}   