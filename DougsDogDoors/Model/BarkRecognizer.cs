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

        public void Recognize(string bark)
        {
            dogDoor.IsOpen = true;
            OnBarkRecognized(new BarkRecognizedEventArgs(bark));
        }

        protected virtual void OnBarkRecognized(BarkRecognizedEventArgs e) => BarkRecognized?.Invoke(this, e);
    }
}
