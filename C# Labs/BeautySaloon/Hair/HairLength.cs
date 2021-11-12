using System;

namespace BeautySaloon
{
    public static class HairLengthRoot
    {
        public abstract class HairLength
        {
            public abstract string Length { get; }
            public abstract int PriceMultiplier { get; }
        }

        public class LongHairLength : HairLength
        {
            public const string Type = "Длинные";
            public override string Length => Type;
            public override int PriceMultiplier => 3;
        }

        public class MediumHairLength : HairLength
        {
            public const string Type = "Средние";
            public override string Length => Type;
            public override int PriceMultiplier => 2;
        }

        public class ShortHairLength : HairLength
        {
            public const string Type = "Короткие";
            public override string Length => Type;
            public override int PriceMultiplier => 1;
        }

        public static string[] AvaliableHairLength => new string[] {
            LongHairLength.Type,
            MediumHairLength.Type,
            ShortHairLength.Type
        };
        public static HairLength SelectHairLength(string type)
        {
            switch (type) {
                case LongHairLength.Type: return new LongHairLength();
                case MediumHairLength.Type: return new MediumHairLength();
                case ShortHairLength.Type: return new ShortHairLength();
                default: throw new Exception("Unknown Hair Length");
            }
        }
    }
}
