using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelHydrator
{
    public class EnhancedRandom : Random
    {
        private const string CHARACTER_SET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_-";

        public EnhancedRandom() : base() {}
        public EnhancedRandom(int seed) : base(seed) {}

        public virtual char NextChar()
        {
            return CHARACTER_SET[Next(CHARACTER_SET.Length)];
        }

        public virtual string NextString(int length)
        {
            string result = "";
            for (int i = 0; i < length; i++)
            {
                result += NextChar();
            }

            return result;
        }

        public virtual int NextDimension(ModelProperty property, int defaultMin, int defaultMax)
        {
            var min = property.Min.HasValue ? property.Min.Value : defaultMin;
            var max = property.Max.HasValue ? property.Max.Value : defaultMax;

            return Next(min, max);
        }
    }
}
