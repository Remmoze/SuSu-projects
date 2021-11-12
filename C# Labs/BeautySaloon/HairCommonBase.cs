using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloon
{
    public abstract class HairCommonBase : IPricedHairItem
    {
        public virtual string Style { get; }
        public virtual int Price { get; protected set; }
        protected virtual int DefaultPrice { get; private set; }
        public virtual int FinalPrice() => Price;

        public HairCommonBase(HairLengthRoot.HairLength hairLength) =>
            Price = CalculatePrice(hairLength);

        public virtual int CalculatePrice(HairLengthRoot.HairLength hairLength) =>
            Price = DefaultPrice * hairLength.PriceMultiplier;
    }
}
