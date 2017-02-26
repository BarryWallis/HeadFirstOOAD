using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RicksGuitarsStart.Model
{
    class Guitar
    {
        public string SerialNumber { get; set; }
        public decimal Price { get; set; }
        public Builder Builder { get; set; }
        public string Model { get; set; }
        public Category Category { get; set; }
        public Wood TopWood { get; set; }
        public Wood BackWood { get; set; }

        /// <summary>
        /// Create a new Guitar instance.
        /// </summary>
        /// <param name="serialNumber">The Guitar serial number.</param>
        /// <param name="price">The Guitar price.</param>
        /// <param name="builder">The Guitar builder.</param>
        /// <param name="model">The Guitar model.</param>
        /// <param name="category">The Guitar type.</param>
        /// <param name="topWood">The Guitar  top wood.</param>
        /// <param name="backWood">The Guitar  back wood.</param>
        public Guitar(string serialNumber, decimal price, Builder builder, string model, Category category, Wood topWood, Wood backWood)
        {
            SerialNumber = serialNumber;
            Price = price;
            Builder = builder;
            Model = model;
            Category = category;
            TopWood = topWood;
            BackWood = backWood;
        }
    }
}
