using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DougsDogDoors.Model;

namespace DougsDogDoors.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DogDoor dogDoor =  new DogDoor();
        private Remote remote;

        #region Properties
        public string DoorState => dogDoor.IsOpen ? "Open" : "Closed";
        #endregion

        public MainWindowViewModel()
        {
            remote = new Remote(dogDoor);
            dogDoor.StateChanged += DogDoorStateChanged;
        }

        internal void PressButton()
        {
            remote.PressButton();
        }

        void DogDoorStateChanged(object sender, DogDoorStateChangedEventArgs e)
        {
            NotifyPropertyChanged("DoorState");
        }

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
