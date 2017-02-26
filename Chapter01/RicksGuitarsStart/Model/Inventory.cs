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
                    if (!models.Contains(guitar.Specification.Model))
                        models.Add(guitar.Specification.Model);
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
            Add(new Guitar("11277", 3999.95m, new GuitarSpecification(Builder.Collings, "CJ", Category.Acoustic, 6, 
                                Wood.IndianRosewood, Wood.Sitka)));
            Add(new Guitar("V95693", 1499.95m, new GuitarSpecification(Builder.Fender, "Stratocastor", Category.Electric, 12, 
                                Wood.Alder, Wood.Alder)));
            Add(new Guitar("V9512", 1549.95m, new GuitarSpecification(Builder.Fender, "Stratocastor", Category.Electric, 6, 
                                Wood.Alder, Wood.Alder)));
            Add(new Guitar("122784", 5495.95m, new GuitarSpecification(Builder.Martin, "D-18", Category.Acoustic, 6, 
                                Wood.Mahogany, Wood.Adirondack)));
            Add(new Guitar("76531", 295.95m, new GuitarSpecification(Builder.Martin, "OM-28", Category.Acoustic, 6, 
                                Wood.BrazilianRosewood, Wood.Adirondack)));
            Add(new Guitar("70108276", 2295.95m, new GuitarSpecification(Builder.Gibson, "Les Paul", Category.Electric, 6,
                                Wood.Mahogany, Wood.Maple)));
            Add(new Guitar("82765501", 1890.95m, new GuitarSpecification(Builder.Gibson, "SG '61 Reissue",
                                Category.Electric, 6, Wood.Mahogany, Wood.Mahogany)));
            Add(new Guitar("77023", 275.95m, new GuitarSpecification(Builder.Martin, "D-28", Category.Acoustic, 6,
                                Wood.BrazilianRosewood, Wood.Adirondack)));
            Add(new Guitar("1092", 12995.95m, new GuitarSpecification(Builder.Olson, "SJ", Category.Acoustic, 6,
                                Wood.IndianRosewood, Wood.Cedar)));
            Add(new Guitar("566-62", 8999.95m, new GuitarSpecification(Builder.Ryan, "Cathedral", Category.Acoustic, 6,
                                Wood.Cocobolo, Wood.Cedar)));
            Add(new Guitar("6 29584", 2100.95m, new GuitarSpecification(Builder.PRS, "Dave Navarro Signature",
                                Category.Electric, 6, Wood.Mahogany, Wood.Maple)));
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
        public ICollection<Guitar> Search(GuitarSpecification searchGuitarSpecification)
        {
            if (searchGuitarSpecification is null)
                throw new ArgumentNullException(nameof(searchGuitarSpecification));

            List<Guitar> foundGuitars = new List<Guitar>();
            foreach (Guitar guitar in guitars)
            {
                if (searchGuitarSpecification.Builder != guitar.Specification.Builder)
                    continue;
                if (!string.IsNullOrEmpty(guitar.Specification.Model) && searchGuitarSpecification.Model != guitar.Specification.Model)
                    continue;
                if (searchGuitarSpecification.Category != guitar.Specification.Category)
                    continue;
                if (searchGuitarSpecification.NumberOfStrings != guitar.Specification.NumberOfStrings)
                    continue;
                if (searchGuitarSpecification.TopWood != guitar.Specification.TopWood)
                    continue;
                if (searchGuitarSpecification.BackWood != guitar.Specification.BackWood)
                    continue;
                foundGuitars.Add(guitar);
            }

            return foundGuitars;
        }
    }
}
