namespace BeautySaloon
{
    public abstract class Barber : ItemBase
    {
        public override string Title { get; }
        public override int Price { get; }
    }

    public class ExperiencedBarber : Barber
    {
        public override string Title => "Старший Мастер";
        public override int Price => 2700;
    }

    public class IntermediateBarber : Barber
    {
        public override string Title => "Средний Мастер";
        public override int Price => 2000;
    }

    public class BeginnerBarber : Barber
    {
        public override string Title => "Младший Мастер";
        public override int Price => 1400;
    }
}
