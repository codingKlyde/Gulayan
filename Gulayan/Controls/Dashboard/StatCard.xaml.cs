using MahApps.Metro.IconPacks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gulayan.Controls.Dashboard
{
    public partial class StatCard : UserControl
    {
        public StatCard()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty BackgroundColorProperty = 
            DependencyProperty.Register("StatCardBackground", typeof(Brush), typeof(StatCard));
        public Brush StatCardBackground
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        public static readonly DependencyProperty DataProperty = 
            DependencyProperty.Register("StatCardData", typeof(int), typeof(StatCard));
        public int StatCardData
        {
            get { return (int)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = 
            DependencyProperty.Register("StatCardTitle", typeof(string), typeof(StatCard));
        public string StatCardTitle
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = 
            DependencyProperty.Register("StatCardIcon", typeof(PackIconMaterialKind), typeof(StatCard));
        public PackIconMaterialKind StatCardIcon
        {
            get { return (PackIconMaterialKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
    }
}