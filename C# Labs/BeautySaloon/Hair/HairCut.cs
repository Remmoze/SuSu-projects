using System;

namespace BeautySaloon
{
    public static class HairCutRoot
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

            public BobbedHairCut(HairLengthRoot.HairLength hairLength) =>
                Price = CalculatePrice(hairLength);

            public int CalculatePrice(HairLengthRoot.HairLength hairLength) =>
                Price = DefaultPrice * hairLength.PriceMultiplier;

            public override int FinalPrice() => Price;
        }

        public class FoxTailHairCut : HairCut, IPricedHairItem
        {
            public const string Type = "Лисий хвост";
            public override string Style => Type;
            protected override int DefaultPrice => 300;
            public int Price { get; private set; }

            public FoxTailHairCut(HairLengthRoot.HairLength hairLength) =>
                Price = CalculatePrice(hairLength);

            public int CalculatePrice(HairLengthRoot.HairLength hairLength) =>
                Price = DefaultPrice * hairLength.PriceMultiplier;

            public override int FinalPrice() => Price;
        }

        public class BangHairCut : HairCut, IPricedHairItem
        {
            public const string Type = "Челка";
            public override string Style => Type;
            protected override int DefaultPrice => 300;
            public int Price { get; private set; }

            public BangHairCut(HairLengthRoot.HairLength hairLength) =>
                Price = CalculatePrice(hairLength);

            public int CalculatePrice(HairLengthRoot.HairLength hairLength) =>
                Price = DefaultPrice * hairLength.PriceMultiplier;

            public override int FinalPrice() => Price;
        }

        public static string[] AvalibleHaircuts => new string[] {
            BobbedHairCut.Type,
            FoxTailHairCut.Type,
            BangHairCut.Type
        };
        public static HairCut SelectHaircut(string type, HairLengthRoot.HairLength length)
        {
            switch (type) {
                case BobbedHairCut.Type: return new BobbedHairCut(length);
                case FoxTailHairCut.Type: return new FoxTailHairCut(length);
                case BangHairCut.Type: return new BangHairCut(length);
                default: throw new Exception("Unknown Haircut");
            }
        }
    }
}
