using System;

namespace BeautySaloon
{
    public static class HairAccessoryRoot
    {
        public abstract class HairAccessory
        {
            public abstract string Style { get; }
            public abstract int FinalPrice();
        }

        public class Hairpins : HairAccessory, IPricedItem
        {
            public const string Type = "Заколки";
            public override string Style => Type;
            public virtual int Price => 50;

            public override int FinalPrice()
            {
                return Price;
            }
        }

        public class InvisibleHairpins : HairAccessory, IPricedItem
        {
            public const string Type = "Невидимки";
            public override string Style => Type;
            public int Price => 50;

            public override int FinalPrice()
            {
                return Price;
            }
        }

        public class Headbands : HairAccessory, IPricedItem
        {
            public const string Type = "Ободки";
            public override string Style => Type;
            public int Price => 60;

            public override int FinalPrice()
            {
                return Price;
            }
        }

        public class Combs : HairAccessory, IPricedItem
        {
            public const string Type = "Гребешки";
            public override string Style => Type;
            public int Price => 70;

            public override int FinalPrice()
            {
                return Price;
            }
        }

        public static string[] AvaliableAccessories => new string[] {
            Hairpins.Type,
            InvisibleHairpins.Type,
            Headbands.Type,
            Combs.Type,
            "Без Акксесуаров"
        };
        public static HairAccessory SelectAccessories(string type)
        {
            switch (type) {
                case Hairpins.Type: return new Hairpins();
                case InvisibleHairpins.Type: return new InvisibleHairpins();
                case Headbands.Type: return new Headbands();
                case Combs.Type: return new Combs();
                case "Без Акксесуаров": return null;
                default: throw new Exception("Unknown Hair Accessory");
            }
        }
    }
}
