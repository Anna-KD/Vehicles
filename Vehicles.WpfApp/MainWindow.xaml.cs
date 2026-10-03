using System.Collections.ObjectModel;
using System.Windows;
using Vehicles.Core;

namespace Vehicles.WpfApp
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Vehicle> vehicles =
            new ObservableCollection<Vehicle>();

        public MainWindow()
        {
            InitializeComponent();

            lbVehicles.ItemsSource = vehicles;
        }

        private void btnCar_Click(object sender, RoutedEventArgs e)
        {
            vehicles.Add(new Car("Volvo", "V60"));
        }

        private void btnBoat_Click(object sender, RoutedEventArgs e)
        {
            vehicles.Add(new Boat("Yamaha", "Boat"));
        }

        private void btnAmphibious_Click(object sender, RoutedEventArgs e)
        {
            vehicles.Add(new AmphibiousCar("Gibbs", "Amphibian"));
        }

        private void btnMove_Click(object sender, RoutedEventArgs e)
        {
            if (lbVehicles.SelectedItem == null)
            {
                MessageBox.Show("Select a vehicle.");
                return;
            }

            if (!double.TryParse(txtDistance.Text, out double km))
            {
                MessageBox.Show("Enter a valid number.");
                return;
            }

            try
            {
                Vehicle vehicle = (Vehicle)lbVehicles.SelectedItem;

                string result = vehicle.Move(km);

                txtLog.AppendText(result + "\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}