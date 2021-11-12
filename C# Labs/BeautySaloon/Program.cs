using System;

namespace BeautySaloon
{
    class BeautySaloon
    {
        public static Menu ServiceSelector;
        public static void Main(string[] args)
        {
            ServiceSelector = new Menu();
            var service = ServiceSelector.GetNewService();

            Console.WriteLine(service); 
        }
    }
}
