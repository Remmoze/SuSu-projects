using System;

namespace BeautySaloon
{
    public class Service
    {
        public HairCut Haircut;
        public HairStyle HairStyle;
        public HairDye HairDye;
        public HairAccessory Accessories;
        public HairCare Care;

        public Client Client;
        public Barber Barber;
        public Date Date;

        public Service(Client client, Barber barber, Date date)
        {
            Client = client;
            Barber = barber;
            Date = date;
        }

        public int CalculatePrice()
        {
            int totalPrice = 0;
            if (Haircut != null) totalPrice += Haircut.FinalPrice();
            if (HairStyle != null) totalPrice += HairStyle.FinalPrice();
            if (HairDye != null) totalPrice += HairDye.FinalPrice();
            if (Accessories != null) totalPrice += Accessories.FinalPrice();
            if (Care != null) totalPrice += Care.FinalPrice();

            totalPrice += Barber.Price;
            return totalPrice;
        }

        private string ListServices()
        {
            string list = "";
            if (Haircut != null) list += "Стрижка, ";
            if (HairStyle != null) list += "Прическа, ";
            if (HairDye != null) list += "Окрашивание, ";
            if (Accessories != null) list += "Украшения, ";
            if (Care != null) list += "Уход";
            return list;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine,
                "Вы: " + Client,
                "",
                $"Вас будет обслуживать {Barber.Title} мастер",
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