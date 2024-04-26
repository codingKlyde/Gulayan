using System.Windows;

namespace Gulayan
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
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
