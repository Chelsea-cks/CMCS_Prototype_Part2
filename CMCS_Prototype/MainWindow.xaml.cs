using System.Windows;

namespace CMCS_Prototype
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new Views.DashboardPage(); 
        }

        private void BtnLecturer_Click(object sender, RoutedEventArgs e) => MainContent.Content = new LecturerDashboard();
        private void BtnCoordinator_Click(object sender, RoutedEventArgs e) => MainContent.Content = new Views.CoordinatorDashboard();
        private void BtnManager_Click(object sender, RoutedEventArgs e) => MainContent.Content = new Views.ManagerDashboard();
        private void BtnDashboard_Click(object sender, RoutedEventArgs e) => MainContent.Content = new Views.DashboardPage();
    }
}
