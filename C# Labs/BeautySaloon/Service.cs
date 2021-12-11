using System;
using System.Linq;

namespace BeautySaloon
{
    public class Service
    {
        public Client Client;
        public Date Date;

        private readonly PricedItemsCollection<IPricedItem> Items = new();

        public Service(Client client, Date date)
        {
            Client = client;
            Date = date;
        }

        public void AddItem(IPricedItem item)
        {
            Items.Add(item);
        }

        public int CalculatePrice()
        {
            return Items.Sum(item => item.Price);
        }

        public void Test()
        {
            Console.WriteLine(ListServices());

            Items.Sort(delegate (IPricedItem x, IPricedItem y) {
                return x.CompareTo(y);
            });

            Console.WriteLine(ListServices());

            Items.Sort((x, y) => {
                return y.Price - x.Price;
            });

            Console.WriteLine(ListServices());

            Items.Sort((x, y) => x.CompareTo(y));


            Console.WriteLine(ListServices());

            Items.Sort((x, y) => x.Title.Length - y.Title.Length);

            Console.WriteLine(ListServices());
        }

        private string ListServices()
        {
            string str = "";
            foreach(var item in Items) {
                str += item.Title;
                str += " (" + item.Price + "), ";
            }
            return str;
        }

        public override string ToString()
        {
            var barber = Items.FirstOrDefault(item => item.Title.Contains("Мастер"));
            return string.Join(Environment.NewLine,
                "Вы: " + Client,
                "",
                $"Вас будет обслуживать {barber.Title}",
                "Наши услуги дла вас:",
                ListServices(),
                "",
                "Цена: " + CalculatePrice(),
                "Время приема: " + Date,
                "Не опаздывайте!"
            );
        }
    }
}