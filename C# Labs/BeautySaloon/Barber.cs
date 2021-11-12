using System;

namespace BeautySaloon
{
    public static class BarberRoot
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

        public static string[] AvaliableBarber => new string[] {
            ExperiencedBarber.Type,
            IntermediateBarber.Type,
            BeginnerBarber.Type
        };
        public static Barber SelectBarber(string type)
        {
            switch (type) {
                case ExperiencedBarber.Type: return new ExperiencedBarber();
                case IntermediateBarber.Type: return new IntermediateBarber();
                case BeginnerBarber.Type: return new BeginnerBarber();
                default: throw new Exception("Unknown Barber experience");
            }
        }
    }

}
