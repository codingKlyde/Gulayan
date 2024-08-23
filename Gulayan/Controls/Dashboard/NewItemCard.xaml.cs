using Gulayan.DataContexts;
using Gulayan.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gulayan.Controls.Dashboard
{
    public partial class NewItemCard : UserControl
    {
        public NewItemCard()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ItemNameProperty = DependencyProperty.Register("ItemName", typeof(string), typeof(NewItemCard));
        public static readonly DependencyProperty ItemRecievedDateProperty = DependencyProperty.Register("ItemRecievedDate", typeof(string), typeof(NewItemCard));
        public static readonly DependencyProperty itemStockProperty = DependencyProperty.Register("ItemStock", typeof(string), typeof(NewItemCard));
        public static readonly DependencyProperty itemThumbnailProperty = DependencyProperty.Register("ItemThumbnail", typeof(ImageSource), typeof(NewItemCard));

        public string ItemName
        {
            get { return (string)GetValue(ItemNameProperty); }
            set { SetValue(ItemNameProperty, value); }
        }
        public string ItemRecievedDate
        {
            get { return (string)GetValue(ItemRecievedDateProperty); }
            set { SetValue(ItemRecievedDateProperty, value); }
        }
        public string ItemStock
        {
            get { return (string)GetValue(itemStockProperty); }
            set { SetValue(itemStockProperty, value); }
        }
        public ImageSource ItemThumbnail
        {
            get { return (ImageSource)GetValue(itemThumbnailProperty); }
            set { SetValue(itemThumbnailProperty, value); }
        }
    }
}