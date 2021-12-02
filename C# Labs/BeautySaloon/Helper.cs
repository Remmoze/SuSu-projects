using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautySaloon
{
    public static class Helper
    {
        public static int OptionsSelectorIndex(string[] options)
        {
            while (true) {
                for (var i = 0; i < options.Length; i++) {
                    Console.WriteLine($"{i + 1}. {options[i]}");
                }
                Console.Write("Введите число: ");

                if (!int.TryParse(Console.ReadLine(), out int index)) {
                    Console.WriteLine("Вы ввели не число!");
                    continue;
                }

                if (index <= 0 || index > options.Length) {
                    Console.WriteLine("Число не в диапазоне!");
                    continue;
                }

                return index - 1; 
            }
        }

        public static string OptionsSelector(string[] options)
        {
            var index = OptionsSelectorIndex(options);
            return options[index];
        }

        public static int GetInt(string title, int min, int max)
        {
            while (true) {
                Console.Write(title);
                if (!int.TryParse(Console.ReadLine(), out int val)) {
                    Console.WriteLine("Вы ввели не число!");
                    continue;
                }
                if (val < min) {
                    Console.WriteLine("Число должно быть больше чем " + min);
                    continue;
                }
                if (val > max) {
                    Console.WriteLine("Число должно быть меньше чем " + max);
                    continue;
                }
                return val;
            }
        }

        public static bool GetBool(string title)
        {
            while(true) {
                Console.Write("\n" + title + " (д/н):");
                var key = Console.ReadKey().KeyChar;
                switch(key) {
                    case 'm':
                    case '1':
                    case 'д':
                    case 'y': { 
                        return true; 
                    }

                    case 'н':
                    case 'n': return false;
                    default: {
                        Console.WriteLine("\n Вы должны написать букву д (да) или н (нет)!");
                        continue;
                    }
                }

            }
        }
    }
}
