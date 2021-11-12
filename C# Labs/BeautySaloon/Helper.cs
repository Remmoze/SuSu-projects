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
            return options[OptionsSelectorIndex(options)];
        }

        public static List<string> MultipleOptionsSelector(string[] options)
        {
            while (true) {
                for (var i = 0; i < options.Length; i++) {
                    Console.WriteLine($"{i + 1}. {options[i]}");
                }
                Console.Write("Введите числа: ");
                var inputs = Console.ReadLine().Split(" ");
                var indexes = ParseInputs(inputs, 1, options.Length).Distinct().ToList();
                if(indexes.Count == 0) {
                    Console.WriteLine("Введите хотя бы одно число!");
                    continue;
                }

                var output = new List<string>();
                indexes.ForEach(index => output.Add(options[index - 1]));

                return output;
            }
        }

        private static List<int> ParseInputs(string[] inputs, int min, int max)
        {
            var output = new List<int>();
            foreach(var input in inputs) {
                if (!int.TryParse(input, out int index)) {
                    Console.WriteLine($"Значение {input} - не число!");
                    return new List<int>();
                }
                if(index < min) {
                    Console.WriteLine($"Значение {index} - не должно быть меньше {min}");
                    return new List<int>();
                }
                if (index > max) {
                    Console.WriteLine($"Значение {index} - не должно быть больше {max}");
                    return new List<int>();
                }
                output.Add(index);
            }
            return output;
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
    }
}
