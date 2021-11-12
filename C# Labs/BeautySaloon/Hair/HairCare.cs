using System;

namespace BeautySaloon
{
    public static class HairCareRoot
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

            public WashHairCare(HairLengthRoot.HairLength hairLength)
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

        public class RestorationHairStyle : HairCare, IPricedHairItem
        {
            public const string Type = "Восстановление";
            public override string Style => Type;
            protected override int DefaultPrice => 200;
            public int Price { get; private set; }

            public RestorationHairStyle(HairLengthRoot.HairLength hairLength)
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

        public class BalmHairStyle : HairCare, IPricedHairItem
        {
            public const string Type = "Бальзамы";
            public override string Style => Type;
            protected override int DefaultPrice => 100;
            public int Price { get; private set; }

            public BalmHairStyle(HairLengthRoot.HairLength hairLength)
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

        public class TipsHairStyle : HairCare, IPricedHairItem
        {
            public const string Type = "Кончики";
            public override string Style => Type;
            protected override int DefaultPrice => 90;
            public int Price { get; private set; }

            public TipsHairStyle(HairLengthRoot.HairLength hairLength)
            {
                Price = CalculatePrice(hairLength);
            }

            public int CalculatePrice(HairLengthRoot.HairLength hairLength)
            {
                return Price = DefaultPrice;
            }

            public override int FinalPrice()
            {
                return Price;
            }
        }

        public static string[] AvaliableCare => new string[] {
            WashHairCare.Type,
            RestorationHairStyle.Type,
            BalmHairStyle.Type,
            TipsHairStyle.Type,
            "Без Ухода"
        };
        public static HairCare SelectCare(string type, HairLengthRoot.HairLength length)
        {
            switch (type) {
                case WashHairCare.Type: return new WashHairCare(length);
                case RestorationHairStyle.Type: return new RestorationHairStyle(length);
                case BalmHairStyle.Type: return new BalmHairStyle(length);
                case TipsHairStyle.Type: return new TipsHairStyle(length);
                case "Без Ухода": return null;
                default: throw new Exception("Unknown Hair Accessory");
            }
        }
    }
    
}
