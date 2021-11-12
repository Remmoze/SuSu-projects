using System;

namespace BeautySaloon
{
    public static class HairDyeRoot
    {
        public abstract class HairDye : HairCommonBase
        {
            public HairDye(HairLengthRoot.HairLength hairLength)
            : base(hairLength) { }
        }

        public class HighlightingHairStyle : HairDye, IPricedHairItem
        {
            public const string Type = "Мелирование";
            public override string Style => Type;
            protected override int DefaultPrice => 160;

            public HighlightingHairStyle(HairLengthRoot.HairLength hairLength)
            : base(hairLength) { }
        }

        public class NaturalHairStyle : HairDye, IPricedHairItem
        {
            public const string Type = "Естественное";
            public override string Style => Type;
            protected override int DefaultPrice => 200;

            public NaturalHairStyle(HairLengthRoot.HairLength hairLength)
            : base(hairLength) { }
        }

        public class DyedHairStyle : HairDye, IPricedHairItem
        {
            public const string Type = "Цветное";
            public override string Style => Type;
            protected override int DefaultPrice => 140;

            public DyedHairStyle(HairLengthRoot.HairLength hairLength)
            : base(hairLength) { }
        }

        public static string[] AvalibleHairDye => new string[] {
            HighlightingHairStyle.Type,
            NaturalHairStyle.Type,
            DyedHairStyle.Type,
            "Без окрашивания"
        };
        public static HairDye SelectHairDye(string type, HairLengthRoot.HairLength length)
        {
            switch (type) {
                case HighlightingHairStyle.Type: return new HighlightingHairStyle(length);
                case NaturalHairStyle.Type: return new NaturalHairStyle(length);
                case DyedHairStyle.Type: return new DyedHairStyle(length);
                case "Без окрашивания": return null;
                default: throw new Exception("Unknown Hair Dye");
            }
        }
    }
}
