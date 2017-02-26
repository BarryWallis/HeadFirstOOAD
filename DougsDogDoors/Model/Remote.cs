using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DougsDogDoors.Model
{
    public class Remote
    {
        private DogDoor dogDoor;
        private DispatcherTimer timer = new DispatcherTimer()
        {
            Interval = new TimeSpan(0, 0, 5)
        };

        /// <summary>
        /// Create an instance of the remote control.
        /// </summary>
        /// <param name="dogDoor">The DogDoor that this Remote will control.</param>
        public Remote(DogDoor dogDoor)
        {
            this.dogDoor = dogDoor;
            timer.Tick += Timer_Tick;

        }

        /// <summary>
        /// Open / close the DogDoor.
        /// </summary>
        public void PressButton()
        {
            Debug.Assert(timer != null);
            Debug.Assert(dogDoor != null);

            timer.Stop();
            dogDoor.IsOpen = !dogDoor.IsOpen;
            if (dogDoor.IsOpen)
                timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Debug.Assert(dogDoor != null);
            Debug.Assert(timer != null);

            dogDoor.IsOpen = false;
            timer.Stop();
        }
    }
}
