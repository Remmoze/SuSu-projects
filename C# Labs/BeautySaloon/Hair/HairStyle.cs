using System;

namespace BeautySaloon
{
    public static class HairStyleRoot
    {
        public abstract class HairStyle : HairCommonBase
        {
            public HairStyle(HairLengthRoot.HairLength hairLength)
            : base(hairLength) { }
        }

        public class CurledHairStyle : HairStyle
        {
            public const string Type = "Локоны";
            public override string Style => Type;
            protected override int DefaultPrice => 100;

            public CurledHairStyle(HairLengthRoot.HairLength hairLength)
            : base(hairLength) { }
        }

        public class BundleHairStyle : HairStyle
        {
            public const string Type = "Пучок";
            public override string Style => Type;
            protected override int DefaultPrice => 80;

            public BundleHairStyle(HairLengthRoot.HairLength hairLength)
            : base(hairLength) { }
        }

        public class BraidsHairStyle : HairStyle
        {
            public const string Type = "Косы";
            public override string Style => Type;
            protected override int DefaultPrice => 300;

            public BraidsHairStyle(HairLengthRoot.HairLength hairLength)
            : base(hairLength) { }
        }

        public static string[] AvalibleHairStyles => new string[] {
            CurledHairStyle.Type,
            BundleHairStyle.Type,
            BraidsHairStyle.Type
        };
        public static HairStyle SelectHairStyle(string type, HairLengthRoot.HairLength length)
        {
            switch (type) {
                case CurledHairStyle.Type: return new CurledHairStyle(length);
                case BundleHairStyle.Type: return new BundleHairStyle(length);
                case BraidsHairStyle.Type: return new BraidsHairStyle(length);
                default: throw new Exception("Unknown Hair Style");
            }
        }
    }
}
