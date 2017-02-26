using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DougsDogDoors.Model
{
    public class DogDoorStateChangedEventArgs : EventArgs
    {
        public bool IsOpen { get; }

        /// <summary>
        /// Create a new DogDorStateChanged instance.
        /// </summary>
        /// <param name="isOpen">True if the DogDoor is open; otherwise false.</param>
        public DogDoorStateChangedEventArgs(bool isOpen) => IsOpen = isOpen;
    }
}
