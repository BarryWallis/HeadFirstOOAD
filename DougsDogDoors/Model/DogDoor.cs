using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DougsDogDoors.Model
{
    public class DogDoor
    {
        public event EventHandler<DogDoorStateChangedEventArgs> StateChanged;

        private DispatcherTimer timer = new DispatcherTimer()
        {
            Interval = new TimeSpan(0, 0, 5)
        };

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
                    if (_open)
                        timer.Start();
                    else
                        timer.Stop();
                }
            }
        }

        public DogDoor() => timer.Tick += Timer_Tick;


        private void Timer_Tick(object sender, EventArgs e)
        {
            Debug.Assert(timer != null);

            IsOpen = false;
            timer.Stop();
        }

        protected virtual void OnStateChanged(DogDoorStateChangedEventArgs e) => StateChanged?.Invoke(this, e);
    }
}
