namespace BeautySaloon
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

        public CurledHairStyle(HairLength hairLength)
        {
            Price = CalculatePrice(hairLength);
        }   

        public int CalculatePrice(HairLength hairLength)
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

        public BundleHairStyle(HairLength hairLength)
        {
            Price = CalculatePrice(hairLength);
        }

        public int CalculatePrice(HairLength hairLength)
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

        public BraidsHairStyle(HairLength hairLength)
        {
            Price = CalculatePrice(hairLength);
        }

        public int CalculatePrice(HairLength hairLength)
        {
            return Price = DefaultPrice * hairLength.PriceMultiplier;
        }

        public override int FinalPrice()
        {
            return Price;
        }
    }
}
