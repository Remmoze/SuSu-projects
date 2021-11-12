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
                    Console.WriteLine($"{i + 1}. " + options[i]);
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
                    Console.WriteLine($"{i + 1}. " + options[i]);
                }
                Console.Write("Введите числа: ");
                var inputs = Console.ReadLine().Split(" ");
                var indexes = ParseInputs(inputs, 1, options.Length).Distinct().ToList();
                if(indexes.Count == 0) {
                    Console.WriteLine("Введите хотя бы одно число!");
                    continue;
                }

                var output = new List<string>();
                foreach(var index in indexes) {
                    output.Add(options[index-1]);
                }

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



        public static string[] AvaliableHairLength => new string[] {
            LongHairLength.Type,
            MediumHairLength.Type,
            ShortHairLength.Type
        };
        public static HairLength SelectHairLength(string type)
        {
            switch (type) {
                case LongHairLength.Type: return new LongHairLength();
                case MediumHairLength.Type: return new MediumHairLength();
                case ShortHairLength.Type: return new ShortHairLength();
                default: throw new Exception("Unknown Hair Length");
            }
        }

        public static string[] AvaliableBarber => new string[] {
            ExperiencedBarber.Type,
            IntermediateBarber.Type,
            BeginnerBarber.Type
        };
        public static Barber SelectBarber(string type)
        {
            switch (type) {
                case ExperiencedBarber.Type: return new ExperiencedBarber();
                case IntermediateBarber.Type: return new IntermediateBarber();
                case BeginnerBarber.Type: return new BeginnerBarber();
                default: throw new Exception("Unknown Barber experience");
            }
        }

        public static string[] AvalibleHaircuts => new string[] {
            BobbedHairCut.Type,
            FoxTailHairCut.Type,
            BangHairCut.Type
        };
        public static HairCut SelectHaircut(string type, HairLength length)
        {
            switch (type) {
                case BobbedHairCut.Type: return new BobbedHairCut(length);
                case FoxTailHairCut.Type: return new FoxTailHairCut(length);
                case BangHairCut.Type: return new BangHairCut(length);
                default: throw new Exception("Unknown Haircut");
            }
        }

        public static string[] AvalibleHairStyles => new string[] {
            CurledHairStyle.Type,
            BundleHairStyle.Type,
            BraidsHairStyle.Type
        };
        public static HairStyle SelectHairStyle(string type, HairLength length)
        {
            switch (type) {
                case CurledHairStyle.Type: return new CurledHairStyle(length);
                case BundleHairStyle.Type: return new BundleHairStyle(length);
                case BraidsHairStyle.Type: return new BraidsHairStyle(length);
                default: throw new Exception("Unknown Hair Style");
            }
        }

        public static string[] AvalibleHairDye => new string[] {
            HighlightingHairStyle.Type,
            NaturalHairStyle.Type,
            DyedHairStyle.Type,
            "Без окрашивания"
        };
        public static HairDye SelectHairDye(string type, HairLength length)
        {
            switch (type) {
                case HighlightingHairStyle.Type: return new HighlightingHairStyle(length);
                case NaturalHairStyle.Type: return new NaturalHairStyle(length);
                case DyedHairStyle.Type: return new DyedHairStyle(length);
                case "Без окрашивания": return null;
                default: throw new Exception("Unknown Hair Dye");
            }
        }

        public static string[] AvaliableAccessories => new string[] {
            Hairpins.Type,
            InvisibleHairpins.Type,
            Headbands.Type,
            Combs.Type,
            "Без Акксесуаров"
        };
        public static HairAccessory SelectAccessories(string type)
        {
            switch (type) {
                case Hairpins.Type: return new Hairpins();
                case InvisibleHairpins.Type: return new InvisibleHairpins();
                case Headbands.Type: return new Headbands();
                case Combs.Type: return new Combs();
                case "Без Акксесуаров": return null;
                default: throw new Exception("Unknown Hair Accessory");
            }
        }

        public static string[] AvaliableCare => new string[] {
            WashHairCare.Type,
            RestorationHairStyle.Type,
            BalmHairStyle.Type,
            TipsHairStyle.Type,
            "Без Ухода"
        };
        public static HairCare SelectCare(string type, HairLength length)
        {
            switch (type) {
                case WashHairCare.Type: return new WashHairCare(length);
                case RestorationHairStyle.Type: return new RestorationHairStyle(length);
                case BalmHairStyle.Type: return new BalmHairStyle(length);
                case TipsHairStyle.Type: return new TipsHairStyle(length);
                case "Без Ухода": return null;
                default: throw new Exception("Unknown Hair Accessory");
            }
        }

        //public static string[] AvaliableServices => new string[] {
        //    "Стрижка",
        //    "Прическа",
        //    "Окрашивание",
        //    "Украшения",
        //    "Уход",
        //};
    }
}
