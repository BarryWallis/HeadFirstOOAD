using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteFinderLibrary;
using System.IO;
using System.Linq;

namespace RouteFinderLibraryTests
{
    [TestClass]
    public class SubwayLoaderTests
    {
        Station[] stations =
        {
            new Station("Ajax Rapids"),
            new Station("Algebra Avenue"),
            new Station("Boards 'R' Us"),
            new Station("Break Neck Pizza"),
            new Station("Choc-O-Holic, Inc"),
            new Station("CSS Center"),
            new Station("Design Patterns Plaza"),
            new Station("DRY Drive"),
            new Station("EJB Estates"),
            new Station("GoF Gardens"),
            new Station("Head First Theater"),
            new Station("Head First Lounge"),
            new Station("HeadFirstLabs"),
            new Station("HTML Heights"),
            new Station("Infinite Circle"),
            new Station("JavaRanch"),
            new Station("JSP Junction"),
            new Station("LSP Lane"),
            new Station("Objectville Diner"),
            new Station("Objectville PizzaStore"),
            new Station("OCP Orchard"),
            new Station("OOA&D Oval"),
            new Station("PMP Place"),
            new Station("Servlet Springs"),
            new Station("SRP Square"),
            new Station("SimUDuck Lake"),
            new Station("The Tikibean Lounge"),
            new Station("UML Walk"),
            new Station("Weather-O-Rama, inc."),
            new Station("WebDesignWay"),
            new Station("XHTML Expressway"),
        };

        string[] rumbaughLine =
        {
            "XHTML Expressway",
            "Infinite Circle",
            "Head First Theater",
            "Choc-O-Holic, Inc",
            "XHTML Expressway",
        };

        string[] wirfsBrockLine =
        {
            "Weather-O-Rama, inc.",
            "HTML Heights",
            "UML Walk",
            "The Tikibean Lounge",
            "Head First Lounge",
            "Objectville Diner",
            "Servlet Springs",
            "SRP Square",
            "Break Neck Pizza",
            "EJB Estates",
            "Boards 'R' Us",
            "PMP Place",
            "DRY Drive",
            "Algebra Avenue",
            "LSP Lane",
            "XHTML Expressway",
            "Weather-O-Rama, inc.",
        };

        [TestMethod]
        public void SubwayLoaderTest()
        {
            SubwayLoader subwayLoader = new SubwayLoader();
            using (StreamReader streamReader = new StreamReader(@"TestFiles\ObectvilleSubway.txt"))
            {
                Subway subway = subwayLoader.Load(streamReader);
                Assert.AreEqual(stations.Length, subway.GetStations().Count);
                Assert.IsTrue(subway.GetStations().SequenceEqual(stations));
                CheckLine(subway, "Wirfs-Brock Line", wirfsBrockLine);
            }
        }

        private void CheckLine(Subway subway, string lineName, string[] stations)
        {
            for (int i = 0; i < stations.Length - 1; i++)
            {
                Assert.IsTrue(subway.HasConnection(stations[i], stations[i + 1], lineName));
            }
        }
    }
}
