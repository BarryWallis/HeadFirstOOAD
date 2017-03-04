using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RicksGuitarsStart.Model
{
    public class Guitar : Instrument
    {
        public new GuitarSpecification Specification
        {
            get
            {
                GuitarSpecification  specification = base.Specification as GuitarSpecification;
                Debug.Assert(specification != null);
                return specification;
            }
        }

        /// <summary>
        /// Create a new Guitar instance.
        /// </summary>
        /// <param name="serialNumber">The Guitar serial number.</param>
        /// <param name="price">The Guitar price.</param>
        /// <param name="specification">The specification of the Guitar.</param>
        public Guitar(string serialNumber, decimal price, GuitarSpecification specification) : base(serialNumber, price, specification)
        {
        }
    }
}
