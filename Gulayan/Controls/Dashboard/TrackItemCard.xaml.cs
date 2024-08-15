using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gulayan.Controls.Dashboard
{
    public partial class TrackItemCard : UserControl
    {
        public TrackItemCard()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ItemNameProperty = DependencyProperty.Register("ItemName", typeof(string), typeof(TrackItemCard));
        public static readonly DependencyProperty itemStockProperty = DependencyProperty.Register("ItemStock", typeof(string), typeof(TrackItemCard));

        public string ItemName
        {
            get { return (string)GetValue(ItemNameProperty); }
            set { SetValue(ItemNameProperty, value); }
        }
        public string ItemStock
        {
            get { return (string)GetValue(itemStockProperty); }
            set { SetValue(itemStockProperty, value); }
        }
    }
}
