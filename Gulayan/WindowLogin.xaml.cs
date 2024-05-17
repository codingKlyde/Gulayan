using System.Windows;
using System.Windows.Input;
namespace Gulayan
{
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
        }

        // CONTROL BAR
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

        // LOGIN 
        private void txtblckUsername_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtbxUsername.Focus();
        }
        private void txtbxUsername_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbxUsername.Text) && txtbxUsername.Text.Length > 0)
                txtblckUsername.Visibility = Visibility.Visible;
            else
                txtblckUsername.Visibility = Visibility.Collapsed;
        }
        private void txtblckPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            psswrdbxPassword.Focus();
        }
        private void psswrdbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(psswrdbxPassword.Password) && psswrdbxPassword.Password.Length > 0)
                txtblckPassword.Visibility = Visibility.Visible;
            else
                txtblckPassword.Visibility = Visibility.Collapsed;
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
            WindowMenu main = new WindowMenu();
            main.Show();
        }
    }
}