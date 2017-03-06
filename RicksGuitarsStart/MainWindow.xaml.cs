using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using RicksGuitarsStart.ViewModel;

namespace RicksGuitarsStart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWIndowViewModel mainWindowViewModel = new MainWIndowViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = mainWindowViewModel;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e) => mainWindowViewModel.Search();

        private void InstrumentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is null)
                throw new ArgumentNullException(nameof(sender));

            if (NumberOfStrings is null && StyleValue is null)
                return;

            string instrumentName = ((sender as ComboBox)?.SelectedItem as ComboBoxItem)?.Content as string;
            switch (InstrumentComboBox.SelectedItem as string)
            {
                case "Guitar":
                    NumberOfStringsLabel.Visibility = Visibility.Visible;
                    NumberOfStrings.Visibility = Visibility.Visible;
                    StyleLabel.Visibility = Visibility.Hidden;
                    StyleValue.Visibility = Visibility.Hidden;
                    break;
                case "Mandolin":
                    NumberOfStringsLabel.Visibility = Visibility.Hidden;
                    NumberOfStrings.Visibility = Visibility.Hidden;
                    StyleLabel.Visibility = Visibility.Visible;
                    StyleValue.Visibility = Visibility.Visible;
                    break;
                case null:
                    Debug.Fail("Null instrument");
                    break;
                default:
                    Debug.Fail("Unexpected Instrument name");
                    break;
            }
        }
    }
}
