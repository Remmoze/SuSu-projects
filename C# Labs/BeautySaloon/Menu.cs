using System;

namespace BeautySaloon
{
    public static class Menu
    {
        public static Service GetNewService()
        {
            var client = GetClient();
            var barber = SelectBarber();
            var date = SelectDate();
            var service = new Service(client, barber, date);
            return SelectServices(service);
        }

        private static Client GetClient()
        {
            Console.Write("Ваше имя: ");
            var name = Console.ReadLine();
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
            service.Haircut = Helper.GetBool("Нужна ли вам стрижка?") ? new HairCut(service.Client.HairLength) : null;
            service.HairStyle = Helper.GetBool("Нужна ли вам прическа?") ? new HairStyle(service.Client.HairLength) : null;
            service.HairDye = Helper.GetBool("Нужно ли вам окрашивание?") ? new HairDye(service.Client.HairLength) : null;
            service.Accessories = Helper.GetBool("Нужны ли вам украшения?") ? new HairAccessory() : null;
            service.Care = Helper.GetBool("Нужен ли вам уход за волосами?") ? new HairCare(service.Client.HairLength) : null;
            Console.Clear();
            return service;
        }
    }
}
