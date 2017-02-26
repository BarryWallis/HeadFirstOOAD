﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DougsDogDoors.Model
{
    public class Remote
    {
        private DogDoor dogDoor;

        /// <summary>
        /// Create an instance of the remote control.
        /// </summary>
        /// <param name="dogDoor">The DogDoor that this Remote will control.</param>
        public Remote(DogDoor dogDoor) => this.dogDoor = dogDoor;

        /// <summary>
        /// Open / close the DogDoor.
        /// </summary>
        public void PressButton()
        {
            Debug.Assert(dogDoor != null);
            dogDoor.Open = !dogDoor.Open;
        }
    }
}
