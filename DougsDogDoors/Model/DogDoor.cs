using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DougsDogDoors.Model
{
    public class DogDoor
    {
        private bool _open = false;
        public bool Open
        {
            get => _open;
            set => _open = value;
        }
    }
}
