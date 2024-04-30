using Gulayan.Models;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Gulayan
{
    public partial class CatalogWindow : Window
    {
        public List<Product> DatabaseProducts { get; private set; }

        public CatalogWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr nWnd, int WMsg, IntPtr wParam, IntPtr lParam); 

        private void stckpnlControlBar_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void bttnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void bttnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void bttnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void Read()
        {
            using (ProductDataContext context = new ProductDataContext())
            {
                DatabaseProducts = context.Products.ToList();
                lstvwProduct.ItemsSource = DatabaseProducts;
            }
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }
    }
}