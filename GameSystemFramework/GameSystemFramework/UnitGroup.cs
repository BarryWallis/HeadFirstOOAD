using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystemFramework
{
    public class UnitGroup // : IEquatable<UnitGroup>
    {
        private UnitMap _units = new UnitMap();
        public ICollection<Unit> Units
        {
            get
            {
                Debug.Assert(_units != null);
                return _units.ToList();
            }
        }

        /// <summary>
        /// Create a new instance without any Units in it.
        /// </summary>
        public UnitGroup() 
        {
        }

        /// <summary>
        /// Create a new instance populated with the given Units.
        /// </summary>
        /// <param name="units">The Collection of Units to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="units"/> is null.</exception>
        public UnitGroup(ICollection<Unit> units)
        {
            if (units == null)
                throw new ArgumentNullException(nameof(units));
            Debug.Assert(units != null);

            foreach (Unit unit in units)
            {
                this._units.Add(unit);
            }
        }

        /// <summary>
        /// Add a `<paramref name="unit"/> to the UnitGroup.
        /// </summary>
        /// <param name="unit">The Unit to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="units"/> is null.</exception>
        public void Add(Unit unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));
            Debug.Assert(_units != null);

            _units.Add(unit);
        }

        /// <summary>
        /// Remove a <paramref name="unit"/> from the UnitGroup.
        /// </summary>
        /// <param name="unit">The Unit to remove.</param>
        /// <exception cref="ArgumentNullException"><paramref name="units"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="unit"/> not in UnitGroup.</exception>
        public void Remove(Unit unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));
            if (!_units.Contains(unit))
                throw new ArgumentException("Unit not in UnitGroup", nameof(unit));
            Debug.Assert(_units != null);

            _units.Remove(unit);
        }

        /// <summary>
        /// Get the Unit with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the Unit to return.</param>
        /// <returns>The Unit corresponding to the <paramref name="id"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> of Unit not in UnitGroup.</exception>
        public Unit GetUnit(int id)
        {
            Debug.Assert(_units != null);
            if (!_units.Contains(id))
                throw new ArgumentOutOfRangeException(nameof(id), id, "Id not in UnitGroup");

            return _units[id];
        }

        ///// <summary>
        ///// Determines whether the specified UnitGroup is equal to the current UnitGroup.
        ///// </summary>
        ///// <param name="other">The UnitGroup to compare with the current UnitGroup.</param>
        ///// <returns>true if the specified UnitGroup is equal to the current UnitGroup; otherwise, false.</returns>
        //public bool Equals(UnitGroup other)
        //{
        //    if (other == null)
        //        return false;
        //    return _units.SequenceEqual(other._units);
        //}

        ///// <summary>
        ///// Determines whether the specified object is equal to the current UnitGroup.
        ///// </summary>
        ///// <param name="other">The object to compare with the current UnitGroup.</param>
        ///// <returns>true if the specified object is equal to the current UnitGroup; otherwise, false.</returns>
        //public override bool Equals(object obj)
        //{
        //    switch (obj)
        //    {
        //        case UnitGroup other:
        //            return Equals(other);
        //        case null:
        //        default:
        //            return false;
        //    }
        //}

        ///// <summary>
        ///// Return a hash code for the UnitGroup.
        ///// </summary>
        ///// <returns>A hash code for the UnitGroup.</returns>
        //public override int GetHashCode()
        //{
        //    int hashCode = 0;
        //    foreach (Unit unit in _units)
        //    {
        //        hashCode ^= unit.GetHashCode();
        //    }
        //    return hashCode;
        //}

        ///// <summary>
        ///// Determines whether two specified UnitGroups have the same value.
        ///// </summary>
        ///// <param name="unitGroup1">The first UnitGroup to compare, or null.</param>
        ///// <param name="unitGroup2">The second UnitGroup to compare, or null.</param>
        ///// <returns>true if the value of a is the same as the value of b; otherwise, false.</returns>
        //public static bool operator ==(UnitGroup unitGroup1, UnitGroup unitGroup2) 
        //    => (object)unitGroup1 == null || (object)unitGroup2 == null ? Object.Equals(unitGroup1, unitGroup2) : unitGroup1.Equals(unitGroup2);

        ///// <summary>
        ///// Determines whether two specified UnitGroups have different values.
        ///// </summary>
        ///// <param name="unitGroup1">The first UnitGroup to compare, or null.</param>
        ///// <param name="unitGroup2">The second UnitGroup to compare, or null.</param>
        ///// <returns>true if the value of a is the same as the value of b; otherwise, false.</returns>
        //public static bool operator !=(UnitGroup unitGroup1, UnitGroup unitGroup2)
        //    => (object)unitGroup1 == null || (object)unitGroup2 == null ? !Object.Equals(unitGroup1, unitGroup2) : !unitGroup1.Equals(unitGroup2);
    }
}
