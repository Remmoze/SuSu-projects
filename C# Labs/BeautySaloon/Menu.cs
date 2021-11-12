using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            HairLength hair = Helper.SelectHairLength(Helper.OptionsSelector(Helper.AvaliableHairLength));
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
            var barber = Helper.SelectBarber(Helper.OptionsSelector(Helper.AvaliableBarber));
            Console.Clear();
            return barber;
        }

        private static Service SelectServices(Service service)
        {
            Console.WriteLine("Выберете стрижку:");
            service.Haircut = Helper.SelectHaircut(
                Helper.OptionsSelector(Helper.AvalibleHaircuts),
                service.Client.HairLength
            );

            Console.WriteLine("Выберете прическу:");
            service.HairStyle = Helper.SelectHairStyle(
                Helper.OptionsSelector(Helper.AvalibleHairStyles),
                service.Client.HairLength
            );

            Console.WriteLine("Выберете окрашивание:");
            service.HairDye = Helper.SelectHairDye(
                Helper.OptionsSelector(Helper.AvalibleHairDye),
                service.Client.HairLength
            );

            Console.WriteLine("Выберете украшения:");
            var Accessorieschoices = Helper.MultipleOptionsSelector(Helper.AvaliableAccessories);
            var accessories = new List<HairAccessory>();
            foreach (var choice in Accessorieschoices) {
                accessories.Add(Helper.SelectAccessories(choice));
            }
            if (accessories.Contains(null)) {
                service.Accessories = null;
            }
            else {
                service.Accessories = accessories;
            }

            Console.WriteLine("Выберете уход:");
            var CareChoices = Helper.MultipleOptionsSelector(Helper.AvaliableCare);
            var cares = new List<HairCare>();
            foreach (var choice in CareChoices) {
                cares.Add(Helper.SelectCare(choice, service.Client.HairLength));
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
