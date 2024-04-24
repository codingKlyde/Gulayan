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

            using (UserDataContext context = new UserDataContext())
            {
                bool userFound = context.Users.Any(user => user.DataUsername == inputUsername && user.DataPassword == inputPassword);

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
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
