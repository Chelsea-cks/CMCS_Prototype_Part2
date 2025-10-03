using System;
using System.ComponentModel;

namespace CMCS_Prototype.Models
{
    public class Claim : INotifyPropertyChanged
    {
        public Guid Id { get; } = Guid.NewGuid();

        private string _lecturerName = string.Empty;
        public string LecturerName
        {
            get => _lecturerName;
            set { _lecturerName = value; OnPropertyChanged(nameof(LecturerName)); }
        }

        private double _hoursWorked;
        public double HoursWorked
        {
            get => _hoursWorked;
            set { _hoursWorked = value; OnPropertyChanged(nameof(HoursWorked)); OnPropertyChanged(nameof(TotalAmount)); }
        }

        private double _hourlyRate;
        public double HourlyRate
        {
            get => _hourlyRate;
            set { _hourlyRate = value; OnPropertyChanged(nameof(HourlyRate)); OnPropertyChanged(nameof(TotalAmount)); }
        }

        public double TotalAmount => Math.Round(HoursWorked * HourlyRate, 2);

        private string _notes = string.Empty;
        public string Notes
        {
            get => _notes;
            set { _notes = value; OnPropertyChanged(nameof(Notes)); }
        }

        private string _status = "Pending";
        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(nameof(Status)); }
        }

        private string _supportingDocumentPath = string.Empty;
        public string SupportingDocumentPath
        {
            get => _supportingDocumentPath;
            set { _supportingDocumentPath = value; OnPropertyChanged(nameof(SupportingDocumentPath)); }
        }

        public DateTime SubmittedOn { get; set; } = DateTime.UtcNow;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
