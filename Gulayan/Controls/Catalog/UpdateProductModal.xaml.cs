using Gulayan.DataContexts;
using Gulayan.Models;
using System.Windows;
using System.Windows.Controls;

namespace Gulayan.Controls.Catalog
{
    public partial class UpdateProductModal : UserControl
    {
        public event EventHandler<Product> ProductUpdated;
        private Product selectedProduct; // Store selected product details
        private List<string> suppliers = new List<string> { "Supplier A", "Supplier B", "Supplier C", "Supplier D", "Supplier E" };
        private Random random = new Random();

        public UpdateProductModal()
        {
            InitializeComponent();
        }

        // Method to set product details when modal is opened for update
        public void SetProductDetails(Product product)
        {
            selectedProduct = product;

            // Populate fields with product details
            txtbxProductBatchNumber.Text = selectedProduct.ProductBatchNumber;
            // Set selected category in combobox
            SelectComboBoxItem(cmbbxProductCategory, selectedProduct.ProductCategory);
            txtbxProductName.Text = selectedProduct.ProductName;
            txtbxProductDescription.Text = selectedProduct.ProductDescription;
            dtpckrRecievedDate.SelectedDate = selectedProduct.ProductRecievedDate;
            dtpckrExpirationDate.SelectedDate = selectedProduct.ProductExpirationDate;
            txtbxProductSupplier.Text = selectedProduct.ProductSupplier;
            txtbxProductStock.Text = selectedProduct.ProductStock.ToString();
        }

        // Utility method to select item in ComboBox by text
        private void SelectComboBoxItem(ComboBox comboBox, string itemText)
        {
            foreach (ComboBoxItem item in comboBox.Items)
            {
                if (item.Content.ToString() == itemText)
                {
                    comboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            ClearErrorMessages();

            bool isValid = true;

            // Validate Batch Number
            if (string.IsNullOrWhiteSpace(txtbxProductBatchNumber.Text))
            {
                ShowErrorMessage(txtblckBatchNumberError, "Batch Number is required.");
                isValid = false;
            }
            // Validate Category
            if (cmbbxProductCategory.SelectedItem == null)
            {
                ShowErrorMessage(txtblckCategoryError, "Please select a category.");
                isValid = false;
            }
            // Validate Name
            if (string.IsNullOrWhiteSpace(txtbxProductName.Text))
            {
                ShowErrorMessage(txtblckNameError, "Name is required.");
                isValid = false;
            }
            else if (txtbxProductName.Text.Length < 6)
            {
                ShowErrorMessage(txtblckNameError, "Name must be at least 6 characters.");
                isValid = false;
            }
            // Set default description if the field is empty
            if (string.IsNullOrWhiteSpace(txtbxProductDescription.Text))
                txtbxProductDescription.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris vestibulum ultricies malesuada. In id varius odio. Cras eget dictum nunc.";
            // Validate Received Date
            if (dtpckrRecievedDate.SelectedDate == null)
            {
                ShowErrorMessage(txtblckReceivedDateError, "Received date is required.");
                isValid = false;
            }
            // Validate Expiration Date
            if (dtpckrExpirationDate.SelectedDate == null)
            {
                ShowErrorMessage(txtblckExpirationDateError, "Expiration date is required.");
                isValid = false;
            }
            else if (dtpckrRecievedDate.SelectedDate != null && dtpckrExpirationDate.SelectedDate <= dtpckrRecievedDate.SelectedDate)
            {
                ShowErrorMessage(txtblckExpirationDateError, "Expiration date must be later than the received date.");
                isValid = false;
            }
            // Validate Stock
            if (!int.TryParse(txtbxProductStock.Text, out int stock) || stock <= 0)
            {
                ShowErrorMessage(txtblckStockError, "Please enter a valid number for stock.");
                isValid = false;
            }

            if (!isValid) return;

            // Update selectedProduct with new values
            selectedProduct.ProductBatchNumber = txtbxProductBatchNumber.Text;
            selectedProduct.ProductCategory = (cmbbxProductCategory.SelectedItem as ComboBoxItem)?.Content.ToString();
            selectedProduct.ProductName = txtbxProductName.Text;
            selectedProduct.ProductDescription = txtbxProductDescription.Text;
            selectedProduct.ProductRecievedDate = dtpckrRecievedDate.SelectedDate.Value;
            selectedProduct.ProductExpirationDate = dtpckrExpirationDate.SelectedDate.Value;
            selectedProduct.ProductSupplier = txtbxProductSupplier.Text;
            selectedProduct.ProductStock = stock;

            // Save changes to the database
            using (ProductDataContext context = new ProductDataContext())
            {
                context.Products.Update(selectedProduct);
                context.SaveChanges();
            }

            MessageBox.Show("Product updated successfully!");
            ClearInputFields();

            // Invoke the ProductUpdated event to notify other parts of the app
            ProductUpdated?.Invoke(this, selectedProduct);
        }
        private void btnRandomizeSupplier_Click(object sender, RoutedEventArgs e)
        {
            int index = random.Next(suppliers.Count);
            txtbxProductSupplier.Text = suppliers[index];
        }
        private void ClearInputFields()
        {
            txtbxProductBatchNumber.Text = "";
            cmbbxProductCategory.SelectedIndex = -1;
            txtbxProductName.Text = "";
            txtbxProductDescription.Text = "";
            dtpckrRecievedDate.SelectedDate = null;
            dtpckrExpirationDate.SelectedDate = null;
            txtbxProductSupplier.Text = "";
            txtbxProductStock.Text = "";
        }
        private void ClearErrorMessages()
        {
            txtblckBatchNumberError.Visibility = Visibility.Collapsed;
            txtblckCategoryError.Visibility = Visibility.Collapsed;
            txtblckNameError.Visibility = Visibility.Collapsed;
            txtblckReceivedDateError.Visibility = Visibility.Collapsed;
            txtblckExpirationDateError.Visibility = Visibility.Collapsed;
            txtblckStockError.Visibility = Visibility.Collapsed;
        }
        private void ShowErrorMessage(TextBlock errorTextBlock, string errorMessage)
        {
            errorTextBlock.Text = errorMessage;
            errorTextBlock.Visibility = Visibility.Visible;
        }
    }
}
