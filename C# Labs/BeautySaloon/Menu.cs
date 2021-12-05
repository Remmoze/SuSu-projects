using System;

namespace BeautySaloon
{
    public static class Menu
    {
        public static Service GetNewService()
        {
            var client = GetClient();
            var date = SelectDate();
            var service = new Service(client, date);
            return SelectServices(service);
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

        private static Service SelectServices(Service service)
        {
            service.AddItem(SelectBarber());
            if (Helper.GetBool("Нужна ли вам стрижка?"))
                service.AddItem(new HairCut(service.Client.HairLength));

            if (Helper.GetBool("Нужна ли вам прическа?"))
                service.AddItem(new HairStyle(service.Client.HairLength));

            if (Helper.GetBool("Нужно ли вам окрашивание?"))
                service.AddItem(new HairDye(service.Client.HairLength));

            if (Helper.GetBool("Нужны ли вам украшения?"))
                service.AddItem(new HairAccessory());

            if (Helper.GetBool("Нужен ли вам уход за волосами?"))
                service.AddItem(new HairCare(service.Client.HairLength));

            Console.Clear();
            return service;
        }
    }
}
