using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RicksGuitarsStart.Model
{
    public class GuitarSpecification : InstrumentSpecification, IEquatable<GuitarSpecification>
    {
        public int NumberOfStrings { get; }

        /// <summary>
        /// Create a new GuitarSpecification instance.
        /// </summary>
        /// <param name="builder">The Guitar builder.</param>
        /// <param name="model">The Guitar model.</param>
        /// <param name="category">The Guitar type.</param>
        /// <param name="numberOfStrings">The number of strings on the Guitar.</param>
        /// <param name="topWood">The Guitar  top wood.</param>
        /// <param name="backWood">The Guitar  back wood.</param>
        public GuitarSpecification(Builder builder, string model, Category category, int numberOfStrings, Wood topWood, Wood backWood) : base(builder, model, category,topWood, backWood)
        {
            if (numberOfStrings <= 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfStrings), numberOfStrings, "must be greater than 0");

            NumberOfStrings = numberOfStrings;
        }

        /// <summary>
        /// Check if two GuitarSpecifications are equal.
        /// </summary>
        /// <param name="other">The second GuitarSpecification to check for equality.</param>
        /// <returns>True if the two GuitarSpecifications are equal; otherwise false.</returns>
        public bool Equals(GuitarSpecification other) => other != null && base.Equals(other) && NumberOfStrings == other.NumberOfStrings;

        /// <summary>
        /// Check if the GuitarSpecification is equal to the given object.
        /// </summary>
        /// <param name="other">The second object to check for equality.</param>
        /// <returns>True if the GuitarSpecification is equal to the given object; otherwise false.</returns>
        public override bool Equals(object obj)
        {
            GuitarSpecification other = obj as GuitarSpecification;
            return Equals(other);
        }

        /// <summary>
        /// Return the hash code for the GuitarSpecification.
        /// </summary>
        /// <returns>The hash code for the GuitarSpecification.</returns>
        public override int GetHashCode() => Tuple.Create(base.GetHashCode(), NumberOfStrings).GetHashCode();

        /// <summary>
        /// Check if two GuitarSpecifications are equal.
        /// </summary>
        /// <param name="guitarSpecification1">The first GuitarSpecification.</param>
        /// <param name="guitarSpecification2">The second GuitarSpecification.</param>
        /// <returns>True if the the two GuitarSpecifications are equal; otherwise false.</returns>
        public static bool operator ==(GuitarSpecification guitarSpecification1, GuitarSpecification guitarSpecification2) 
            => guitarSpecification1 is null || guitarSpecification2 is null ?
                Object.Equals(guitarSpecification1, guitarSpecification2)
                : guitarSpecification1.Equals(guitarSpecification2);


        /// <summary>
        /// Check if two GuitarSpecifications are not equal.
        /// </summary>
        /// <param name="guitarSpecification1">The first GuitarSpecification.</param>
        /// <param name="guitarSpecification2">The second GuitarSpecification.</param>
        /// <returns>True if the the two GuitarSpecifications are not equal; otherwise false.</returns>
        public static bool operator !=(GuitarSpecification guitarSpecification1, GuitarSpecification guitarSpecification2)
            => !(guitarSpecification1 is null || guitarSpecification2 is null ?
                Object.Equals(guitarSpecification1, guitarSpecification2)
                : guitarSpecification1.Equals(guitarSpecification2));
    }
}
