using System.Windows;
using System.Windows.Controls;
using Gulayan.Controls.Dashboard;
using Gulayan.DataContexts;
using Gulayan.Models;

namespace Gulayan.Views
{
    public partial class ViewDashboard : UserControl
    {
        public ViewDashboard()
        {
            InitializeComponent();
            UpdateRecentProducts();
        }

        // NEW PRODUCT SECTION
        private List<Product> GetRecentProducts()
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                return context.Products
                    .OrderByDescending(p => p.ProductRecievedDate)
                    .Take(3)
                    .ToList();
            }
        }
        public void UpdateRecentProducts()
        {
            try
            {
                var recentProducts = GetRecentProducts();

                // Assuming you have a collection in the ViewModel for recent products
                if (recentProducts != null && recentProducts.Count > 0)
                {
                    // Update each card with the respective product
                    if (recentProducts.Count > 0)
                    {
                        newitemCard1.ItemName = recentProducts[0].ProductName;
                        newitemCard1.ItemRecievedDate = recentProducts[0].ProductRecievedDate.ToString("MM/dd/yy");
                        newitemCard1.ItemStock = recentProducts[0].ProductStock.ToString();
                        //newitemCard1.ItemThumbnail = recentProducts[0].ProductThumbnail; // Assuming you have a thumbnail property
                    }
                    if (recentProducts.Count > 1)
                    {
                        newitemCard2.ItemName = recentProducts[1].ProductName;
                        newitemCard2.ItemRecievedDate = recentProducts[1].ProductRecievedDate.ToString("MM/dd/yy");
                        newitemCard2.ItemStock = recentProducts[1].ProductStock.ToString();
                        //newitemCard2.ItemThumbnail = recentProducts[1].ProductThumbnail;
                    }
                    if (recentProducts.Count > 2)
                    {
                        newitemCard3.ItemName = recentProducts[2].ProductName;
                        newitemCard3.ItemRecievedDate = recentProducts[2].ProductRecievedDate.ToString("MM/dd/yy");
                        newitemCard3.ItemStock = recentProducts[2].ProductStock.ToString();
                        //newitemCard3.ItemThumbnail = recentProducts[2].ProductThumbnail;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching recent products: {ex.Message}");
            }
        }
    }
}