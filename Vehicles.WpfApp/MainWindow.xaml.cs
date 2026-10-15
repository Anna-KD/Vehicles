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
            carGarage.LogMessage += msg =>
            {
                txtLog.AppendText(msg + Environment.NewLine);
            };

            boatGarage.LogMessage += msg =>
            {
                txtLog.AppendText(msg + Environment.NewLine);
            };
        }

        private void btnCar_Click(object sender, RoutedEventArgs e)
        {
            Car car = new Car("Volvo", "V60");

            vehicles.Add(car);
            carGarage.Add(car);
        }

        private void btnBoat_Click(object sender, RoutedEventArgs e)
        {
            Boat boat = new Boat("Yamaha", "Boat");

            vehicles.Add(boat);
            boatGarage.Add(boat);
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
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbVehicles.SelectedItem == null)
                return;

            Vehicle vehicle = (Vehicle)lbVehicles.SelectedItem;

            vehicles.Remove(vehicle);

            if (vehicle is Car car)
                carGarage.Remove(car);

            if (vehicle is Boat boat)
                boatGarage.Remove(boat);
        }
        private Garage<Car> carGarage = new();
        private Garage<Boat> boatGarage = new();
        
    }
}