using Gulayan.Controls.Catalog;
using Gulayan.DataContexts;
using Gulayan.Models;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Gulayan.Views
{
    public partial class ViewCatalog : UserControl
    {
        public ObservableCollection<Product> DatabaseProducts { get; set; }
        private UpdateProductModal updateProductModal; 

        public ViewCatalog()
        {
            InitializeComponent();
            ReadProduct();
            UpdateTotalProductCount();
        }

        // TOTAL PRODUCTS
        private int GetTotalProductCount()
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                return context.Products.Count();
            }
        }
        public void UpdateTotalProductCount()
        {
            try
            {
                int count = GetTotalProductCount();
                txtblckTotalProduct.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching total product count: {ex.Message}");
            }
        }


        // IMPORT
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
                    ReadProduct();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error importing data: {ex.Message}");
                }
            }
        }

        // PRINT
        private void bttnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                // Create a FlowDocument dynamically to print the DataGrid content
                FlowDocument doc = new FlowDocument();
                doc.PagePadding = new Thickness(50);
                doc.PageHeight = printDialog.PrintableAreaHeight;
                doc.PageWidth = printDialog.PrintableAreaWidth;

                Table table = new Table();
                doc.Blocks.Add(table);

                // Add columns to the table
                foreach (var column in dtgrdVegetable.Columns)
                {
                    table.Columns.Add(new TableColumn());
                }

                // Add the header row
                TableRowGroup headerGroup = new TableRowGroup();
                table.RowGroups.Add(headerGroup);
                TableRow headerRow = new TableRow();
                headerGroup.Rows.Add(headerRow);

                foreach (var column in dtgrdVegetable.Columns)
                {
                    headerRow.Cells.Add(new TableCell(new Paragraph(new Run(column.Header.ToString()))));
                }

                // Add the data rows
                TableRowGroup dataGroup = new TableRowGroup();
                table.RowGroups.Add(dataGroup);

                foreach (var item in dtgrdVegetable.Items)
                {
                    if (item is Product product)
                    {
                        TableRow dataRow = new TableRow();
                        dataGroup.Rows.Add(dataRow);

                        dataRow.Cells.Add(new TableCell(new Paragraph(new Run(product.ProductBatchNumber))));
                        dataRow.Cells.Add(new TableCell(new Paragraph(new Run(product.ProductName))));
                        dataRow.Cells.Add(new TableCell(new Paragraph(new Run(product.ProductRecievedDate.ToString("MM/dd/yyyy")))));
                        dataRow.Cells.Add(new TableCell(new Paragraph(new Run(product.ProductExpirationDate.ToString("MM/dd/yyyy")))));
                        dataRow.Cells.Add(new TableCell(new Paragraph(new Run(product.ProductStock.ToString()))));
                    }
                }

                IDocumentPaginatorSource idocument = doc;

                printDialog.PrintDocument(idocument.DocumentPaginator, "Printing DataGrid");
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

        // READ/REFRESH
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

        // DELETE
        public void DeleteProduct(Product product)
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                if (product != null)
                {
                    context.Products.Attach(product);
                    context.Products.Remove(product);
                    context.SaveChanges();
                    ReadProduct();
                    UpdateTotalProductCount();
                    MessageBox.Show("Product deleted successfully!");

                }
            }
        }
        private void bttnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Product selectedProduct = button?.CommandParameter as Product;
            if (selectedProduct != null)
            {
                DeleteProduct(selectedProduct);
            }
        }

        // ADD
        public void AddProduct(Product newProduct)
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
            }
            ReadProduct();
            UpdateTotalProductCount();
        }
        private void OpenAddProductModal_Click(object sender, RoutedEventArgs e)
        {
            UpdateModalContent.Visibility = Visibility.Collapsed;

            if (cntntcntrlAddModal.Visibility == Visibility.Collapsed)
                cntntcntrlAddModal.Visibility = Visibility.Visible;
            else
                cntntcntrlAddModal.Visibility = Visibility.Collapsed;
        }
        // This method executes during runtime
        private void AddProductControl_ProductAdded(object sender, Product newProduct)
        {
            AddProduct(newProduct);
            cntntcntrlAddModal.Visibility = Visibility.Collapsed;
        }

        // UPDATE
        private void bttnUpdate_Click(object sender, RoutedEventArgs e)
        {
            cntntcntrlAddModal.Visibility = Visibility.Collapsed;

            Button? button = sender as Button;
            if (button != null)
            {
                Product? selectedProduct = button.CommandParameter as Product;
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
            UpdateModalContent.Visibility = Visibility.Collapsed;
        }
    }
}