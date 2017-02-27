using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DougsDogDoors
{
    public class BarkRecognizedEventArgs : EventArgs
    {
        public string Bark { get; }

        /// <summary>
        /// Create a new BarkRecognizedEventArgs instance.
        /// </summary>
        public BarkRecognizedEventArgs(string bark) => Bark = bark;
    }
}
