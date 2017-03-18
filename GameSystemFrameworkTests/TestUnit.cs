using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameSystemFramework;

namespace GameSystemFrameworkTests
{
    [TestClass]
    public class TestUnit
    {
        const string unitType = "infantry";
        const string name = "Bad Horse";
        const int id = 1;
        Unit unit = new Unit(unitType, id, name);

        [TestMethod]
        public void Creation() => Assert.AreEqual(unitType, unit.UnitType);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateUnitNullUnitTypeException()
        {
            Unit newUnit = new Unit(null, id, name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateUnitWhiteSpaceUnitTypeException()
        {
            Unit newUnit = new Unit("   ", id, name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateUnitNullNameException()
        {
            Unit newUnit = new Unit(unitType, id, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateUnitWhiteSpaceNameException()
        {
            Unit newUnit = new Unit(unitType, id, "   ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPropertyNullException()
        {
            unit.GetProperty<int>(null);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPropertyWhiteSpaceException()
        {
            unit.GetProperty<int>("   ");
            Assert.Fail();
        }

        [TestMethod]
        public void SetIntProperty()
        {
            string property = "hitPoints";
            int value = 25;
            unit.SetProperty(property, value);
            int storedValue = unit.GetProperty<int>(property);
            Assert.AreEqual(value, storedValue);
        }

        [TestMethod]
        public void ChangeIntProperty()
        {
            string property = "hitPoints";
            int value = 25;
            unit.SetProperty(property, value);
            int storedValue = unit.GetProperty<int>(property);
            Assert.AreEqual(value, storedValue);

            int newValue = 15;
            unit.SetProperty(property, newValue);
            storedValue = unit.GetProperty<int>(property);
            Assert.AreEqual(newValue, storedValue);
        }

        [TestMethod]
        public void SetUnitProperty()
        {
            string property = "unit";
            unit.SetProperty(property, unit);
            Unit storedValue = unit.GetProperty<Unit>(property);
            Assert.AreEqual(unit, storedValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetPropertyPropertyNull()
        {
            unit.SetProperty(null, 123);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetPropertyPropertyWhiteSpace()
        {
            unit.SetProperty("   ", 123);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetPropertyValueNull()
        {
            unit.SetProperty("abc", null);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetPropertyNonExistentValue()
        {
            unit.SetProperty("test", 123);
            unit.GetProperty<int>("abc");
            Assert.Fail();

        }

        [TestMethod]
        public void AddWeapon()
        {
            Assert.AreEqual(0, unit.Weapons.Count);
            unit.AddWeapon(new Weapon());
            Assert.AreEqual(1, unit.Weapons.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddWeaponNullWeapon()
        {
            unit.AddWeapon(null);
            Assert.Fail();
        }
    }
}