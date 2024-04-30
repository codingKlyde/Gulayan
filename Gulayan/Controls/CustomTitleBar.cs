using System.Windows;
using System.Windows.Controls;

namespace Gulayan.Controls
{
    public class CustomTitleBar : Control
    {
        static CustomTitleBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomTitleBar), new FrameworkPropertyMetadata(typeof(CustomTitleBar)));
        }
    }
}
