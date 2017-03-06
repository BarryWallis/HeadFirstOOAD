using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using RicksGuitarsStart.Model;

namespace RicksGuitarsStart.ViewModel
{
    class MainWIndowViewModel : INotifyPropertyChanged
    {
        private Inventory inventory = new Inventory();

        #region Properties
        private ObservableCollection<string> _models;
        public ObservableCollection<string> Models { get => _models; }

        private ObservableCollection<string> _instruments = new ObservableCollection<string>();
        public ObservableCollection<string> Instruments { get => _instruments; }

        private string _modelComboBoxItem;
        public string ModelComboBoxItem
        {
            get { return _modelComboBoxItem; }
            set
            {
                _modelComboBoxItem = value;
                NotifyPropertyChanged();
            }
        }

        private string _resultsTextBox;
        public string ResultsTextBox
        {
            get { return _resultsTextBox; }
            set
            {
                _resultsTextBox = value;
                NotifyPropertyChanged();
            }
        }

        private int _builderComboBoxIndex;
        public int BuilderComboBoxIndex
        {
            get { return _builderComboBoxIndex; }
            set
            {
                _builderComboBoxIndex = value;
                NotifyPropertyChanged();
            }
        }

        private int _categoryComboBoxIndex;
        public int CategoryComboBoxIndex
        {
            get { return _categoryComboBoxIndex; }
            set
            {
                _categoryComboBoxIndex = value;
                NotifyPropertyChanged();
            }
        }

        private int _topWoodComboBoxIndex;
        public int TopWoodComboBoxIndex
        {
            get { return _topWoodComboBoxIndex; }
            set
            {
                _topWoodComboBoxIndex = value;
                NotifyPropertyChanged();
            }
        }

        private int _bottomWoodComboBoxIndex;
        public int BottomWoodComboBoxIndex
        {
            get { return _bottomWoodComboBoxIndex; }
            set
            {
                _bottomWoodComboBoxIndex = value;
                NotifyPropertyChanged();
            }
        }

        private int _numberOfStrings = 6;
        public int NumberOfStrings
        {
            get { return _numberOfStrings; }
            set
            {
                _numberOfStrings = value;
                NotifyPropertyChanged();
            }
        }

        private int _styleComboBoxIndex = 0;
        public int StyleComboBoxIndex
        {
            get { return _styleComboBoxIndex; }
            set
            {
                _styleComboBoxIndex = value;
                NotifyPropertyChanged();
            }
        }

        private string _instrumentCombBoxItem;
        public string InstrumentCombBoxItem
        {
            get { return _instrumentCombBoxItem; }
            set
            {
                _instrumentCombBoxItem = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        public MainWIndowViewModel()
        {
            Debug.Assert(inventory != null);

            ResultsTextBox = " ";
            inventory.Initialize();
            _models = new ObservableCollection<string>(inventory.Models);
            _modelComboBoxItem = _models[0];
            _instruments.Add("Guitar");
            _instruments.Add("Mandolin");
            _instrumentCombBoxItem = _instruments[0];

        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Search for the given instrument and populate the ResultsTextBox.
        /// </summary>
        internal void Search()
        {
            switch (InstrumentCombBoxItem)
            {
                case "Guitar":
                    ICollection<Guitar> guitars = inventory.Search(new GuitarSpecification((Builder)BuilderComboBoxIndex, ModelComboBoxItem, (Category)CategoryComboBoxIndex, NumberOfStrings, (Wood)TopWoodComboBoxIndex, (Wood)BottomWoodComboBoxIndex));
                    if (guitars.Count > 0)
                    {
                        ResultsTextBox = "";
                        foreach (Guitar guitar in guitars)
                        {
                            AddGuitarToTextBox(guitar);
                        }
                    }
                    else
                        ResultsTextBox = "No guitars found.";
                    break;
                case "Mandolin":
                    ICollection<Mandolin> mandolins = inventory.Search(new MandolinSpecification((Builder)BuilderComboBoxIndex, ModelComboBoxItem, (Category)CategoryComboBoxIndex, (Wood)TopWoodComboBoxIndex, (Wood)BottomWoodComboBoxIndex, (Style)StyleComboBoxIndex));
                    if (mandolins.Count > 0)
                    {
                        ResultsTextBox = "";
                        foreach (Mandolin mandolin in mandolins)
                        {
                            AddMandolinToTextBox(mandolin);
                        }
                    }
                    else
                        ResultsTextBox = "No mandolins found.";
                    break;
                default:
                    Debug.Fail("Unexpected instrument found");
                    break;
            }
        }

        /// <summary>
        /// Add guitar info to ResultsTextBox.
        /// </summary>
        /// <param name="guitar"></param>
        private void AddGuitarToTextBox(Guitar guitar)
        {
            ResultsTextBox += $"{guitar.SerialNumber} is {guitar.Price:C}\n";
            ResultsTextBox += $"\tBuilder: {guitar.Specification.Builder}\n";
            ResultsTextBox += $"\tModel: { guitar.Specification.Model}\n";
            ResultsTextBox += $"\tCategory: { guitar.Specification.Category}\n";
            ResultsTextBox += $"\tTop Wood: { guitar.Specification.TopWood}\n";
            ResultsTextBox += $"\tBack Wood: {guitar.Specification.BackWood}\n";
        }

        /// <summary>
        /// Add mandolin info to ResultsTextBox.
        /// </summary>
        /// <param name="mandolin"></param>
        private void AddMandolinToTextBox(Mandolin mandolin)
        {
            ResultsTextBox += $"{mandolin.SerialNumber} is {mandolin.Price:C}\n";
            ResultsTextBox += $"\tBuilder: {mandolin.Specification.Builder}\n";
            ResultsTextBox += $"\tModel: { mandolin.Specification.Model}\n";
            ResultsTextBox += $"\tCategory: { mandolin.Specification.Category}\n";
            ResultsTextBox += $"\tTop Wood: { mandolin.Specification.TopWood}\n";
            ResultsTextBox += $"\tBack Wood: {mandolin.Specification.BackWood}\n";
            ResultsTextBox += $"\tStyle: {mandolin.Specification.Style}\n";
        }
    }
}
