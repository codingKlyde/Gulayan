using Gulayan.Models;
using System.Windows;
using System.Windows.Controls;

namespace Gulayan.Controls.Catalog
{
    public partial class AddProductModal : UserControl
    {
        public event EventHandler<Product> ProductAdded;
        private List<string> suppliers = new List<string> { "Supplier A", "Supplier B", "Supplier C", "Supplier D", "Supplier E" };
        private Random random = new Random();

        public AddProductModal()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
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

            if (!isValid)
                return;
      
            var addProduct = new Product
            {
                ProductBatchNumber = txtbxProductBatchNumber.Text,
                ProductCategory = (cmbbxProductCategory.SelectedItem as ComboBoxItem)?.Content.ToString(),
                ProductName = txtbxProductName.Text,
                ProductDescription = txtbxProductDescription.Text,
                ProductRecievedDate = (dtpckrRecievedDate.SelectedDate ?? DateTime.Now).Date,
                ProductExpirationDate = (dtpckrExpirationDate.SelectedDate ?? DateTime.Now).Date,
                ProductSupplier = txtbxProductSupplier.Text,
                ProductStock = stock
            };
            MessageBox.Show("Product added successfully!");
            ClearInputFields();
            // Invoke the ProductAdded event to notify other parts of the app (if any)
            ProductAdded?.Invoke(this, addProduct);
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