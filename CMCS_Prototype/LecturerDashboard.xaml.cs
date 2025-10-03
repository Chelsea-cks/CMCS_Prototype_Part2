using CMCS_Prototype.Models;
using CMCS_Prototype.Services;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;

namespace CMCS_Prototype
{
    public partial class LecturerDashboard : Window
    {
        public LecturerDashboard()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string lecturer = TxtLecturerName.Text.Trim();
                if (string.IsNullOrWhiteSpace(lecturer))
                {
                    MessageBox.Show("Lecturer name is required.");
                    return;
                }

                if (!double.TryParse(TxtHours.Text, out double hours) || hours <= 0)
                {
                    MessageBox.Show("Enter valid hours greater than 0.");
                    return;
                }

                if (!double.TryParse(TxtRate.Text, out double rate) || rate <= 0)
                {
                    MessageBox.Show("Enter valid hourly rate greater than 0.");
                    return;
                }

                Claim newClaim = new Claim
                {
                    LecturerName = lecturer,
                    HoursWorked = hours,
                    HourlyRate = rate,
                    Notes = TxtNotes.Text,
                    Status = "Pending",
                    SubmittedOn = DateTime.Now
                };

                ClaimStore.Claims.Add(newClaim);
                MessageBox.Show("Claim submitted successfully!");

                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting claim: " + ex.Message);
            }
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Documents (*.pdf;*.docx;*.xlsx)|*.pdf;*.docx;*.xlsx"
            };

            if (dlg.ShowDialog() == true)
            {
                UploadFileName.Text = System.IO.Path.GetFileName(dlg.FileName);

                // Attach to the last submitted claim
                if (ClaimStore.Claims.Any())
                {
                    ClaimStore.Claims.Last().SupportingDocumentPath = dlg.FileName;
                }
            }
        }

        private void BtnTrack_Click(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            DgMyClaims.ItemsSource = null;
            DgMyClaims.ItemsSource = ClaimStore.Claims
                .Where(c => c.LecturerName == TxtLecturerName.Text.Trim())
                .ToList();
        }
    }
}
