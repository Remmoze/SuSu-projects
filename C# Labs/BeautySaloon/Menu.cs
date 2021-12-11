using System;
using System.Linq;

namespace BeautySaloon
{
    public static class Menu
    {
        public static void GenerateNewService()
        {
            var items = new PricedItemsCollection<IPricedItem>();

            var client = GetClient();
            var date = SelectDate();
            var barber = SelectBarber();
            items.Add(barber);

            if (Helper.GetBool("Нужна ли вам стрижка?"))
                items.Add(new HairCut(client.HairLength));

            if (Helper.GetBool("Нужна ли вам прическа?"))
                items.Add(new HairStyle(client.HairLength));

            if (Helper.GetBool("Нужно ли вам окрашивание?"))
                items.Add(new HairDye(client.HairLength));

            if (Helper.GetBool("Нужны ли вам украшения?"))
                items.Add(new HairAccessory());

            if (Helper.GetBool("Нужен ли вам уход за волосами?"))
                items.Add(new HairCare(client.HairLength));


            items.Sort((x, y) => x.CompareTo(y));

            //items.Sort(delegate (IPricedItem x, IPricedItem y) {
            //    return x.CompareTo(y);
            //});

            Console.Clear();
            Console.WriteLine("Вы: " + client);
            Console.WriteLine();
            Console.WriteLine("Вас будет обслуживать " + barber.Title);
            Console.WriteLine("Наши услуги дла вас:");
            Console.WriteLine(ListServices(items));
            Console.WriteLine();
            Console.WriteLine("Цена: " + items.Sum(item => item.Price));
            Console.WriteLine("Время приема: " + date);
            Console.WriteLine("Не опаздывайте!");
        }

        private static string ListServices(PricedItemsCollection<IPricedItem> items)
        {
            string str = "";
            foreach (var item in items) {
                str += item.Title;
                str += " (" + item.Price + "), ";
            }
            return str;
        }

        private static Client GetClient()
        {
            Console.Write("Ваше имя: ");
            var name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Ваша длина волос: ");
            string hairlength = Helper.OptionsSelector(new string[] { "Длинные", "Средние", "Короткие" });
            HairLength hair;
            switch (hairlength) {
                case "Длинные": hair = new LongHairLength(); break;
                case "Средние": hair = new MediumHairLength(); break;
                case "Короткие": hair = new ShortHairLength(); break;
                default: throw new Exception("Unknown hair length");
            }
            Console.Clear();
            return new Client(name, hair);
        }

        private static Date SelectDate()
        {
            Console.WriteLine("Выберете время для похода в салон: ");
            var hour = Helper.GetInt("Часы: ", 0, 23);
            var minutes = Helper.GetInt("Минуты: ", 0, 59);
            Console.Clear();
            return new Date(hour, minutes);
        }

        private static Barber SelectBarber()
        {
            Console.WriteLine("Выберете мастера: ");
            var barber = Helper.OptionsSelector(new string[] { "Старший", "Средний", "Младший" });
            Console.Clear();
            switch (barber) {
                case "Старший": return new ExperiencedBarber();
                case "Средний": return new IntermediateBarber();
                case "Младший": return new BeginnerBarber();
                default: throw new Exception("Unknown barber");
            }
        }
    }
}
