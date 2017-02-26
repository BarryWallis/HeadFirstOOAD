using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RicksGuitarsStart.Model
{
    class Inventory
    {
        private List<Guitar> guitars = new List<Guitar>();

        public ICollection<string> Models
        {
            get
            {
                List<string> models = new List<string>();
                foreach (Guitar guitar in guitars)
                {
                    if (!models.Contains(guitar.Model))
                        models.Add(guitar.Model);
                }
                models.Sort();
                return models;
            }
        }

       /// <summary>
        /// Create a new instance of Inventory.
        /// </summary>
        public Inventory()
        {

        }

        /// <summary>
        /// Initialize the inventory.
        /// </summary>
        public void Initialize()
        {
            guitars.Add(new Guitar("11277", 3999.95m, Builder.Collings, "CJ", Category.Acoustic,
                                Wood.IndianRosewood, Wood.Sitka));
            guitars.Add(new Guitar("V95693", 1499.95m, Builder.Fender, "Stratocastor", Category.Electric,
                                Wood.Alder, Wood.Alder));
            guitars.Add(new Guitar("V9512", 1549.95m, Builder.Fender, "Stratocastor", Category.Electric,
                                Wood.Alder, Wood.Alder));
            guitars.Add(new Guitar("122784", 5495.95m, Builder.Martin, "D-18", Category.Acoustic,
                                Wood.Mahogany, Wood.Adirondack));
            guitars.Add(new Guitar("76531", 6295.95m, Builder.Martin, "OM-28", Category.Acoustic,
                                Wood.BrazilianRosewood, Wood.Adirondack));
            guitars.Add(new Guitar("70108276", 2295.95m, Builder.Gibson, "Les Paul", Category.Electric,
                                Wood.Mahogany, Wood.Maple));
            guitars.Add(new Guitar("82765501", 1890.95m, Builder.Gibson, "SG '61 Reissue",
                                Category.Electric, Wood.Mahogany, Wood.Mahogany));
            guitars.Add(new Guitar("77023", 6275.95m, Builder.Martin, "D-28", Category.Acoustic,
                                Wood.BrazilianRosewood, Wood.Adirondack));
            guitars.Add(new Guitar("1092", 12995.95m, Builder.Olson, "SJ", Category.Acoustic,
                                Wood.IndianRosewood, Wood.Cedar));
            guitars.Add(new Guitar("566-62", 8999.95m, Builder.Ryan, "Cathedral", Category.Acoustic,
                                Wood.Cocobolo, Wood.Cedar));
            guitars.Add(new Guitar("6 29584", 2100.95m, Builder.PRS, "Dave Navarro Signature",
                                Category.Electric, Wood.Mahogany, Wood.Maple));
        }

        /// <summary>
        /// Add a Guitar to the inventory.
        /// </summary>
        /// <param name="guitar">The Guitar to add to the inventory.</param>
        public void Add(Guitar guitar)
        {
            if (guitar is null)
                throw new ArgumentNullException(nameof(guitar));

            guitars.Add(guitar);
        }

        /// <summary>
        /// Search for a Guitar like the one given as a parameter.
        /// </summary>
        /// <param name="searchGuitar">The Guitar to searcvh for.</param>
        /// <returns>A collection of all the guitars that match the criteria.</returns>
        public ICollection<Guitar> Search(Guitar searchGuitar)
        {
            if (searchGuitar is null)
                throw new ArgumentNullException(nameof(searchGuitar));

            List<Guitar> foundGuitars = new List<Guitar>();
            foreach (Guitar guitar in guitars)
            {
                if (searchGuitar.Builder != guitar.Builder)
                    continue;
                if (!string.IsNullOrEmpty(guitar.Model) && searchGuitar.Model != guitar.Model)
                    continue;
                if (searchGuitar.Category != guitar.Category)
                    continue;
                if (searchGuitar.TopWood != guitar.TopWood)
                    continue;
                if (searchGuitar.BackWood != guitar.BackWood)
                    continue;
                foundGuitars.Add(guitar);
            }

            return foundGuitars;
        }
    }
}
