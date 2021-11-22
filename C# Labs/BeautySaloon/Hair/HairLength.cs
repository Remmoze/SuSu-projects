namespace BeautySaloon
{
    public abstract class HairLength
    {
        public abstract string Length { get; }
        public abstract int PriceMultiplier { get; }
    }

    public class LongHairLength : HairLength
    {
        public override string Length
        {
            get
            {
                return "Длинные";
            }
        }
        public override int PriceMultiplier
        {
            get
            {
                return 3;
            }
        }
    }

    public class MediumHairLength : HairLength
    {
        public override string Length
        {
            get
            {
                return "Средние";
            }
        }
        public override int PriceMultiplier
        {
            get
            {
                return 2;
            }
        }
    }

    public class ShortHairLength : HairLength
    {
        public override string Length
        {
            get
            {
                return "Короткие";
            }
        }
        public override int PriceMultiplier
        {
            get
            {
                return 1;
            }
        }
    }
}
