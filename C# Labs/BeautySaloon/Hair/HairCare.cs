namespace BeautySaloon
{
    public abstract class HairCare
    {
        public abstract string Style { get; }
        protected abstract int DefaultPrice { get; }
        public abstract int FinalPrice();
    }

    public class WashHairCare : HairCare, IPricedHairItem
    {
        public const string Type = "Мытье";
        public override string Style => Type;
        protected override int DefaultPrice => 50;
        public int Price { get; private set; }

        public WashHairCare(HairLength hairLength)
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

    public class RestorationHairStyle : HairCare, IPricedHairItem
    {
        public const string Type = "Восстановление";
        public override string Style => Type;
        protected override int DefaultPrice => 200;
        public int Price { get; private set; }

        public RestorationHairStyle(HairLength hairLength)
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

    public class BalmHairStyle : HairCare, IPricedHairItem
    {
        public const string Type = "Бальзамы";
        public override string Style => Type;
        protected override int DefaultPrice => 100;
        public int Price { get; private set; }

        public BalmHairStyle(HairLength hairLength)
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

    public class TipsHairStyle : HairCare, IPricedHairItem
    {
        public const string Type = "Кончики";
        public override string Style => Type;
        protected override int DefaultPrice => 90;
        public int Price { get; private set; }

        public TipsHairStyle(HairLength hairLength)
        {
            Price = CalculatePrice(hairLength);
        }

        public int CalculatePrice(HairLength hairLength)
        {
            return Price = DefaultPrice;
        }

        public override int FinalPrice()
        {
            return Price;
        }
    }
}
