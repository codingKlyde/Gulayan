using System.Windows.Controls;
using Gulayan.DataContexts;

namespace Gulayan.Views
{
    public partial class ViewDashboard : UserControl
    {
        public ViewDashboard()
        {
            InitializeComponent();
            TotalProduct();
        }

        public void TotalProduct()
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                int count = context.Products.Count();
                txtblckTotalProduct.Text = count.ToString();
            }
        }
    }
}