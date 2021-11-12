using System;

namespace BeautySaloon
{
    public static class HairCutRoot
    {
        public abstract class HairCut : IPricedHairItem
        {
            public virtual string Style { get; }
            public virtual int Price { get; protected set; }
            protected virtual int DefaultPrice { get; private set; }
            public virtual int FinalPrice() => Price;

            public HairCut(HairLengthRoot.HairLength hairLength) =>
                Price = CalculatePrice(hairLength);

            public virtual int CalculatePrice(HairLengthRoot.HairLength hairLength) =>
                Price = DefaultPrice * hairLength.PriceMultiplier;
        }

        public class BobbedHairCut : HairCut, IPricedHairItem
        {
            public const string Type = "Каре";
            public override string Style => Type;
            protected override int DefaultPrice => 300;

            public BobbedHairCut(HairLengthRoot.HairLength hairLength) : base(hairLength) { }
        }

        public class FoxTailHairCut : HairCut, IPricedHairItem
        {
            public const string Type = "Лисий хвост";
            public override string Style => Type;
            protected override int DefaultPrice => 300;

            public FoxTailHairCut(HairLengthRoot.HairLength hairLength) : base(hairLength) { }
        }

        public class BangHairCut : HairCut, IPricedHairItem
        {
            public const string Type = "Челка";
            public override string Style => Type;
            protected override int DefaultPrice => 300;

            public BangHairCut(HairLengthRoot.HairLength hairLength) : base(hairLength) { }
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
