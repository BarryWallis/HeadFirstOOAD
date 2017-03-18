using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameSystemFramework
{
    public class Unit // : IEquatable<Unit>
    {
        private Dictionary<string, object> properties = new Dictionary<string, object>();

        private List<Weapon> _weapons = new List<Weapon>();
        public ICollection<Weapon> Weapons { get => _weapons.ToArray(); }

        public int Id { get;}
        public string Name { get;  }
        public string UnitType { get; } = null;

        /// <summary>
        /// Create an instance of a Unit of the given <paramref name="unitType"/>.
        /// </summary>
        /// <param name="unitType">The type of unit to create.</param>
        /// <exception cref="ArgumentNullException"><paramref name="unitType"/> is null or white space or <paramref name="name"/> is null or white space.</exception>
        public Unit(string unitType, int id, string name)
        {
            if (string.IsNullOrWhiteSpace(unitType))
                throw new ArgumentNullException(nameof(unitType));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            UnitType = unitType;
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Return the specified property cast to the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="property">The property to get the value of.</param>
        /// <returns>The value of the specified property.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="property"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="property"/> is not a property of this Unit.</exception>
        public T GetProperty<T>(string property)
        {
            if (string.IsNullOrWhiteSpace(property))
                throw new ArgumentNullException(nameof(property));
            if (!properties.ContainsKey(property))
                throw new ArgumentOutOfRangeException(nameof(property), "Property not found");
            Debug.Assert(properties != null);
            Debug.Assert(properties[property] is T);

            return (T)properties[property];
        }

        /// <summary>
        /// Set the value of the specified property.
        /// </summary>
        /// <param name="property">The property to get the value of.</param>
        /// <param name="value">The value of the specified <paramref name="property"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="property"/> is null or <paramref name="value"/> is null.</exception>
        public void SetProperty(string property, object value)
        {
            if (string.IsNullOrWhiteSpace(property))
                throw new ArgumentNullException(nameof(property));
            Debug.Assert(properties != null);

            properties[property] = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Add a weapon to the list of weapons.
        /// </summary>
        /// <param name="weapon">The weapon to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="weapon"/> is null or <paramref name="value"/> is null.</exception>
        public void AddWeapon(Weapon weapon)
        {
            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon));
            Debug.Assert(_weapons != null);
            _weapons.Add(weapon);
        }

        ///// <summary>
        ///// Determines whether the specified Unit is equal to the current Unit.
        ///// </summary>
        ///// <param name="other">The Unit to compare with the current Unit.</param>
        ///// <returns>true if the specified Unit is equal to the current Unit; otherwise, false.</returns>
        //public bool Equals(Unit other) => other == null ? false : Id == other.Id;

        ///// <summary>
        ///// Determines whether the specified object is equal to the current UnitGroup.
        ///// </summary>
        ///// <param name="other">The object to compare with the current UnitGroup.</param>
        ///// <returns>true if the specified object is equal to the current Unit; otherwise, false.</returns>
        //public override bool Equals(object obj)
        //{
        //    switch (obj)
        //    {
        //        case Unit other:
        //            return Equals(other);
        //        case null:
        //        default:
        //            return false;
        //    }
        //}

        ///// <summary>
        ///// Return a hash code for the Unit.
        ///// </summary>
        ///// <returns>A hash code for the Unit.</returns>
        //public override int GetHashCode() => Id.GetHashCode();

        ///// <summary>
        ///// Determines whether two specified Unit have the same value.
        ///// </summary>
        ///// <param name="unit1">The first Unit to compare, or null.</param>
        ///// <param name="unit2">The second Unit to compare, or null.</param>
        ///// <returns>true if the value of <paramref name="unit1"/> is the same as the value of <paramref name="unit2"/>; otherwise, false.</returns>
        //public static bool operator ==(Unit unit1, Unit unit2)
        //    => (object)unit1 == null || (object)unit2 == null ? Object.Equals(unit1, unit2) : unit1.Equals(unit2);

        ///// <summary>
        ///// Determines whether two specified Units have different values.
        ///// </summary>
        ///// <param name="unit1">The first Unit to compare, or null.</param>
        ///// <param name="unit2">The second Unit to compare, or null.</param>
        ///// <returns>true if the value of <paramref name="unit1"/> is different from the value of <paramref name="unit2"/>; otherwise, false.</returns>
        //public static bool operator !=(Unit unit1, Unit unit2)
        //    => (object)unit1 == null || (object)unit2 == null ? !Object.Equals(unit1, unit2) : !unit1.Equals(unit2);
    }
}