using System;
using System.Collections.Generic;

namespace BeautySaloon
{
    public class Menu
    {
        public Service GetNewService()
        {
            return SelectServices(new Service() {
                Client = GetClient(),
                Date = SelectDate(),
                Barber = SelectBarber()
            });
        }

        private static Client GetClient()
        {
            Console.Write("Ваше имя: ");
            var name = Console.ReadLine();
            Console.WriteLine("Ваша длина волос: ");
            HairLengthRoot.HairLength hair = HairLengthRoot.SelectHairLength(Helper.OptionsSelector(HairLengthRoot.AvaliableHairLength));
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

        private static BarberRoot.Barber SelectBarber()
        {
            Console.WriteLine("Выберете мастера: ");
            var barber = BarberRoot.SelectBarber(Helper.OptionsSelector(BarberRoot.AvaliableBarber));
            Console.Clear();
            return barber;
        }

        private static Service SelectServices(Service service)
        {
            Console.WriteLine("Выберете стрижку:");
            service.Haircut = HairCutRoot.SelectHaircut(
                Helper.OptionsSelector(HairCutRoot.AvalibleHaircuts),
                service.Client.HairLength
            );

            Console.WriteLine("Выберете прическу:");
            service.HairStyle = HairStyleRoot.SelectHairStyle(
                Helper.OptionsSelector(HairStyleRoot.AvalibleHairStyles),
                service.Client.HairLength
            );

            Console.WriteLine("Выберете окрашивание:");
            service.HairDye = HairDyeRoot.SelectHairDye(
                Helper.OptionsSelector(HairDyeRoot.AvalibleHairDye),
                service.Client.HairLength
            );

            Console.WriteLine("Выберете украшения:");
            var Accessorieschoices = Helper.MultipleOptionsSelector(HairAccessoryRoot.AvaliableAccessories);
            var accessories = new List<HairAccessoryRoot.HairAccessory>();
            foreach (var choice in Accessorieschoices) {
                accessories.Add(HairAccessoryRoot.SelectAccessories(choice));
            }
            if (accessories.Contains(null)) {
                service.Accessories = null;
            }
            else {
                service.Accessories = accessories;
            }

            Console.WriteLine("Выберете уход:");
            var CareChoices = Helper.MultipleOptionsSelector(HairCareRoot.AvaliableCare);
            var cares = new List<HairCareRoot.HairCare>();
            foreach (var choice in CareChoices) {
                cares.Add(HairCareRoot.SelectCare(choice, service.Client.HairLength));
            }
            if (cares.Contains(null)) {
                service.Care = null;
            }
            else {
                service.Care = cares;
            }

            Console.Clear();
            return service;
        }
    }
}
