using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HealthCareCovid.pages;

namespace HealthCareCovid
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Home home_;
        public HealthCare healthCare_;
        public Appointment appointment_;
        public AvailableStructureDose availableStructureDose_;
        public MainWindow()
        {
           
            InitializeComponent();
            home_ = new Home();
            healthCare_ = new HealthCare();
            Main.Navigate(home_);

        }

        private void move_leftbuttondown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void reduire_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void fermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            Main.Navigate(home_);
        }

        private void Main_Navigated()
        {

        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void healthcare_Click(object sender, RoutedEventArgs e)
        {
            Main.Navigate(healthCare_);
        }

        private void appointment_Click(object sender, RoutedEventArgs e)
        {
            appointment_ = new Appointment();
            Main.Navigate(appointment_);
        }

        private void stockHealthCare_Click(object sender, RoutedEventArgs e)
        {
            availableStructureDose_ = new AvailableStructureDose();
            Main.Navigate(availableStructureDose_);
        }
    }
}
