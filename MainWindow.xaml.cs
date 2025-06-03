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

namespace MTZainIqbal
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private List<Vehicle> vehicles;
		private List<Vehicle> originalvehicles;

		public MainWindow()
		{
			InitializeComponent();

			vehicles = new List<Vehicle>()
			{
			new Car(0, "Honda Civic", 69.9, "Sedan", "Standard", false),
			new Car(1, "Toyota Corola", 69.9, "Sedan", "Standard", false),
			new Car(2, "Ford Explorer", 99.9, "SUV", "Standard", true),
			new Car(3, "Nissan Versa", 49.9, "Hatchback", "Standard", false),
			new Car(4, "Hyundai Tucson", 89.9, "SUV", "Standard", true),
			new Car(5, "Lamborghini Aventador", 189.9, "Sports", "Exotic", false),
			new Car(6, "Ferrari 488 GTB", 179.9, "Sports", "Exotic", false),
			new Car(7, "Mclaren P1", 199.9, "Sports", "Exotic", true),
			new Motorcycle(8, "Suzuki Boulevard M109R", 49.9, "Cruiser", "Bike", false),
			new Motorcycle(9, "Harley-Davidson Street Glide", 79.9, "Cruiser", "Bike", true),
			new Motorcycle(10, "Honda CRF125", 39.9, "Dirt", "Bike", true),
			new Motorcycle(11, "Ducati Monster", 69.9, "Sports", "Bike", false),
			new Motorcycle(12, "Can-Am Spyder", 59.9, "Cruiser", "Trike", true),
			new Motorcycle(13, "Polaris Slingshot", 69.9, "Cruiser", "Trike", false)
			};

			originalvehicles = new List<Vehicle>()
			{
			new Car(0, "Honda Civic", 69.9, "Sedan", "Standard", false),
			new Car(1, "Toyota Corola", 69.9, "Sedan", "Standard", false),
			new Car(2, "Ford Explorer", 99.9, "SUV", "Standard", true),
			new Car(3, "Nissan Versa", 49.9, "Hatchback", "Standard", false),
			new Car(4, "Hyundai Tucson", 89.9, "SUV", "Standard", true),
			new Car(5, "Lamborghini Aventador", 189.9, "Sports", "Exotic", false),
			new Car(6, "Ferrari 488 GTB", 179.9, "Sports", "Exotic", false),
			new Car(7, "Mclaren P1", 199.9, "Sports", "Exotic", true),
			new Motorcycle(8, "Suzuki Boulevard M109R", 49.9, "Cruiser", "Bike", false),
			new Motorcycle(9, "Harley-Davidson Street Glide", 79.9, "Cruiser", "Bike", true),
			new Motorcycle(10, "Honda CRF125", 39.9, "Dirt", "Bike", true),
			new Motorcycle(11, "Ducati Monster", 69.9, "Sports", "Bike", false),
			new Motorcycle(12, "Can-Am Spyder", 59.9, "Cruiser", "Trike", true),
			new Motorcycle(13, "Polaris Slingshot", 69.9, "Cruiser", "Trike", false)
			};
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			RefreshListBox();
		}

		private void RefreshListBox()
		{
			var names = from veh in vehicles
						select veh.Name;

			lstVehicles.ItemsSource = names;
		}

		private void lstVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (lstVehicles.SelectedItem != null)
			{
				var selectedVeh = (from veh in vehicles
								   where veh.Id == lstVehicles.SelectedIndex
								   select veh).FirstOrDefault();

				txtId.Text = selectedVeh.Id.ToString();
				txtName.Text = selectedVeh.Name;
				txtRentalPrice.Text = selectedVeh.RentalPrice.ToString();
				txtCategory.Text = selectedVeh.Category;
				txtType.Text = selectedVeh.Type;
				chkIsReserved.IsChecked = selectedVeh.IsReserved;

				if (txtType.Text == "Standard" | txtType.Text == "Exotic")
				{
					rdoCar.IsChecked = true;
				}
				else
				{
					rdoMotorcycle.IsChecked = true;
				}

			}

		}
		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			double rp;
			if (txtName.Text == "")
			{
				MessageBox.Show("Please enter a value in the name field", "Name Blank", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else if (txtRentalPrice.Text == "")
			{
				MessageBox.Show("Please enter a value in the RentalPrice field", "RentalPrice Blank", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else if (txtRentalPrice.Text == "")
			{
				MessageBox.Show("Please enter a value in the Category field", "Category Blank", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else if (txtRentalPrice.Text == "")
			{
				MessageBox.Show("Please enter a value in the Type field", "Type Blank", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else if (rdoCar.IsChecked == false && rdoMotorcycle.IsChecked == false)
			{
				MessageBox.Show("Please select car or motorocycle", "RadioButton Blank", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else if (!double.TryParse(txtRentalPrice.Text, out rp))
			{
				MessageBox.Show("Improper value, please enter a number", "Invalid Number", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else if (rdoCar.IsChecked == true && (txtType.Text == "Trike" | txtType.Text == "Bike"))
			{
				MessageBox.Show("Conflicting Type values, Car can only be Exotic and standard", "Type error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else if (rdoMotorcycle.IsChecked == true && (txtType.Text == "Standard" | txtType.Text == "Exotic"))
			{
				MessageBox.Show("Conflicting Type values, Motorcycle can only be Bike and Trike", "Type error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			else
			{
				
				if (rdoCar.IsChecked == true)
				{
					Vehicle newVeh = new Car(lstVehicles.Items.Count, txtName.Text, Convert.ToDouble(txtRentalPrice.Text), txtCategory.Text, txtType.Text,
					Convert.ToBoolean(chkIsReserved.IsChecked));
					vehicles.Add(newVeh);
				}
				else {
					Vehicle newVeh = new Motorcycle(lstVehicles.Items.Count, txtName.Text, Convert.ToDouble(txtRentalPrice.Text), txtCategory.Text, txtType.Text,
					Convert.ToBoolean(chkIsReserved.IsChecked));
					vehicles.Add(newVeh);
				}
			}

			RefreshListBox();
		}

		private void btnEdit_Click(object sender, RoutedEventArgs e)
		{
			if (lstVehicles.SelectedItem != null)
			{
				double rp;
				if (txtName.Text == "")
				{
					MessageBox.Show("Please enter a value in the name field", "Name Blank", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else if (txtRentalPrice.Text == "")
				{
					MessageBox.Show("Please enter a value in the RentalPrice field", "RentalPrice Blank", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else if (txtRentalPrice.Text == "")
				{
					MessageBox.Show("Please enter a value in the Category field", "Category Blank", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else if (txtRentalPrice.Text == "")
				{
					MessageBox.Show("Please enter a value in the Type field", "Type Blank", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else if (rdoCar.IsChecked == false && rdoMotorcycle.IsChecked == false)
				{
					MessageBox.Show("Please select car or motorocycle", "RadioButton Blank", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else if (!double.TryParse(txtRentalPrice.Text, out rp))
				{
					MessageBox.Show("Improper value, please enter a number", "Invalid Number", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else if (rdoCar.IsChecked == true && (txtType.Text == "Trike" | txtType.Text == "Bike"))
				{
					MessageBox.Show("Conflicting Type values, Car can only be Exotic and standard", "Type error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else if (rdoMotorcycle.IsChecked == true && (txtType.Text == "Standard" | txtType.Text == "Exotic"))
				{
					MessageBox.Show("Conflicting Type values, Motorcycle can only be Bike and Trike", "Type error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{

					var selectedVeh = (from veh in vehicles
									   where veh.Id == lstVehicles.SelectedIndex
									   select veh).FirstOrDefault();

					selectedVeh.Name = txtName.Text;
					selectedVeh.RentalPrice = Convert.ToDouble(txtRentalPrice.Text);
					selectedVeh.Category = txtCategory.Text;
					selectedVeh.Type = txtType.Text;
					selectedVeh.IsReserved = Convert.ToBoolean(chkIsReserved.IsChecked);

					RefreshListBox();
				}
			}
		}

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			if (lstVehicles.SelectedItem != null)
			{
				var selectedVeh = (from veh in vehicles
								   where veh.Id == lstVehicles.SelectedIndex
								   select veh).FirstOrDefault();

				vehicles.Remove(selectedVeh);
				txtId.Text = txtName.Text = txtRentalPrice.Text = txtCategory.Text = txtType.Text = "";
				chkIsReserved.IsChecked = null;

				for (int i = 0; i < vehicles.Count; i++)
					vehicles[i].Id = i;

				RefreshListBox();
			}
		}

		private void btnClear_Click(object sender, RoutedEventArgs e)
		{
			if (lstVehicles.SelectedItem != null)
			{
				var selectedVeh = from veh in vehicles
								   where veh.Id == lstVehicles.SelectedIndex
								   select veh;

				txtId.Text = txtName.Text = txtRentalPrice.Text = txtCategory.Text = txtType.Text = "";
				chkIsReserved.IsChecked = false;
				rdoCar.IsChecked = false;
				rdoMotorcycle.IsChecked = false;

				RefreshListBox();
			}
		}

		private void btnClearList_Click(object sender, RoutedEventArgs e)
		{
			txtId.Text = txtName.Text = txtRentalPrice.Text = txtCategory.Text = txtType.Text = "";
			chkIsReserved.IsChecked = null;

			//lstVehicles.ItemsSource = null;
			vehicles.Clear();
			RefreshListBox();
		}

		private void btnReset_Click(object sender, RoutedEventArgs e)
		{
			vehicles = new List<Vehicle>(originalvehicles);
			RefreshListBox();
		}
	}
}
