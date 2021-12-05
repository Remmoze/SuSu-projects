namespace BeautySaloon
{
    public abstract class HairLength
    {
        public abstract string Length { get; }
        public abstract int PriceMultiplier { get; }
    }

    public class LongHairLength : HairLength
    {
        public override string Length => "Длинные";
        public override int PriceMultiplier => 3;
    }

    public class MediumHairLength : HairLength
    {
        public override string Length => "Средние";
        public override int PriceMultiplier => 2;
    }

    public class ShortHairLength : HairLength
    {
        public override string Length => "Короткие";
        public override int PriceMultiplier => 1;
    }
}
