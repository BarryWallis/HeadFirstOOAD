using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteFinderLibrary
{
    public class Subway
    {
        private List<Station> stations = new List<Station>();
        private List<Connection> connections = new List<Connection>();

        /// <summary>
        /// Add a station to the Subway.
        /// </summary>
        /// <param name="stationName">The name of the station to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stationName"/> is null or empty.</exception>
        /// <exception cref="ArgumentException"><paramref name="stationName"/> is already in the list of stations.</exception>
        public void AddStation(string stationName)
        {
            if (string.IsNullOrWhiteSpace(stationName))
                throw new ArgumentNullException(nameof(stationName));
            if (HasStation(stationName))
                throw new ArgumentException("Station already in list", nameof(stationName));
            Debug.Assert(stations != null);

            Station station = new Station(stationName);
            stations.Add(station);
        }

        /// <summary>
        /// Check if a <paramref name="stationName"/> is in the list of Stations.
        /// </summary>
        /// <param name="stationName">The name of the Station to check for.</param>
        /// <returns>true if the <paramref name="stationName"/> is in the list of Stations; otherwise false."</returns>
        public bool HasStation(string stationName)
        {
            Debug.Assert(stations != null);

            return stations.Contains(new Station(stationName));
        }

        /// <summary>
        /// Add a connection between the two stations for the given <paramref name="lineName"/>. All conections are bi-directional.
        /// </summary>
        /// <param name="station1Name">A station to connect.</param>
        /// <param name="station2Name">Another station to connect.</param>
        /// <param name="lineName">The name of the line these are connected on.</param>
        /// <exception cref="ArgumentNullException">Station or <paramref name="lineName"/> is null or empty.</exception>
        /// <exception cref="ArgumentException">The station does not exist in the list of Stations.</exception>
        public void AddConnection(string station1Name, string station2Name, string lineName)
        {
            if (string.IsNullOrWhiteSpace(station1Name))
                throw new ArgumentNullException(nameof(station1Name));
            if (!HasStation(station1Name))
                throw new ArgumentException("Station does not exist", nameof(station1Name));
            if (string.IsNullOrWhiteSpace(station2Name))
                throw new ArgumentNullException(nameof(station2Name));
            if (!HasStation(station2Name))
                throw new ArgumentException("Station does not exist", nameof(station2Name));
            if (string.IsNullOrWhiteSpace(lineName))
                throw new ArgumentNullException(nameof(lineName));
            Debug.Assert(connections != null);

            Station station1 = new Station(station1Name);
            Station station2 = new Station(station2Name);
            connections.Add(new Connection(station1, station2, lineName));
            connections.Add(new Connection(station2, station1, lineName));
        }

        public ICollection<Station> GetStations() => stations.ToArray();

        public ICollection<Connection> GetConnections() => connections.ToArray();
    }
}
