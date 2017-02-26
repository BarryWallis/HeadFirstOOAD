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

        public GuitarSpecification(Builder builder, string model, Category category, Wood topWood, Wood backWood)
        {
            Builder = builder;
            Model = model;
            Category = category;
            TopWood = topWood;
            BackWood = backWood;
        }
    }
}
