using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteFinderLibrary;

namespace RouteFinderLibraryTests
{
    [TestClass]
    public class StationTests
    {
        [TestMethod]
        public void CtorString()
        {
            const string stationName = "Test Station";
            Station station = new Station(stationName);
            Assert.AreEqual(stationName, station.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CtorStringNull()
        {
            Station station = new Station(null);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CtorStringEmpty()
        {
            Station station = new Station("   ");
            Assert.Fail();
        }

        [TestMethod]
        public void EqualsTrueStation()
        {
            const string name = "station";
            Station station1 = new Station(name);
            Station station2 = new Station(name);
            Assert.IsTrue(station1.Equals(station2));
        }

        [TestMethod]
        public void EqualsFalseStation()
        {
            Station station1 = new Station("s1");
            Station station2 = new Station("s2");
            Assert.IsFalse(station1.Equals(station2));
        }

        [TestMethod]
        public void EqualsTrueStationCaseInsensitive()
        {
            const string name = "station";
            Station station1 = new Station(name);
            Station station2 = new Station(name.ToUpper());
            Assert.IsTrue(station1.Equals(station2));
        }

        [TestMethod]
        public void EqualsFalseStationCaseInsensitive()
        {
            Station station1 = new Station("s1");
            Station station2 = new Station("S2");
            Assert.IsFalse(station1.Equals(station2));
        }

        [TestMethod]
        public void EqualsObject()
        {
            Station station = new Station("s");
            Assert.IsFalse(station.Equals(1));
        }

        [TestMethod]
        public void EqualsNull()
        {
            Station station = new Station("s");
            Assert.IsFalse(station.Equals(null));
        }

        [TestMethod]
        public void OperatorEqualsTrue()
        {
            string name = "s";
            Station station1 = new Station(name);
            Station station2 = new Station(name);
            Assert.IsTrue(station1 == station2);
        }

        [TestMethod]
        public void OperatorEqualsFalse()
        {
            string name = "s";
            Station station1 = new Station(name);
            Station station2 = new Station("x");
            Assert.IsFalse(station1 == station2);
        }

        [TestMethod]
        public void OperatorNotEqualsTrue()
        {
            string name = "s";
            Station station1 = new Station(name);
            Station station2 = new Station(name);
            Assert.IsFalse(station1 != station2);
        }

        [TestMethod]
        public void OperatorNotEqualsFalse()
        {
            string name = "s";
            Station station1 = new Station(name);
            Station station2 = new Station("x");
            Assert.IsTrue(station1 != station2);
        }
    }
}
