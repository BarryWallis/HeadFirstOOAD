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
using System.Windows.Shapes;
using DougsDogDoors.Model;
using DougsDogDoors.ViewModel;

namespace DougsDogDoors
{
    /// <summary>
    /// Interaction logic for AddBarksWindow.xaml
    /// </summary>
    public partial class AddBarksWindow : Window
    {
        AddBarksViewModel viewModel;

        public AddBarksWindow(DogDoor dogDoor)
        {
            InitializeComponent();

            viewModel = new AddBarksViewModel(dogDoor);
            DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!viewModel.AddBark())
                MessageBox.Show($"Cannot add bark", "Add Bark", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
