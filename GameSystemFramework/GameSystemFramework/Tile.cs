using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameSystemFramework
{
    public class Tile
    {
        internal ICollection<Unit> Units { get; }  = new LinkedList<Unit>();

        /// <summary>
        /// Add the given unit to the tile.
        /// </summary>
        /// <param name="unit">The unit to add.</param>
        internal void Add(Unit unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));
            Debug.Assert(Units != null);

            Units.Add(unit);
        }

        /// <summary>
        /// Remove the given unit from the tile.
        /// </summary>
        /// <param name="unit">The unit to remove.</param>
        internal void Remove(Unit unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));
            Debug.Assert(Units != null);

            Units.Remove(unit);
        }

        /// <summary>
        /// Remove all the units from the tile.
        /// </summary>
        internal void RemoveUnits()
        {
            Debug.Assert(Units != null);

            Units.Clear();
        }
    }
}