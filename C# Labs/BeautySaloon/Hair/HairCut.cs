namespace BeautySaloon
{
    public abstract class HairCut
    {
        public abstract string Style { get; }
        protected abstract int DefaultPrice { get; }
        public abstract int FinalPrice();
    }

    public class BobbedHairCut : HairCut, IPricedHairItem
    {
        public const string Type = "Каре";
        public override string Style => Type;
        protected override int DefaultPrice => 300;
        public int Price { get; private set; }

        public BobbedHairCut(HairLength hairLength)
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

    public class FoxTailHairCut : HairCut, IPricedHairItem
    {
        public const string Type = "Лисий хвост";
        public override string Style => Type;
        protected override int DefaultPrice => 300;
        public int Price { get; private set; }

        public FoxTailHairCut(HairLength hairLength)
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

    public class BangHairCut : HairCut, IPricedHairItem
    {
        public const string Type = "Челка";
        public override string Style => Type;
        protected override int DefaultPrice => 300;
        public int Price { get; private set; }

        public BangHairCut(HairLength hairLength)
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
