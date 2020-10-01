using System;

namespace Vectormath {
    public class Vector {
        private double _Length;
        public double Length {
            get { return _Length; }
            set { _Length = Math.Max(0d, value); }
        }
        private double _Angle;
        public double Angle {
            get { return _Angle; }
            set { _Angle = value % 360; }
        }

        public double Rads {
            get { return Angle * Math.PI / 180; }
        }
        public double X {
            get { return Length * Math.Cos(Rads); }
        }
        public double Y {
            get { return Length * Math.Sin(Rads); }
        }

        public Vector(double length, double angle) {
            (Length, Angle) = (length, angle);
        }

        private static Vector FromPoint(double x, double y) {
            return new Vector(Math.Sqrt(x * x + y * y), Math.Atan(y / x) * (180 / Math.PI));
        }

        public static Vector operator +(Vector a, Vector b) {
            return FromPoint(a.X + b.X, a.Y + b.Y);
        }
        public static Vector operator -(Vector a, Vector b) {
            return FromPoint(a.X - b.X, a.Y - b.Y);
        }
        public static double operator *(Vector a, Vector b) {
            return a.X * b.X + a.Y * b.Y;
        }

        public override string ToString() {
            return $"Length: {Length:0.###} | Angle: {Angle:0.###}";
        }
    }

    class Program {
        static void Main(string[] args) {

            double length = 0;
            double angle = 0;

            while(true) {
                Console.Clear();

                Console.WriteLine("First vector:");
                Console.Write("Length: ");
                length = Convert.ToDouble(Console.ReadLine());
                Console.Write("Angle: ");
                angle = Convert.ToDouble(Console.ReadLine());
                var VectorA = new Vector(length, angle);

                Console.WriteLine("\nSecond vector:");
                Console.Write("Length: ");
                length = Convert.ToDouble(Console.ReadLine());
                Console.Write("Angle: ");
                angle = Convert.ToDouble(Console.ReadLine());
                var VectorB = new Vector(length, angle);

                Console.Clear();

                Console.WriteLine("First Vector: " + VectorA);
                Console.WriteLine("Second Vector: " + VectorB);
                Console.WriteLine("Sum: " + (VectorA + VectorB));
                Console.WriteLine("Subtration: " + (VectorA - VectorB));
                Console.WriteLine("Dot product: " + (VectorA * VectorB).ToString("0.###"));

                Console.Write("\nContinue? Y/N: ");
                if(Console.ReadLine() == "N")
                    break;
            }
        }
    }
}
