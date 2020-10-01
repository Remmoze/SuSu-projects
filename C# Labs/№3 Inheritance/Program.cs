using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Inheritance {

    public enum PlaneType {
        Passenger,
        Cargo
    }

    public abstract class Plane {
        public PlaneType type;
        public string name;
        public int weight; //tons
        public abstract int GetFlightLoad(); //kg
        public Plane(string _name, int _weight) {
            weight = _weight;
            name = _name;
        }
    }

    public class CargoPlane : Plane {
        public int cargoWeight;
        public CargoPlane(string name, int _weight, int cargo) : base(name, _weight) {
            type = PlaneType.Cargo;
            cargoWeight = cargo;
        }
        public override int GetFlightLoad() {
            return cargoWeight + weight*1000;
        }
    }

    public class PassengerPlane : Plane {
        public int passengers;
        public PassengerPlane(string name, int _weight, int _passengers) : base(name, _weight) {
            passengers = _passengers;
            type = PlaneType.Passenger;
        }
        public override int GetFlightLoad() {
            return passengers * 62 + weight * 1000;
        }
    }

    //public class Boeing_747 : PassangerPlane {
    //    public Boeing_747() : base(333, 366) {}
    //}
    //public class Airbus_A330 : PassangerPlane {
    //    public Airbus_A330() : base(500, 277) { }
    //}

    public class Airline {
        public List<Plane> planes = new List<Plane>();
        public Airline() {
            //planes.Add(new PassengerPlane("Boeing_747", 333, 366));
            //planes.Add(new PassengerPlane("Airbus_A330", 500, 277));
            //planes.Add(new CargoPlane("TestCargo", 666, 333));
        }

        public void ImportJSON() {
            var json = File.ReadAllText("./test.json");
            planes = JsonConvert.DeserializeObject<List<Plane>>(json);
        }

        public void ExportJSON() {
            var json = JsonConvert.SerializeObject(planes);
            File.WriteAllText("./test.json", json);
        }

        public void Print() {
            foreach(var plane in planes) {
                Console.WriteLine($"{plane.name}, {plane.type}, {plane.GetFlightLoad()}");
            }
        }
    }

    class Program {
        public static Airline airline = new Airline();
        static void Main(string[] args) {
            airline.ImportJSON();
            airline.Print();
            Console.WriteLine("Hello World!");
        }
    }
}
