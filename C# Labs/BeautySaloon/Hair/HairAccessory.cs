namespace BeautySaloon
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


}
