using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Inheritance {

    public class Airline {
        private List<Plane> planes = new List<Plane>();
        public int AvarageWeight { get; private set; }

        public Airline() {
            //planes.Add(new PassengerPlane("Boeing_747", 333, 366));
            //planes.Add(new PassengerPlane("Airbus_A330", 500, 277));
            //planes.Add(new CargoPlane("TestCargo", 666, 333));
            RecalculateWeight();
        }

        private void RecalculateWeight() {
            AvarageWeight = planes.Sum(x => x.GetFlightLoad());
        }

        public void AddPlane(Plane plane) {
            planes.Add(plane);
            RecalculateWeight();
        }

        JsonSerializerSettings JsonSettings = new JsonSerializerSettings {
            TypeNameHandling = TypeNameHandling.All
        };
        public void ImportJSON(string path = "./test.json") {
            var json = File.ReadAllText(path);
            planes = JsonConvert.DeserializeObject<List<Plane>>(json, JsonSettings);
            RecalculateWeight();
        }

        public void ExportJSON(string path = "./test.json") {
            string json = JsonConvert.SerializeObject(planes, JsonSettings);
            File.WriteAllText(path, json);
        }

        public void Print() {
            foreach(var plane in planes) {
                Console.WriteLine($"{plane.name} | {plane.type} | {plane.GetFlightLoad()} kg");
            }
        }
    }

    class Program {
        public static Airline airline = new Airline();
        static void Main(string[] args) {

            var options = new string[] { "add", "sort", "list last 5 planes", "list last 3 flights", "Import from Json", "Export to Json", "exit" };
            var selected = 0;
            while(true) {
                Console.Clear();
                Console.WriteLine("* Select next action: \n");

                for(int i = 0; i < options.Length; i++) {
                    if(i == selected)
                        Console.Write("> ");
                    Console.WriteLine(options[i]);
                }

                switch(Console.ReadKey(true).Key) {
                    case ConsoleKey.DownArrow: {
                        selected = Math.Min(selected + 1, options.Length - 1);
                        break;
                    }
                    case ConsoleKey.UpArrow: {
                        selected = Math.Max(selected - 1, 0);
                        break;
                    }
                    case ConsoleKey.Enter: {
                        Select(options[selected]);
                        selected = 0;
                        break;
                    }

                }
            }
        }

        public static void Select(string option) {
            Console.Clear();
            switch(option) {
                case "add": {

                }
                case "Import from Json": {
                    airline.ImportJSON(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\airline.json");

                    Console.WriteLine("Files have been successfuly imported.");
                    Console.WriteLine("Press Any key to continue...");
                    Console.ReadKey(true);
                    return;
                }
                case "Export to Json": {
                    airline.ExportJSON(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\airline.json");

                    Console.WriteLine("Files have been successfuly exported.");
                    Console.WriteLine("Press Any key to continue...");
                    Console.ReadKey(true);
                    return;
                }
                case "exit": {
                    Console.Clear();
                    Console.WriteLine("bye!");
                    Environment.Exit(0);
                    return;
                }
                default: {
                    throw new Exception($"Invalid option '{option}'");
                }
            }
        }
    }
}
