using System;

namespace Vectormath {
    public class Vector {
        public double Length { get; set; }
        public double Angle { get; set; }

        public double Rads => Angle * Math.PI / 180;
        public double X => Length * Math.Cos(Rads);
        public double Y => Length * Math.Sin(Rads);

        public Vector(double length, double angle) => (Length, Angle) = (length, angle);

        private static Vector FromPoint(double x, double y)
            => new Vector(Math.Sqrt(x * x + y * y), Math.Atan(y / x) * (180 / Math.PI));

        public static Vector operator +(Vector a, Vector b) => FromPoint(a.X + b.X, a.Y + b.Y);
        public static Vector operator -(Vector a, Vector b) => FromPoint(a.X - b.X, a.Y - b.Y);
        public static double operator *(Vector a, Vector b) => a.X * b.X + a.Y * b.Y;

        public override string ToString() => $"Length: {Length:0.###} | Angle: {Angle:0.###}";
    }

    class Program {
        static void Main(string[] args) {
            var rnd = new Random();
            while(true) {
                Console.Clear();
                var a = new Vector(rnd.Next(1, 10), rnd.Next(360));
                var b = new Vector(rnd.Next(1, 10), rnd.Next(360));
                Console.WriteLine($"First Vector: \t{a}");
                Console.WriteLine($"Second Vector:\t{b}");
                Console.WriteLine($"Sum:\t\t{a + b}");
                Console.WriteLine($"Subtration:\t{a - b}");
                Console.WriteLine($"Dot product:\t{a * b:0.###}");

                Console.Write("\nContinue? Y/N: ");
                if(Console.ReadLine() == "N")
                    break;
            }
        }
    }
}
