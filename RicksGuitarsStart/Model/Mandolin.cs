using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RicksGuitarsStart.Model
{
    class Mandolin : Instrument
    {
        public new MandolinSpecification Specification
        {
            get
            {
                MandolinSpecification specification = base.Specification as MandolinSpecification;
                Debug.Assert(specification != null);
                return specification;
            }
        }

        public Mandolin(string serialNumber, decimal price, MandolinSpecification specification) : base(serialNumber, price, specification)
        {
        }
    }
}
