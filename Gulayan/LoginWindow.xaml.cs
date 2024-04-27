using System.Windows;
using System.Windows.Input;

namespace Gulayan
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) 
                DragMove();
        }

        private void bttnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void bttnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }





        private void bttnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var inputUsername = txtbxUsername.Text;
            var inputPassword = psswrdbxPassword.Password;

            using (AdminDataContext context = new AdminDataContext())
            {
                bool userFound = context.Admins.Any(user => user.AdminUsername == inputUsername && user.AdminPassword == inputPassword);

                if (userFound)
                {
                    GainAccess();
                    Close();
                }
                else
                    MessageBox.Show("User not found!");
            }
        }

        public void GainAccess()
        {
            CatalogWindow main = new CatalogWindow();
            main.Show();
        }

     
    }
}
