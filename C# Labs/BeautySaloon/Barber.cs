namespace BeautySaloon
{
    public abstract class Barber
    {
        public abstract string Title { get; }
        public abstract int Price { get; }
    }

    public class ExperiencedBarber : Barber
    {
        public const string Type = "Старший";
        public override string Title => Type;
        public override int Price => 2700;
    }

    public class IntermediateBarber : Barber
    {
        public const string Type = "Средний";
        public override string Title => Type;
        public override int Price => 2000;
    }

    public class BeginnerBarber : Barber
    {
        public const string Type = "Младший";
        public override string Title => Type;
        public override int Price => 1400;
    }
}
