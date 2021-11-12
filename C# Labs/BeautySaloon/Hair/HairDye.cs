namespace BeautySaloon
{
    public abstract class HairDye
    {
        public abstract string Style { get; }
        protected abstract int DefaultPrice { get; }
        public abstract int FinalPrice();
    }

    public class HighlightingHairStyle : HairDye, IPricedHairItem
    {
        public const string Type = "Мелирование";
        public override string Style => Type;
        protected override int DefaultPrice => 160;
        public int Price { get; private set; }

        public HighlightingHairStyle(HairLength hairLength)
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

    public class NaturalHairStyle : HairDye, IPricedHairItem
    {
        public const string Type = "Естественное";
        public override string Style => Type;
        protected override int DefaultPrice => 200;
        public int Price { get; private set; }

        public NaturalHairStyle(HairLength hairLength)
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

    public class DyedHairStyle : HairDye, IPricedHairItem
    {
        public const string Type = "Цветное";
        public override string Style => Type;
        protected override int DefaultPrice => 140;
        public int Price { get; private set; }

        public DyedHairStyle(HairLength hairLength)
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
