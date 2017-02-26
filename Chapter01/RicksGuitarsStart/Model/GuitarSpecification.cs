using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RicksGuitarsStart.Model
{
    class GuitarSpecification
    {
        public Builder Builder { get; }
        public string Model { get; }
        public Category Category { get; }
        public Wood TopWood { get;  }
        public Wood BackWood { get;  }
        public int NumberOfStrings { get; }

        /// <summary>
        /// Create a new GuitarSpecification instance.
        /// </summary>
        /// <param name="builder">The Guitar builder.</param>
        /// <param name="model">The Guitar model.</param>
        /// <param name="category">The Guitar type.</param>
        /// <param name="numberOfStrings">The number of strings on the Guitar.</param>
        /// <param name="topWood">The Guitar  top wood.</param>
        /// <param name="backWood">The Guitar  back wood.</param>
        public GuitarSpecification(Builder builder, string model, Category category, int numberOfStrings, Wood topWood, Wood backWood)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentNullException(nameof(model));
            if (numberOfStrings <= 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfStrings), numberOfStrings, "must be greater than 0");

            Builder = builder;
            Model = model;
            Category = category;
            NumberOfStrings = numberOfStrings;
            TopWood = topWood;
            BackWood = backWood;
        }
    }
}
