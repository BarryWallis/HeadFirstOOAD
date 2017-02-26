using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RicksGuitarsStart.Model
{
    class Guitar
    {
        public string SerialNumber { get; }
        public decimal Price { get; }
        public GuitarSpecification Specification { get; }

        /// <summary>
        /// Create a new Guitar instance.
        /// </summary>
        /// <param name="serialNumber">The Guitar serial number.</param>
        /// <param name="price">The Guitar price.</param>
        /// <param name="specification">The specification of the Guitar.</param>
        public Guitar(string serialNumber, decimal price, GuitarSpecification specification)
        {
            SerialNumber = serialNumber;
            Price = price;
            Specification = specification;
        }
    }
}
