using System;

namespace BeautySaloon
{
    public static class HairCareRoot
    {
        public class HairCare : IPricedHairItem
        {
            public virtual string Style { get; }
            public virtual int Price { get; protected set; }
            protected virtual int DefaultPrice { get; private set; }
            public virtual int FinalPrice() => Price;

            public HairCare(HairLengthRoot.HairLength hairLength) =>
                Price = CalculatePrice(hairLength);

            public virtual int CalculatePrice(HairLengthRoot.HairLength hairLength) =>
                Price = DefaultPrice * hairLength.PriceMultiplier;
        }

        public class WashHairCare : HairCare
        {
            public const string Type = "Мытье";
            public override string Style => Type;
            protected override int DefaultPrice => 50;

            public WashHairCare(HairLengthRoot.HairLength hairLength) : base(hairLength) { }
        }

        public class RestorationHairStyle : HairCare
        {
            public const string Type = "Восстановление";
            public override string Style => Type;
            protected override int DefaultPrice => 200;

            public RestorationHairStyle(HairLengthRoot.HairLength hairLength) : base(hairLength) { }
        }

        public class BalmHairStyle : HairCare
        {
            public const string Type = "Бальзамы";
            public override string Style => Type;
            protected override int DefaultPrice => 100;

            public BalmHairStyle(HairLengthRoot.HairLength hairLength) : base(hairLength) { }
        }

        public class TipsHairStyle : HairCare
        {
            public const string Type = "Кончики";
            public override string Style => Type;
            protected override int DefaultPrice => 90;

            public TipsHairStyle(HairLengthRoot.HairLength hairLength) : base(hairLength) =>
                Price = CalculatePrice(hairLength);

            public override int CalculatePrice(HairLengthRoot.HairLength hairLength) =>
                Price = DefaultPrice; // Длина волос не важна для кончиков
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
