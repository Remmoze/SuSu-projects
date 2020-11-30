using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance {
    public enum PlaneType {
        Passenger,
        Cargo
    }

    public abstract class Plane {
        public PlaneType type;
        public string name;
        public int weight; //tons

        public List<string> Flights;

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
            return cargoWeight + weight * 1000;
        }
    }

    public class PassengerPlane : Plane {
        public int passengers;
        public PassengerPlane(string name, int _weight, int _passengers) : base(name, _weight) {
            type = PlaneType.Passenger;
            passengers = _passengers;
        }
        public override int GetFlightLoad() {
            return passengers * 62 + weight * 1000;
        }
    }
}
