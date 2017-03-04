using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RicksGuitarsStart.Model
{
    abstract public class InstrumentSpecification
    {
        public Builder Builder { get; }
        public string Model { get; }
        public Category Category { get; }
        public Wood TopWood { get; }
        public Wood BackWood { get; }

        protected InstrumentSpecification(Builder builder, string model, Category category, Wood topWood, Wood backWood)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentNullException(nameof(model));

            Builder = builder;
            Model = model;
            Category = category;
            TopWood = topWood;
            BackWood = backWood;
        }

        /// <summary>
        /// Check if two InstrumentSpecifications are equal.
        /// </summary>
        /// <param name="other">The second InstrumentSpecification to check for equality.</param>
        /// <returns>True if the two InstrumentSpecifications are equal; otherwise false.</returns>
        public bool Equals(InstrumentSpecification other) => other != null && Builder == other.Builder && Model == other.Model && Category == other.Category && TopWood == other.TopWood && BackWood == other.BackWood;

        /// <summary>
        /// Check if the InstrumentSpecification is equal to the given object.
        /// </summary>
        /// <param name="other">The second object to check for equality.</param>
        /// <returns>True if the InstrumentSpecification is equal to the given object; otherwise false.</returns>
        public override bool Equals(object obj)
        {
            InstrumentSpecification other = obj as InstrumentSpecification;
            return Equals(other);
        }

        /// <summary>
        /// Return the hash code for the InstrumentSpecification.
        /// </summary>
        /// <returns>The hash code for the InstrumentSpecification.</returns>
        public override int GetHashCode() => Tuple.Create(Builder, Model, Category, TopWood, BackWood).GetHashCode();

        /// <summary>
        /// Check if two InstrumentSpecifications are equal.
        /// </summary>
        /// <param name="instrumentSpecification1">The first InstrumentSpecification.</param>
        /// <param name="instrumentSpecification2">The second InstrumentSpecification.</param>
        /// <returns>True if the the two InstrumentSpecifications are equal; otherwise false.</returns>
        public static bool operator ==(InstrumentSpecification instrumentSpecification1, InstrumentSpecification instrumentSpecification2)
            => instrumentSpecification1 is null || instrumentSpecification2 is null ?
                Object.Equals(instrumentSpecification1, instrumentSpecification2)
                : instrumentSpecification1.Equals(instrumentSpecification2);


        /// <summary>
        /// Check if two InstrumentSpecifications are not equal.
        /// </summary>
        /// <param name="instrumentSpecification1">The first InstrumentSpecification.</param>
        /// <param name="instrumentSpecification2">The second InstrumentSpecification.</param>
        /// <returns>True if the the two InstrumentSpecifications are not equal; otherwise false.</returns>
        public static bool operator !=(InstrumentSpecification instrumentSpecification1, InstrumentSpecification instrumentSpecification2)
            => !(instrumentSpecification1 is null || instrumentSpecification2 is null ?
                Object.Equals(instrumentSpecification1, instrumentSpecification2)
                : instrumentSpecification1.Equals(instrumentSpecification2));
    }
}
