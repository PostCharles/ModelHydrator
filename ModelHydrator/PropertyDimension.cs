using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHydrator
{
    public class PropertyDimension
    {
        public bool HasMin { get; private set; }
        public int Min { get; private set; }
        public bool HasMax { get; private set; }
        public int Max { get; private set; }

        public void SetMin(int min)
        {
            HasMin = true;
            Min = min;
        }

        public void SetMax(int max)
        {
            HasMax = true;
            Max = max;
        }

    }
}
