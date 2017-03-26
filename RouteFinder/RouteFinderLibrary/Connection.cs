using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteFinderLibrary
{
    public class Connection
    {
        public string LineName { get; }
        public Station Station1 { get; }
        public Station Station2 { get; }

        /// <summary>
        /// Connect two stations on a particular line. 
        /// </summary>
        /// <param name="station1">The first station.</param>
        /// <param name="station2">The second station.</param>
        /// <param name="lineName">The line the stations are on.</param>
        /// <exception cref="ArgumentException">Cannot connect a station to itself.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="lineName"/> cannot be null or empty.</exception>
        public Connection(Station station1, Station station2, string lineName)
        {
            if (string.IsNullOrWhiteSpace(lineName))
                throw new ArgumentNullException(nameof(lineName));
            if (station1 == station2)
                throw new ArgumentException("A Station cannot connect to itself");

            LineName = lineName;
            Station1 = station1 ?? throw new ArgumentNullException(nameof(station1));
            Station2 = station2 ?? throw new ArgumentNullException(nameof(station2));
        }

        /// <summary>
        /// Check two Connections for equality.
        /// </summary>
        /// <param name="other">The other connection to check for equality.</param>
        /// <returns>true if the Connections are the same; otherwise false.</returns>
        public bool Equals(Connection other) 
            => other is null 
            ? false 
            : LineName.ToLower() == other.LineName.ToLower() && Station1 == other.Station1 && Station2 == other.Station2;

        // override object.Equals
        public override bool Equals(object obj) => (obj == null || GetType() != obj.GetType()) ? false : Equals(obj as Connection);

        // override object.GetHashCode
        public override int GetHashCode() => LineName.ToLower().GetHashCode() ^ Station1.GetHashCode() ^ Station2.GetHashCode();

        /// <summary>
        /// Determines whether two specified Connections have the same value.
        /// </summary>
        /// <param name="connection1">The first Connection to compare, or null.</param>
        /// <param name="connection2">The second Connection to compare, or null.</param>
        /// <returns>true if the value of <paramref name="connection1"/> is the same as the value of <paramref name="connection2"/>; otherwise, false.</returns>
        public static bool operator ==(Connection connection1, Connection connection2) 
            => connection1 is null || connection2 is null ? Object.Equals(connection1, connection2) : connection1.Equals(connection2);

        /// <summary>
        /// Determines whether two specified Connections have different values.
        /// </summary>
        /// <param name="connection1">The first Connection to compare, or null.</param>
        /// <param name="connection2">The second Connection to compare, or null.</param>
        /// <returns>true if the value of <paramref name="connection1"/> is different from the value of <paramref name="connection2"/>; otherwise, false.</returns>
        public static bool operator !=(Connection connection1, Connection connection2) 
            => connection1 is null || connection2 is null ? !Object.Equals(connection1, connection2) : !connection1.Equals(connection2);
    }
}
