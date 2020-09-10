using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Notebook {
    public enum SearchOptions {
        name, phone, birthday
    }
    public class Notebook {


        public class Entry {
            public string LastName { get; }
            public string FirstName { get; }
            public string MiddleName { get; }
            public string FullName {
                get {
                    return $"{LastName} {FirstName} {MiddleName}";
                }
            }
            private DateTime BirthDayDateTime { get; set; }
            public string BirthDay {
                get {
                    return BirthDayDateTime.ToString("MM.dd.yy");
                }
            }
            public string PhoneNumber { get; }

            public Entry(string[] name, DateTime birthday, string phone) {

                LastName = name[0];
                FirstName = name[1];
                MiddleName = name[2];

                BirthDayDateTime = birthday;
                PhoneNumber = phone;
            }

            public void PrintFull() {
                Console.WriteLine($"{FullName} / {PhoneNumber} / {BirthDay}");
            }
        }

        private List<Entry> Entries = new List<Entry>();

        public Entry RequestInput() {

            Console.WriteLine("\n* Adding new entry to the list *");
            Console.WriteLine("Name (ex: LastName FirstName MiddleName):");
            string[] name = Console.ReadLine().Split(" ");
            while(name.Length < 3) {
                Console.WriteLine("Please write name in the correct form.");
                name = Console.ReadLine().Trim().Split(" ");
            }

            Console.WriteLine("Date of birth (ex: 23 10 1998):");
            DateTime date;
            while(!DateTime.TryParse(Regex.Replace(Console.ReadLine().Trim(), "[^0-9. ]", ""), out date)) { // only allow 0-9 and .
                Console.WriteLine("Please write the date of birth in the correct form.");
            }
            Console.WriteLine("Phone number (ex: +79823214412):");
            string phone = Regex.Replace(Console.ReadLine().Trim(), "[^0-9+]", ""); // only allow 0-9 and +

            return new Entry(name, date, phone);
        }

        public Entry RequestRemoval() {
            Console.WriteLine("* Please write down the index of the desired entry to be removed *");
            Console.WriteLine("* Write '-1' to exit *");
            ListEntries();

            string input;
            int index;
            while(true) {
                Console.Write("Index: ");
                input = Console.ReadLine();
                if(!int.TryParse(input, out index)) {
                    Console.WriteLine("Write a correct index value.");
                    continue;
                }
                if(index < -1 || index >= Entries.Count) {
                    Console.WriteLine("Index is out of bounds.");
                    continue;
                }
                break;
            }

            if(index == -1)
                return null;
            return Entries[index];
        }

        public void ListEntries() {
            Console.WriteLine("____________________");
            for(int i = 0; i < Entries.Count; i++) {
                Console.Write($"[{i}] ");
                Entries[i].PrintFull();
            }
            Console.WriteLine("____________________");
        }

        public void AddEntry(Entry entry) {
            Entries.Add(entry);
        }

        public void RemoveEntry(Entry entry) {
            Entries.Remove(entry);
        }

        public void Sort() {
            Entries.Sort((x, y) => string.Compare(x.FullName, y.FullName));
        }

        public Entry SearchBy(SearchOptions type) {

            string input;
            Console.Write("Search input: ");
            input = Console.ReadLine();

            switch(type) {
                case SearchOptions.birthday: {
                    return Entries.FirstOrDefault(x => x.BirthDay == input);
                }
                case SearchOptions.phone: {
                    return Entries.FirstOrDefault(x => x.PhoneNumber.Contains(input)); // a way to ignore '+' sign
                }
                case SearchOptions.name: {
                    return Entries.FirstOrDefault(x => x.FullName.StartsWith(input)); // can write just portion of the name
                }
                default:
                throw new ArgumentException("Invalid search option");
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            Notebook book = new Notebook();
            //test entry
            book.AddEntry(new Notebook.Entry(new string[] { "Ivanov", "Ivan", "Ivanovich" }, new DateTime(1998, 10, 11), "+9876543210"));

            Console.Write("Welcome to Notebook class. ");
            string[] input;
            PrintOptions();

            while(true) {
                input = Console.ReadLine().Split(" ");
                switch(input[0]) {
                    case "add": {
                        var entry = book.RequestInput();
                        Console.Clear();
                        book.AddEntry(entry);
                        Console.WriteLine("Entry successfully added!");
                        entry.PrintFull();
                        PrintOptions();
                        break;
                    }
                    case "delete":
                    case "remove": {
                        var entry = book.RequestRemoval();
                        Console.Clear();
                        if(entry != null) {
                            book.RemoveEntry(entry);
                            Console.WriteLine("Entry successfully deleted!");
                        } else {
                            Console.WriteLine("Couldn't delete entry!");
                        }

                        PrintOptions();
                        break;
                    }
                    case "sort": {
                        book.Sort();

                        PrintOptions();
                        break;
                    }
                    case "search":
                    case "find": {
                        if(input.Length < 2 || !Enum.TryParse(input[1], out SearchOptions option)) {
                            Console.WriteLine("Incorrect search type");
                            break;
                        }
                        var entry = book.SearchBy(option);
                        Console.Clear();
                        if(entry != null)
                            entry.PrintFull();
                        PrintOptions();
                        break;
                    }
                    case "list": {
                        Console.Clear();
                        book.ListEntries();
                        PrintOptions();
                        break;
                    }
                    case "exit": {
                        Console.Clear();
                        Console.WriteLine("Thank you for using Notebook class!");
                        Environment.Exit(0);
                        break;
                    }
                    default: {
                        Console.Clear();
                        Console.WriteLine("\nPlease write down the correct action from the list given below:");
                        PrintOptions(false);
                        break;
                    }
                }

            }
        }

        static void PrintOptions(bool showtip = true) {
            if(showtip) {
                Console.WriteLine();
                Console.WriteLine("Please write down the next action: ");
            }
            Console.WriteLine("* add");
            Console.WriteLine("* remove");
            Console.WriteLine("* sort");
            Console.WriteLine("* find <name/phone/birthday>");
            Console.WriteLine("* list");
            Console.WriteLine("* exit");
        }
    }
}