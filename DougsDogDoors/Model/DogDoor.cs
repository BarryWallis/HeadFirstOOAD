using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DougsDogDoors.Model
{
    public class DogDoor
    {
        public event EventHandler<DogDoorStateChangedEventArgs> StateChanged;

        private bool _open = false;
        public bool IsOpen
        {
            get => _open;
            set
            {
                if (_open != value)
                {
                    _open = value;
                    OnStateChanged(new DogDoorStateChangedEventArgs(value));
                }
            }
        }

        protected virtual void OnStateChanged(DogDoorStateChangedEventArgs e) => StateChanged?.Invoke(this, e);
    }
}
