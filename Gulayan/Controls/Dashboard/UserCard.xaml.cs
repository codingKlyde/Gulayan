using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gulayan.Controls.Dashboard
{
    public partial class UserCard : UserControl
    {
        public UserCard()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty StockProperty = DependencyProperty.Register("Stock", typeof(int), typeof(UserCard));
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(UserCard));
        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(string), typeof(UserCard));
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(UserCard));
      
        public int Stock
        {
            get { return (int)GetValue(StockProperty); }
            set { SetValue(StockProperty, value); }
        }
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public string Date
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
}