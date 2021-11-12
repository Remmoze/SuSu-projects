using System;

namespace BeautySaloon
{
    public static class HairAccessoryRoot
    {
        public abstract class HairAccessory : IPricedItem
        {
            public virtual string Style { get; }
            public virtual int Price { get; private set; }
            public virtual int FinalPrice() => Price;
        }

        public class Hairpins : HairAccessory
        {
            public const string Type = "Заколки";
            public override string Style => Type;
            public override int Price => 50;
        }

        public class InvisibleHairpins : HairAccessory, IPricedItem
        {
            public const string Type = "Невидимки";
            public override string Style => Type;
            public override int Price => 50;
        }

        public class Headbands : HairAccessory, IPricedItem
        {
            public const string Type = "Ободки";
            public override string Style => Type;
            public override int Price => 60;
        }

        public class Combs : HairAccessory, IPricedItem
        {
            public const string Type = "Гребешки";
            public override string Style => Type;
            public override int Price => 70;
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
