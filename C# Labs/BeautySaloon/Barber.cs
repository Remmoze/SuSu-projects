namespace BeautySaloon
{
    public abstract class Barber : ItemBase
    {
        public abstract string Title { get; }
        public override int Price { get; }
    }

    public class ExperiencedBarber : Barber
    {
        public override string Title
        {
            get
            {
                return "Старший";
            }
        }
        public override int Price
        {
            get
            {
                return 2700;
            }
        }
    }

    public class IntermediateBarber : Barber
    {
        public override string Title
        {
            get
            {
                return "Средний";
            }
        }
        public override int Price
        {
            get
            {
                return 2000;
            }
        }
    }

    public class BeginnerBarber : Barber
    {
        public override string Title
        {
            get
            {
                return "Младший";
            }
        }
        public override int Price
        {
            get
            {
                return 1400;
            }
        }
    }
}
