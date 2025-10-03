using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CMCS_Prototype.Services;
using CMCS_Prototype.Models;

namespace CMCS_Prototype.Views
{
    public partial class CoordinatorDashboard : UserControl
    {
        public CoordinatorDashboard()
        {
            InitializeComponent();
            DgClaims.ItemsSource = ClaimStore.Claims;
        }

        private Claim? SelectedClaim => DgClaims.SelectedItem as Claim;

        private void BtnVerify_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClaim == null) { MessageBox.Show("Select a claim first."); return; }
            MessageBox.Show($"Verify details:\nLecturer: {SelectedClaim.LecturerName}\nAmount: {SelectedClaim.TotalAmount:C}\nNotes: {SelectedClaim.Notes}");
        }

        private void BtnApprove_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClaim == null) { MessageBox.Show("Select a claim first."); return; }
            SelectedClaim.Status = "Coordinator Approved";
            DgClaims.Items.Refresh();
            MessageBox.Show("Claim marked as Coordinator Approved.");
        }

        private void BtnReject_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClaim == null) { MessageBox.Show("Select a claim first."); return; }
            SelectedClaim.Status = "Coordinator Rejected";
            DgClaims.Items.Refresh();
            MessageBox.Show("Claim marked as Rejected.");
        }
    }
}
