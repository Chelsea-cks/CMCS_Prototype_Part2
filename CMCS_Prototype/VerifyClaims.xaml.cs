using System.Collections.Generic;
using System.Windows;
using CMCS_Prototype.Models;

namespace CMCS_Prototype.Views
{
    public partial class VerifyClaims : Window
    {
        private List<Claim> _claims;

        public VerifyClaims()
        {
            InitializeComponent();
            _claims = ClaimManager.Claims;
            ClaimsDataGrid.ItemsSource = _claims;
        }

        private void ApproveClaim_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsDataGrid.SelectedItem is Claim selected)
            {
                selected.Status = "Approved";
                ClaimsDataGrid.Items.Refresh();
                MessageBox.Show($"{selected.LecturerName}'s claim approved.", "Approved", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void RejectClaim_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsDataGrid.SelectedItem is Claim selected)
            {
                selected.Status = "Rejected";
                ClaimsDataGrid.Items.Refresh();
                MessageBox.Show($"{selected.LecturerName}'s claim rejected.", "Rejected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
