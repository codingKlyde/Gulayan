using Gulayan.Models;
using System.Windows;
using System.Windows.Controls;

namespace Gulayan.Controls.Catalog
{
    public partial class ModalAddProduct : UserControl
    {
        public event EventHandler<Product> ProductAdded;

        public ModalAddProduct()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            int stock;

            if (!int.TryParse(txtbxProductStock.Text, out stock))
            {
                MessageBox.Show("Please enter valid numbers for Stock.");
                return;
            }

            var newProduct = new Product
            {
                ProductBatchNumber = txtbxProductBatchNumber.Text,
                ProductCategory = txtbxProductCategory.Text,
                ProductName = txtbxProductName.Text,
                ProductDescription = txtbxProductDescription.Text,
                ProductRecievedDate = (dtpckrRecievedDate.SelectedDate ?? DateTime.Now).Date,
                ProductExpirationDate = (dtpckrExpirationDate.SelectedDate ?? DateTime.Now).Date,
                ProductSupplier = txtbxProductSupplier.Text,
                ProductStock = stock
            };

            ProductAdded?.Invoke(this, newProduct);
        }
    }
}