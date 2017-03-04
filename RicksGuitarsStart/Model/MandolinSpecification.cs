using System;

namespace RicksGuitarsStart.Model
{
    public class MandolinSpecification : InstrumentSpecification, IEquatable<MandolinSpecification>
    {
        public Style Style { get;  }

        public MandolinSpecification(Builder builder, string model, Category category, Wood topWood, Wood backWood, Style style) : base(builder, model, category, topWood, backWood)
        {
            Style = style;
        }

        /// <summary>
        /// Check if two MandolinSpecifications are equal.
        /// </summary>
        /// <param name="other">The second MandolinSpecification to check for equality.</param>
        /// <returns>True if the two MandolinSpecifications are equal; otherwise false.</returns>
        public bool Equals(MandolinSpecification other) => other != null && base.Equals(other) && Style == other.Style;

        /// <summary>
        /// Check if the MandolinSpecification is equal to the given object.
        /// </summary>
        /// <param name="other">The second object to check for equality.</param>
        /// <returns>True if the MandolinSpecification is equal to the given object; otherwise false.</returns>
        public override bool Equals(object obj)
        {
            MandolinSpecification other = obj as MandolinSpecification;
            return Equals(other);
        }

        /// <summary>
        /// Return the hash code for the MandolinSpecification.
        /// </summary>
        /// <returns>The hash code for the MandolinSpecification.</returns>
        public override int GetHashCode() => Tuple.Create(base.GetHashCode(), Style).GetHashCode();

        /// <summary>
        /// Check if two MandolinSpecifications are equal.
        /// </summary>
        /// <param name="mandolinSpecification1">The first MandolinSpecification.</param>
        /// <param name="mandolinSpecification2">The second MandolinSpecification.</param>
        /// <returns>True if the the two MandolinSpecifications are equal; otherwise false.</returns>
        public static bool operator ==(MandolinSpecification mandolinSpecification1, MandolinSpecification mandolinSpecification2)
            => mandolinSpecification1 is null || mandolinSpecification2 is null ?
                Object.Equals(mandolinSpecification1, mandolinSpecification2)
                : mandolinSpecification1.Equals(mandolinSpecification2);


        /// <summary>
        /// Check if two MandolinSpecifications are not equal.
        /// </summary>
        /// <param name="mandolinSpecification1">The first MandolinSpecification.</param>
        /// <param name="mandolinSpecification2">The second MandolinSpecification.</param>
        /// <returns>True if the the two MandolinSpecifications are not equal; otherwise false.</returns>
        public static bool operator !=(MandolinSpecification mandolinSpecification1, MandolinSpecification mandolinSpecification2)
            => !(mandolinSpecification1 is null || mandolinSpecification2 is null ?
                Object.Equals(mandolinSpecification1, mandolinSpecification2)
                : mandolinSpecification1.Equals(mandolinSpecification2));
    }
}