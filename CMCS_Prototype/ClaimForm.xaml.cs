using System;
using System.Windows;
using CMCS_Prototype.Models;

namespace CMCS_Prototype.Views
{
    public partial class ClaimForm : Window
    {
        public ClaimForm()
        {
            InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var claim = new Claim
                {
                    LecturerName = LecturerNameBox.Text,
                    HoursWorked = double.Parse(HoursWorkedBox.Text),
                    HourlyRate = double.Parse(HourlyRateBox.Text),
                    Notes = NotesBox.Text
                };

                ClaimManager.AddClaim(claim);

                MessageBox.Show($"Claim for {claim.LecturerName} submitted successfully!\nTotal: R{claim.TotalAmount}",
                                "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                LecturerNameBox.Clear();
                HoursWorkedBox.Clear();
                HourlyRateBox.Clear();
                NotesBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
