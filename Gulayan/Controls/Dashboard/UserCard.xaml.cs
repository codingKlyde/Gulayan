﻿using System.Windows;
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

        public static readonly DependencyProperty DownPriceProperty = DependencyProperty.Register("DownPrice", typeof(string), typeof(UserCard));
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(UserCard));
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(UserCard));
        public static readonly DependencyProperty UpPriceProperty = DependencyProperty.Register("UpPrice", typeof(string), typeof(UserCard));
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(UserCard));
      
        public string DownPrice
        {
            get { return (string)GetValue(DownPriceProperty); }
            set { SetValue(DownPriceProperty, value); }
        }
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }
        public string UpPrice
        {
            get { return (string)GetValue(UpPriceProperty); }
            set { SetValue(UpPriceProperty, value); }
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
}