using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CMCS_Prototype.Models;
using CMCS_Prototype.Services;

namespace CMCS_Prototype.Views
{
    public partial class ManagerDashboard : UserControl
    {
        public ManagerDashboard()
        {
            InitializeComponent();
            DgToReview.ItemsSource = ClaimStore.Claims;
            RefreshFilter();
        }

        private void RefreshFilter()
        {
            // Only show those that coordinator approved (manager should act on those)
            DgToReview.ItemsSource = ClaimStore.Claims.Where(c => c.Status == "Coordinator Approved").ToList();
        }

        private Claim? SelectedClaim => DgToReview.SelectedItem as Claim;

        private void BtnFinalApprove_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClaim == null) { MessageBox.Show("Select a claim first."); return; }
            SelectedClaim.Status = "Manager Approved";
            MessageBox.Show("Claim final-approved.");
            RefreshFilter();
        }

        private void BtnManagerReject_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClaim == null) { MessageBox.Show("Select a claim first."); return; }
            SelectedClaim.Status = "Manager Rejected";
            MessageBox.Show("Claim rejected by manager.");
            RefreshFilter();
        }
    }
}
