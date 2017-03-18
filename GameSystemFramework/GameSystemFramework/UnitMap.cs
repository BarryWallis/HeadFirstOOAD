using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystemFramework
{
    class UnitMap : KeyedCollection<int, Unit>
    {
        protected override int GetKeyForItem(Unit item) => (item ?? throw new ArgumentNullException(nameof(item))).Id;
    }
}
