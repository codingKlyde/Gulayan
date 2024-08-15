using MahApps.Metro.IconPacks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gulayan.Controls.Dashboard
{
    public partial class StatisticCard : UserControl
    {
        public StatisticCard()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ItemBackgroundProperty = DependencyProperty.Register("ItemBackground", typeof(Brush), typeof(StatisticCard));
        public static readonly DependencyProperty ItemCaptionProperty = DependencyProperty.Register("ItemCaption", typeof(string), typeof(StatisticCard));
        public static readonly DependencyProperty ItemDataProperty = DependencyProperty.Register("ItemData", typeof(int), typeof(StatisticCard));
        public static readonly DependencyProperty ItemIconProperty = DependencyProperty.Register("ItemIcon", typeof(PackIconMaterialKind), typeof(StatisticCard));

        public Brush ItemBackground
        {
            get { return (Brush)GetValue(ItemBackgroundProperty); }
            set { SetValue(ItemBackgroundProperty, value); }
        }
        public string ItemCaption
        {
            get { return (string)GetValue(ItemCaptionProperty); }
            set { SetValue(ItemCaptionProperty, value); }
        }
        public int ItemData
        {
            get { return (int)GetValue(ItemDataProperty); }
            set { SetValue(ItemDataProperty, value); }
        }
        public PackIconMaterialKind ItemIcon
        {
            get { return (PackIconMaterialKind)GetValue(ItemIconProperty); }
            set { SetValue(ItemIconProperty, value); }
        }
    }
}