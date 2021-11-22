using System;
using System.Linq;
using System.Collections.Generic;

namespace BeautySaloon
{
    public class Service
    {
        public HairCutRoot.HairCut Haircut { get; set; }
        public HairStyleRoot.HairStyle HairStyle { get; set; }
        public HairDyeRoot.HairDye HairDye { get; set; }
        public List<HairAccessoryRoot.HairAccessory> Accessories { get; set; }
        public List<HairCareRoot.HairCare> Care { get; set; }

        public Client Client { get; set; }
        public BarberRoot.Barber Barber { get; set; }
        public Date Date { get; set; }

        public int CalculatePrice()
        {
            int totalPrice = 0;
            totalPrice += Haircut.FinalPrice();
            totalPrice += HairStyle.FinalPrice();

            if (HairDye != null)
                totalPrice += HairDye.FinalPrice();

            if (Accessories != null)
                totalPrice += Accessories.Sum(accessory => accessory.FinalPrice());

            if (Care != null)
                totalPrice += Care.Sum(care => care.FinalPrice());

            totalPrice += Barber.Price;
            return totalPrice;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine,
                "Услуга нашего салона для вас:",
                "Вы: " + Client,
                "",
                $"Вас будет обслуживать {Barber.Title} мастер",
                "Стрижка: " + Haircut.Style,
                "Прическа: " + HairStyle.Style,
                "Окрашивание: " + (HairDye == null ? "Нет" : HairDye.Style),
                "Украшения: " + (Accessories == null ? "Нет" : string.Join(", ", Accessories.Select(accessory => accessory.Style))),
                "Уход: " + (Care == null ? "Нет" : string.Join(", ", Care.Select(care => care.Style))),
                "",
                "Цена: " + CalculatePrice(),
                "Время приема: " + Date,
                "Не опаздывайте!"
            );
        }
    }
}