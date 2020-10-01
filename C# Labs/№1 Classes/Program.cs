using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Notebook {
    public class Entry {
        private DateTime BirthDayDateTime { get; }
        public string FullName { get; }
        public string BirthDay {
            get {
                return BirthDayDateTime.ToString("dd.MM.yy");
            }
        }
        public string PhoneNumber { get; }

        public Entry(string name, DateTime birthday, string phone) {
            FullName = name;
            BirthDayDateTime = birthday;
            PhoneNumber = phone;
        }

        public override string ToString() {
            return $"{FullName} / {PhoneNumber} / {BirthDay}";
        }
    }

    public class Notebook {
        private readonly List<Entry> Entries = new List<Entry>();

        public void AddEntry(Entry entry) {
            Entries.Add(entry);
        }

        public void RemoveEntry(Entry entry) {
            Entries.Remove(entry);
        }

        public void SortByName() {
            Entries.Sort((x, y) => string.Compare(x.FullName, y.FullName));
        }

        public IEnumerable<Entry> SearchName(string input) {
            return Entries.FindAll(x => x.FullName.StartsWith(input));
        }

        public IEnumerable<Entry> SearchPhone(string input) {
            return Entries.FindAll(x => x.PhoneNumber.Contains(input));
        }

        public IEnumerable<Entry> SearchBirthday(string input) {
            DateTime date;
            while(!DateTime.TryParse(Regex.Replace(input.Trim(), "[^0-9. ]", ""), out date)) {
                return null;
            }
            return Entries.FindAll(x => x.BirthDay == date.ToString("dd.MM.yy"));
        }

        public List<Entry> GetEntries() {
            return Entries;
        }
    }

    class Program {
        static void Main(string[] args) {
            Notebook book = new Notebook();
            book.AddEntry(new Entry("Ivanov Ivan Ivanovich", new DateTime(1998, 10, 11), "+9876543210"));// default entry

            var options = new string[] { "add", "remove", "sort", "list", "search by name", "search by birthday", "search by phone", "exit"};
            string[] input;

            Console.Title = "Welcome to Notebook class.";
            var selected = 0;
            while(true) {
                Console.Clear();

                for(int i = 0; i < options.Length; i++) {
                    if(i == selected)
                        Console.Write("> ");
                    Console.WriteLine(options[i]);
                }

                var command = Console.ReadKey(true).Key;
                if(command == ConsoleKey.DownArrow)
                    selected = Math.Min(selected + 1, options.Length-1);

                else if(command == ConsoleKey.UpArrow)
                    selected = Math.Max(selected - 1, 0);

                else if(command == ConsoleKey.Enter) {
                    Console.Title = "";
                    switch(options[selected]) {
                        case "add": {
                            book.AddEntry(NewEntry());
                            Console.Title = "Entry successfully added!";
                            break;
                        }
                        case "remove": {
                            RemovalSystem(book);
                            break;
                        }
                        case "sort": {
                            book.SortByName();
                            Console.Title = "Notebook has been sorted!";
                            break;
                        }
                        case "list": {
                            Console.Clear();
                            foreach(var entry in book.GetEntries())
                                Console.WriteLine(entry);
                            Console.WriteLine("\nPress any key to continue");
                            Console.ReadKey(true);
                            break;
                        }
                        case "search by name": {
                            Console.Clear();
                            Console.Title = "Search by name: ";
                            Console.Write("Name: ");
                            PrintSearch(book.SearchName(Console.ReadLine()));
                            Console.Title = "";
                            break;
                        }
                        case "search by birthday": {
                            Console.Clear();
                            Console.Title = "Search by birthday: ";
                            Console.Write("Birthday: ");
                            PrintSearch(book.SearchBirthday(Console.ReadLine()));
                            Console.Title = "";
                            break;
                        }
                        case "search by phone": {
                            Console.Clear();
                            Console.Title = "Search by phone: ";
                            Console.Write("Phone: ");
                            PrintSearch(book.SearchPhone(Console.ReadLine()));
                            Console.Title = "";
                            break;
                        }
                        case "exit": {
                            Console.Clear();
                            Console.WriteLine("Thank you for using Notebook class!");
                            Environment.Exit(0);
                            break;
                        }
                    }
                    selected = 0;
                }
            }
        }

        public static Entry NewEntry() {
            Console.Clear();
            Console.WriteLine("* Adding new entry to the list *");
            Console.Write("Name: ");
            string name = Console.ReadLine().Trim();

            Console.Write("Date of birth: ");
            DateTime date;
            while(!DateTime.TryParse(Regex.Replace(Console.ReadLine().Trim(), "[^0-9. ]", ""), out date)) { // only allow 0-9 and .
                Console.WriteLine("Please write the date of birth in the correct form.");
            }

            Console.Write("Phone number: ");
            string phone = Console.ReadLine().Trim();

            return new Entry(name, date, phone);
        }

        public static void RemovalSystem(Notebook book) {
            Console.Clear();
            var selected = 0;
            while(true) {
                Console.Clear();
                Console.WriteLine("* Press enter to remove an entry *\n");
                var entries = book.GetEntries();

                for(int i = 0; i < entries.Count+1; i++) {
                    if(i == selected)
                        Console.Write("> ");
                    if(i < entries.Count)
                        Console.WriteLine(entries[i]);
                    else
                        Console.WriteLine("exit");
                }

                switch(Console.ReadKey(true).Key) {
                    case ConsoleKey.DownArrow: {
                        selected = Math.Min(selected + 1, entries.Count);
                        break;
                    }
                    case ConsoleKey.UpArrow: {
                        selected = Math.Max(selected - 1, 0);
                        break;
                    }
                    case ConsoleKey.Enter: {
                        if(selected == entries.Count)
                            return; //exit selected
                        book.RemoveEntry(entries[selected]);
                        selected = 0;
                        break;
                    }
                    
                }
            }
        }

        public static void PrintSearch(IEnumerable<Entry> result) {
            Console.Clear();
            if(result == null || result.Count() == 0)
                Console.WriteLine("Your search didn't return any matches.");
            else { 
                Console.WriteLine("Your search returned matches: ");
                foreach(var entry in result) {
                    Console.WriteLine(entry);
                }
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey(true);
        }
    }
}