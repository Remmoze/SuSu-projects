using System;

namespace BeautySaloon
{
    class BeautySaloon
    {
        public static void Main(string[] args)
        {
            var service = Menu.GetNewService();

            service.Test();

            //Console.WriteLine(service); 
        }
    }
}
