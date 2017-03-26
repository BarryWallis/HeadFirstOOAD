using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteFinderLibrary;

namespace RouteFinderLibraryTests
{
    [TestClass]
    public class ConnectionTests
    {
        [TestMethod]
        public void CtorStringStationStationName()
        {
            Station station1 = new Station("station1");
            Station station2 = new Station("station2");
            string lineName = "line";

            Connection connection = new Connection(station1, station2, lineName);
            Assert.AreEqual(lineName, connection.LineName);
            Assert.AreEqual(station1, connection.Station1);
            Assert.AreEqual(station2, connection.Station2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CtorStationStationNull()
        {
            Station station1 = new Station("station1");
            Station station2 = new Station("station2");

            Connection connection = new Connection(station1, station2, null);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CtorStationStationEmpty()
        {
            Station station1 = new Station("station1");
            Station station2 = new Station("station2");

            Connection connection = new Connection(station1, station2, "   ");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CtorNullStationString()
        {
            Station station2 = new Station("station2");

            Connection connection = new Connection(null, station2, "line");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CtorStationNullString()
        {
            Station station1 = new Station("station1");

            Connection connection = new Connection(station1, null, "line");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CtorSameStationString()
        {
            Station station1 = new Station("station1");
            Station station2 = station1;

            Connection connection = new Connection(station1, station2, "line");
            Assert.Fail();
        }

        [TestMethod]
        public void EqualsTrueConnection1()
        {
            Station s1 = new Station("s1");
            Station s2 = new Station("s2");
            string lineName = "lineName";
            Connection c1 = new Connection(s1, s2, lineName);
            Connection c2 = new Connection(s2, s1, lineName);
            Assert.IsTrue(c1.Equals(c2));
        }


        [TestMethod]
        public void EqualsTrueConnection2()
        {
            Station s1 = new Station("s1");
            Station s2 = new Station("s2");
            string lineName = "lineName";
            Connection c1 = new Connection(s1, s2, lineName);
            Connection c2 = new Connection(s1, s2, lineName);
            Assert.IsTrue(c1.Equals(c2));
        }

        [TestMethod]
        public void EqualsFalseConnection()
        {
            Station s1 = new Station("s1");
            Station s2 = new Station("s2");
            Station s3 = new Station("s3");
            string lineName = "lineName";
            Connection c1 = new Connection(s1, s2, lineName);
            Connection c2 = new Connection(s3, s1, lineName);
            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod]
        public void EqualsNull()
        {
            Station s1 = new Station("s1");
            Station s2 = new Station("s2");
            string lineName = "lineName";
            Connection c1 = new Connection(s1, s2, lineName);
            Assert.IsFalse(c1.Equals(null));
        }

        [TestMethod]
        public void OperatorEqualsTrueConnectionConnection()
        {
            Station s1 = new Station("s1");
            Station s2 = new Station("s2");
            string lineName = "lineName";
            Connection c1 = new Connection(s1, s2, lineName);
            Connection c2 = new Connection(s1, s2, lineName);
            Assert.IsTrue(c1 == c2);
        }

        [TestMethod]
        public void OperatorEqualsFalseConnectionConnection()
        {
            Station s1 = new Station("s1");
            Station s2 = new Station("s2");
            Station s3 = new Station("s3");
            string lineName = "lineName";
            Connection c1 = new Connection(s1, s2, lineName);
            Connection c2 = new Connection(s3, s1, lineName);
            Assert.IsFalse(c1 == c2);
        }

        [TestMethod]
        public void OperatorEqualsNullConnection()
        {
            Station s1 = new Station("s1");
            Station s2 = new Station("s2");
            string lineName = "lineName";
            Connection c2 = new Connection(s1, s2, lineName);
            Assert.IsFalse(null == c2);
        }

        [TestMethod]
        public void OperatorEqualsConnectionNull()
        {
            Station s1 = new Station("s1");
            Station s2 = new Station("s2");
            string lineName = "lineName";
            Connection c2 = new Connection(s1, s2, lineName);
            Assert.IsFalse(c2 == null);
        }
    }
}