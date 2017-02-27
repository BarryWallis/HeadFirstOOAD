using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DougsDogDoors.Model
{
    public class BarkRecognizer
    {
        public event EventHandler<BarkRecognizedEventArgs> BarkRecognized;

        private DogDoor dogDoor;

        public BarkRecognizer(DogDoor dogDoor)
        {
            if (dogDoor is null)
                throw new ArgumentNullException(nameof(dogDoor));

            this.dogDoor = dogDoor;
        }

        public bool Recognize(string bark)
        {
            if (dogDoor.Barks.Contains(new Bark(bark)))
            {
                dogDoor.IsOpen = true;
                OnBarkRecognized(new BarkRecognizedEventArgs(bark));
                return true;
            }
            else
                return false;
        }

        protected virtual void OnBarkRecognized(BarkRecognizedEventArgs e) => BarkRecognized?.Invoke(this, e);
    }
}
