using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteFinderLibrary
{
    public class Station
    {
        public string Name { get; }

        /// <summary>
        /// Create a new Station with the given <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the station.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null or empty.</exception>
        public Station(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        /// <summary>
        /// Check two Stations for equality.
        /// </summary>
        /// <param name="other">The other station to check for equality.</param>
        /// <returns>true if the Stations are the same; otherwise false.</returns>
        public bool Equals(Station other) => other is null ? false : Name.ToLower() == other.Name.ToLower();

        // override object.Equals
        public override bool Equals(object obj) => (obj == null || GetType() != obj.GetType()) ? false : Equals(obj as Station);

        // override object.GetHashCode
        public override int GetHashCode() => Name.ToLower().GetHashCode();

        /// <summary>
        /// Determines whether two specified Stations have the same value.
        /// </summary>
        /// <param name="station1">The first Station to compare, or null.</param>
        /// <param name="station2">The second Station to compare, or null.</param>
        /// <returns>true if the value of <paramref name="station1"/> is the same as the value of <paramref name="station2"/>; otherwise, false.</returns>
        public static bool operator ==(Station station1, Station station2) => station1 is null || station2 is null ? Object.Equals(station1, station2) : station1.Equals(station2);

        /// <summary>
        /// Determines whether two specified Stations have different values.
        /// </summary>
        /// <param name="station1">The first Station to compare, or null.</param>
        /// <param name="station2">The second Station to compare, or null.</param>
        /// <returns>true if the value of <paramref name="station1"/> is different from the value of <paramref name="station2"/>; otherwise, false.</returns>
        public static bool operator !=(Station station1, Station station2) => station1 is null || station2 is null ? !Object.Equals(station1, station2) : !station1.Equals(station2);
    }
}
