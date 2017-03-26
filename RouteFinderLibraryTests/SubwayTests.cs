using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteFinderLibrary;
using System.Linq;

namespace RouteFinderLibraryTests
{
    [TestClass]
    public class SubwayTests
    {
        [TestMethod]
        public void AddStationString()
        {
            Subway subway = new Subway();
            Assert.AreEqual(0, subway.GetStations().Count);

            const string stationName = "Charing Cross";
            subway.AddStation(stationName);
            Assert.AreEqual(1, subway.GetStations().Count);
            Assert.IsTrue(subway.GetStations().Contains(new Station(stationName)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStationNull()
        {
            Subway subway = new Subway();
            subway.AddStation(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStationEmpty()
        {
            Subway subway = new Subway();
            subway.AddStation("   ");
            Assert.Fail();
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStationStringDuplicate()
        {
            Subway subway = new Subway();
            const string stationName = "Charing Cross";
            subway.AddStation(stationName);
            subway.AddStation(stationName);
            Assert.Fail();
        }
        [TestMethod]
        public void HasStationStringTrue()
        {
            Subway subway = new Subway();
            const string stationName = "Charing Cross";
            subway.AddStation(stationName);
            Assert.IsTrue(subway.HasStation(stationName));
        }

        [TestMethod]
        public void HasStationStringFalse()
        {
            Subway subway = new Subway();
            const string stationName = "Charing Cross";
            subway.AddStation(stationName);
            Assert.IsFalse(subway.HasStation("Bogosity"));
        }

        [TestMethod]
        public void AddConnectionStringStringString()
        {
            Subway subway = new Subway();
            const string lineName = "Rock Island Line";
            const string station1 = "Station 1";
            subway.AddStation(station1);
            const string station2 = "Station 2";
            subway.AddStation(station2);

            Assert.AreEqual(0, subway.GetConnections().Count);
            subway.AddConnection(station1, station2, lineName);
            Assert.AreEqual(2, subway.GetConnections().Count);
            ICollection<Connection> connections = subway.GetConnections();
            bool result1 = connections.Contains(new Connection(new Station(station1), new Station(station2), lineName));
            bool result2 = connections.Contains(new Connection(new Station(station2), new Station(station1), lineName));
            Assert.IsTrue(result1 && result2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddConnectionsNullStringString()
        {
            Subway subway = new Subway();
            string station2 = "s2";
            subway.AddStation(station2);
            subway.AddConnection(null, station2, "line");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddConnectionsStringNullString()
        {
            Subway subway = new Subway();
            string station1 = "s1";
            subway.AddStation(station1);
            subway.AddConnection(station1, null, "line");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddConnectionNoStation1StringStringString()
        {
            Subway subway = new Subway();
            string station1 = "s1";
            string station2 = "s2";
            subway.AddStation(station2);
            subway.AddConnection(station1, station2, "line");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddConnectionNoStation2StringStringString()
        {
            Subway subway = new Subway();
            string station1 = "s1";
            string station2 = "s2";
            subway.AddStation(station1);
            subway.AddConnection(station1, station2, "line");
            Assert.Fail();
        }
    }
}
