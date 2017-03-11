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

        private ObservableCollection<string> _instrumentTypes;
        public ObservableCollection<string> Instruments { get => _instrumentTypes; }

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

        private int _backWoodComboBoxIndex;
        public int BackWoodComboBoxIndex
        {
            get { return _backWoodComboBoxIndex; }
            set
            {
                _backWoodComboBoxIndex = value;
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

        private bool _instrumentCheckBoxIsChecked;
        public bool InstrumentCheckBoxIsChecked
        {
            get { return _instrumentCheckBoxIsChecked; }
            set
            {
                _instrumentCheckBoxIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        private bool _builderCheckBoxIsChecked;
        public bool BuilderCheckBoxIsChecked
        {
            get { return _builderCheckBoxIsChecked; }
            set
            {
                _builderCheckBoxIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        private bool _modelCheckBoxIsChecked;
        public bool ModelCheckBoxIsChecked
        {
            get { return _modelCheckBoxIsChecked; }
            set
            {
                _modelCheckBoxIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        private bool _categoryCheckBoxIsChecked;
        public bool CategoryCheckBoxIsChecked
        {
            get { return _categoryCheckBoxIsChecked; }
            set
            {
                _categoryCheckBoxIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        private bool _topWoodCheckBoxIsChecked;
        public bool TopWoodCheckBoxIsChecked
        {
            get { return _topWoodCheckBoxIsChecked; }
            set
            {
                _topWoodCheckBoxIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        private bool _backWoodCheckBoxIsChecked;
        public bool BackWoodCheckBoxIsChecked
        {
            get { return _backWoodCheckBoxIsChecked; }
            set
            {
                _backWoodCheckBoxIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        private bool _numberOfStringsCheckBoxIsChecked;
        public bool NumberOfStringsCheckBoxIsChecked
        {
            get { return _numberOfStringsCheckBoxIsChecked; }
            set
            {
                _numberOfStringsCheckBoxIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        private bool _styleCheckBoxIsChecked;
        public bool StyleCheckBoxIsChecked
        {
            get { return _styleCheckBoxIsChecked; }
            set
            {
                _styleCheckBoxIsChecked = value;
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
            _instrumentTypes = new ObservableCollection<string>(inventory.InstrumentTypes);
            _instrumentCombBoxItem = _instrumentTypes[0];
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
            Dictionary<string, object> properties = new Dictionary<string, object>();
            if (InstrumentCheckBoxIsChecked)
                properties["InstrumentType"] = (InstrumentType)Enum.Parse(typeof(InstrumentType), InstrumentCombBoxItem.ToString());
            if (BuilderCheckBoxIsChecked)
                properties["Builder"] = (Builder)Enum.Parse(typeof(Builder), BuilderComboBoxIndex.ToString());
            if (ModelCheckBoxIsChecked)
                properties["Model"] = ModelComboBoxItem;
            if (CategoryCheckBoxIsChecked)
                properties["Category"] = (Category)Enum.Parse(typeof(Category), CategoryComboBoxIndex.ToString());
            if (TopWoodCheckBoxIsChecked)
                properties["TopWood"] = (Wood)Enum.Parse(typeof(Wood), TopWoodComboBoxIndex.ToString());
            if (BackWoodCheckBoxIsChecked)
                properties["BackWood"] = (Wood)Enum.Parse(typeof(Wood), BackWoodComboBoxIndex.ToString());
            if (NumberOfStringsCheckBoxIsChecked)
                properties["NumberOfStrings"] = NumberOfStrings;
            if (TopWoodCheckBoxIsChecked)
                properties["TopWood"] = (Wood)Enum.Parse(typeof(Wood), TopWoodComboBoxIndex.ToString());
            if (StyleCheckBoxIsChecked)
                properties["Style"] = (Style)Enum.Parse(typeof(Style), StyleComboBoxIndex.ToString());

            ICollection<Instrument> instruments = inventory.Search(new InstrumentSpecification(properties));
            ResultsTextBox = "";
            if (instruments.Count > 0)
            {
                foreach (Instrument instrument in instruments)
                {
                    AddInstrumentToTextBox(instrument);
                }
            }
            else
                ResultsTextBox = $"No instruments found.";

        }

        /// <summary>
        /// Add instrument info to ResultsTextBox.
        /// </summary>
        /// <param name="instrument">The instrument to add to the text box.</param>
        private void AddInstrumentToTextBox(Instrument instrument)
        {
            ResultsTextBox += $"{instrument.SerialNumber} is {instrument.Price}";
            foreach (KeyValuePair<string, object> property in instrument.Specification.Properties)
            {
                ResultsTextBox += $"\t{property.Key}: {property.Value}\n";
            }
        }

    }
}
