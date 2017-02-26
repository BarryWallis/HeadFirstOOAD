using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RicksGuitarsStart.Model
{
    public class Guitar : IEquatable<Guitar>
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

        /// <summary>
        /// Check if two Guitars are equal.
        /// </summary>
        /// <param name="other">The second Guitar to check for equality.</param>
        /// <returns>True if the two Guitars are equal; otherwise false.</returns>
        public bool Equals(Guitar other) => other != null && SerialNumber == other.SerialNumber;

        /// <summary>
        /// Check if the Guitar is equal to the given object.
        /// </summary>
        /// <param name="other">The second object to check for equality.</param>
        /// <returns>True if the Guitar is equal to the given object; otherwise false.</returns>
        public override bool Equals(object obj)
        {
            Guitar other = obj as Guitar;
            return Equals(other);
        }

        /// <summary>
        /// Return the hash code for the Guitar.
        /// </summary>
        /// <returns>The hash code for the Guitar.</returns>
        public override int GetHashCode() => SerialNumber.GetHashCode();

        /// <summary>
        /// Check if two Guitars are equal.
        /// </summary>
        /// <param name="guitarSpecification1">The first Guitar.</param>
        /// <param name="guitarSpecification2">The second Guitar.</param>
        /// <returns>True if the the two GuitarSpecifications are equal; otherwise false.</returns>
        public static bool operator ==(Guitar guitar1, Guitar guitar2)
            => guitar1 is null || guitar2 is null ?
                Object.Equals(guitar1, guitar2)
                : guitar1.Equals(guitar2);


        /// <summary>
        /// Check if two Guitars are not equal.
        /// </summary>
        /// <param name="guitarSpecification1">The first Guitar.</param>
        /// <param name="guitarSpecification2">The second Guitar.</param>
        /// <returns>True if the the two Guitars are not equal; otherwise false.</returns>
        public static bool operator !=(Guitar guitar1, Guitar guitar2)
            => !(guitar1 is null || guitar2 is null ?
                Object.Equals(guitar1, guitar2)
                : guitar1.Equals(guitar2));
    }
}
