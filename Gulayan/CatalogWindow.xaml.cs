using System.Windows;

namespace Gulayan
{
    public partial class CatalogWindow : Window
    {
        public List<Product> DatabaseProducts { get; private set; }

        public CatalogWindow()
        {
            InitializeComponent();
        }

        public void Read()
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                DatabaseProducts = context.Products.ToList();
                ItemList.ItemsSource = DatabaseProducts;
            }

        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

    
    }
}
