using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameSystemFramework;
using System.Collections.Generic;
using System.Linq;

namespace GameSystemFrameworkTests
{
    [TestClass]
    public class UnitGroupTest
    {
        [TestMethod]
        public void CreateDefaultUnitGroup()
        {
            UnitGroup unitGroup = new UnitGroup();
            Assert.AreEqual(0, unitGroup.Units.Count);
        }

        [TestMethod]
        public void CreateUnitsUnitGroup()
        {
            Unit[] units = new Unit[10];
            for (int i = 0; i < units.Length; i++)
            {
                units[i] = new Unit("Test Unit", i, i.ToString());
            }

            UnitGroup unitGroup = new UnitGroup(units);
            Assert.AreEqual(units.Length, unitGroup.Units.Count);
            Assert.IsTrue(unitGroup.Units.SequenceEqual(units));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateNullUnitGroup()
        {
            UnitGroup unitGroup = new UnitGroup(null);
            Assert.Fail();
        }

        [TestMethod]
        public void AddUnit()
        {
            Unit unit = new Unit("Test", 42, "Test Unit 42");
            UnitGroup unitGroup = new UnitGroup();
            unitGroup.Add(unit);
            Assert.AreEqual(unit.Id, unitGroup.Units.First().Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNull()
        {
            UnitGroup unitGroup = new UnitGroup();
            unitGroup.Add(null);
            Assert.Fail();
        }

        [TestMethod]
        public void RemoveUnit()
        {
            Unit unit = new Unit("Test", 42, "Test Unit 42");
            UnitGroup unitGroup = new UnitGroup();
            unitGroup.Add(unit);
            unitGroup.Remove(unit);
            Assert.AreEqual(0, unitGroup.Units.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNull()
        {
            UnitGroup unitGroup = new UnitGroup();
            unitGroup.Remove(null);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveUnitNotInUnitGroup()
        {
            Unit unit = new Unit("Test", 42, "Test Unit 42");
            UnitGroup unitGroup = new UnitGroup();
            unitGroup.Remove(unit);
            Assert.Fail();
        }

        [TestMethod]
        public void GetUnit()
        {
            Unit unit = new Unit("Test", 42, "Test Unit 42");
            UnitGroup unitGroup = new UnitGroup();
            unitGroup.Add(unit);
            Unit gotUnit = unitGroup.GetUnit(unit.Id);
            Assert.AreEqual(unit.Name, gotUnit.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetNull()
        {
            UnitGroup unitGroup = new UnitGroup();
            unitGroup.GetUnit(42);
            Assert.Fail();
        }
    }
}