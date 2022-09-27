using ServerServiceInterface;
using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

namespace ThreeDigitClient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool CheckIfRequiredDataIsGiven()
        {
            if (txtCompanyUsername.Visibility != Visibility.Hidden && txtCompanyUsername.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Provide Super Admin Username", "Login Failed");
                txtCompanyUsername.Focus();
                return false;
            }

            if (txtUsername.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Provide Username", "Login Failed");
                txtUsername.Focus();
                return false;
            }

            if (txtUsername.Text.Trim().Length < 3 || txtUsername.Text.Trim().Length > 8)
            {
                MessageBox.Show("Username should be 3 to 8 characters long", "Login Failed");
                txtUsername.Focus();
                return false;
            }

            if (pswPassword.Password.Trim().Length == 0)
            {
                MessageBox.Show("Please Provide Password", "Login Failed");
                pswPassword.Focus();
                return false;
            }

            if (pswPassword.Password.Trim().Length < 3 || pswPassword.Password.Trim().Length > 8)
            {
                MessageBox.Show("Password should be 3 to 8 characters long", "Login Failed");
                pswPassword.Focus();
                return false;
            }
            return true;
        }
        

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginToDashboard();
        }

        private void LoginToDashboard()
        {
            if (CheckIfRequiredDataIsGiven())
            {
                try
                {
                    CClientLocalInfo culi = new CClientLocalInfo();
                    culi.ClientDevice = "Computer";
                    culi.ClientDeviceCode = 1;
                    culi.CompanyId = 1;
                    culi.CompanyUsername = "sdf";
                    culi.UserType = 0;
                    culi.Username = txtUsername.Text.Trim();
                    culi.Password = pswPassword.Password.Trim();

                    using (ChannelFactory<IUserLogin> loginProxy = new ChannelFactory<ServerServiceInterface.IUserLogin>("UserLoginEndpoint"))
                    {
                        loginProxy.Open();
                        IUserLogin loginService = loginProxy.CreateChannel();
                        MessageBox.Show(loginService.GetLoginDetails("Heloo"));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + " | " + e.InnerException + " | " + e.Source);
                }
            }
        }

        private void pswPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginToDashboard();
            }
        }
        
    }
}
