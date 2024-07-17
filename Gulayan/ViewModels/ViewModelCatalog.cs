using Gulayan.DataContexts;
using Gulayan.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Gulayan.ViewModels
{
    public class ViewModelCatalog : ViewModelBase
    {
        private ObservableCollection<Product> _databaseProducts;
        public ObservableCollection<Product> DatabaseProducts
        {
            get { return _databaseProducts; }
            set
            {
                _databaseProducts = value;
                OnPropertyChanged(nameof(DatabaseProducts));
            }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));

                // Update CanExecute for commands that depend on SelectedProduct
                ((RelayCommand)DeleteProductCommand).RaiseCanExecuteChanged();
                ((RelayCommand)UpdateProductCommand).RaiseCanExecuteChanged();
            }
        }

        // Commands
        public ICommand RefreshCommand { get; private set; }
        public ICommand AddProductCommand { get; private set; }
        public ICommand DeleteProductCommand { get; private set; }
        public ICommand UpdateProductCommand { get; private set; }

        public ViewModelCatalog()
        {
            RefreshCommand = new RelayCommand(Refresh);
            AddProductCommand = new RelayCommand(AddProduct);
            DeleteProductCommand = new RelayCommand(DeleteProduct, CanDeleteProduct);
            UpdateProductCommand = new RelayCommand(UpdateProduct);

            Refresh(null);
        }


        // READ
        private void Refresh(object parameter)
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                DatabaseProducts = new ObservableCollection<Product>(context.Products);
            }
        }

        // DELETE
        private void DeleteProduct(object parameter)
        {
            if (SelectedProduct != null)
            {
                using (ProductDataContext context = new ProductDataContext())
                {
                    Product product = context.Products.Find(SelectedProduct.ProductID);

                    if (product != null)
                    {
                        context.Products.Remove(product);
                        context.SaveChanges();
                        Refresh(null);
                        MessageBox.Show("Product deleted successfully!");
                    }
                }
            }
        }
        // Can execute method for delete command
        private bool CanDeleteProduct(object parameter)
        {
            return SelectedProduct != null;
        }







        // Method to update a product
        private void UpdateProduct(object parameter)
        {
            // Implement your logic to update a product
            MessageBox.Show("Update product logic here");
        }
        // Can execute method for update command
        private bool CanUpdateProduct(object parameter)
        {
            return SelectedProduct != null;
        }

        // Method to add a new product
        private void AddProduct(object parameter)
        {
            // Implement your logic to add a new product
            MessageBox.Show("Add product logic here");
        }
    }
}