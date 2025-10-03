using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CMCS_Prototype.Services;

namespace CMCS_Prototype.Views
{
    public partial class DashboardPage : UserControl
    {
        public DashboardPage()
        {
            InitializeComponent();
            DgAll.ItemsSource = ClaimStore.Claims;
            UpdateCounts();
            
            ClaimStore.Claims.CollectionChanged += (s, e) => UpdateCounts();
        }

        private void UpdateCounts()
        {
            var all = ClaimStore.Claims;
            TxtSubmitted.Text = all.Count.ToString();
            TxtPending.Text = all.Count(c => c.Status == "Pending").ToString();
            TxtCoordApproved.Text = all.Count(c => c.Status == "Coordinator Approved").ToString();
            TxtManagerApproved.Text = all.Count(c => c.Status == "Manager Approved").ToString();
            TxtRejected.Text = all.Count(c => c.Status.Contains("Rejected")).ToString();

            DgAll.Items.Refresh();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e) => UpdateCounts();
    }
}
