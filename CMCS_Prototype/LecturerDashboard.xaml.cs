using System.Windows;

namespace CMCS_Prototype.Views
{
    public partial class LecturerDashboard : Window
    {
        public LecturerDashboard()
        {
            InitializeComponent();
        }

        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            var claimForm = new ClaimForm();
            claimForm.Show();
            this.Close();
        }

        private void ViewClaims_Click(object sender, RoutedEventArgs e)
        {
            var verifyClaims = new VerifyClaims(); 
            verifyClaims.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
