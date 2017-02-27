using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DougsDogDoors.Model;

namespace DougsDogDoors.ViewModel
{
    public class AddBarksViewModel : INotifyPropertyChanged
    {
        DogDoor dogDoor;

        #region Properties
        public Collection<string> Barks
        {
            get
            {
                Collection<String> barks = new Collection<string>();
                foreach (Bark bark in dogDoor.Barks)
                {
                    barks.Add(bark.ToString());
                }
                return barks;
            }
        }

        public string NewBark { get; set; }
        #endregion

        public AddBarksViewModel(DogDoor dogDoor) => this.dogDoor = dogDoor;

        internal bool AddBark()
        {
            if (string.IsNullOrWhiteSpace(NewBark) || dogDoor.Barks.Contains(new Bark(NewBark)))
                return false;

            dogDoor.Barks.Add(new Bark(NewBark));
            NotifyPropertyChanged("Barks");
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}