using System;

namespace BeautySaloon
{
    public static class HairStyleRoot
    {

        public abstract class HairStyle
        {
            public abstract string Style { get; }
            protected abstract int DefaultPrice { get; }
            public abstract int FinalPrice();
        }

        public class CurledHairStyle : HairStyle, IPricedHairItem
        {
            public const string Type = "Локоны";
            public override string Style => Type;
            protected override int DefaultPrice => 100;
            public int Price { get; private set; }

            public CurledHairStyle(HairLengthRoot.HairLength hairLength)
            {
                Price = CalculatePrice(hairLength);
            }

            public int CalculatePrice(HairLengthRoot.HairLength hairLength)
            {
                return Price = DefaultPrice * hairLength.PriceMultiplier;
            }

            public override int FinalPrice()
            {
                return Price;
            }
        }

        public class BundleHairStyle : HairStyle, IPricedHairItem
        {
            public const string Type = "Пучок";
            public override string Style => Type;
            protected override int DefaultPrice => 80;
            public int Price { get; private set; }

            public BundleHairStyle(HairLengthRoot.HairLength hairLength)
            {
                Price = CalculatePrice(hairLength);
            }

            public int CalculatePrice(HairLengthRoot.HairLength hairLength)
            {
                return Price = DefaultPrice * hairLength.PriceMultiplier;
            }

            public override int FinalPrice()
            {
                return Price;
            }
        }

        public class BraidsHairStyle : HairStyle, IPricedHairItem
        {
            public const string Type = "Косы";
            public override string Style => Type;
            protected override int DefaultPrice => 300;
            public int Price { get; private set; }

            public BraidsHairStyle(HairLengthRoot.HairLength hairLength)
            {
                Price = CalculatePrice(hairLength);
            }

            public int CalculatePrice(HairLengthRoot.HairLength hairLength)
            {
                return Price = DefaultPrice * hairLength.PriceMultiplier;
            }

            public override int FinalPrice()
            {
                return Price;
            }
        }
        public static string[] AvalibleHairStyles => new string[] {
            CurledHairStyle.Type,
            BundleHairStyle.Type,
            BraidsHairStyle.Type
        };
        public static HairStyle SelectHairStyle(string type, HairLengthRoot.HairLength length)
        {
            switch (type) {
                case CurledHairStyle.Type: return new CurledHairStyle(length);
                case BundleHairStyle.Type: return new BundleHairStyle(length);
                case BraidsHairStyle.Type: return new BraidsHairStyle(length);
                default: throw new Exception("Unknown Hair Style");
            }
        }
    }
}
