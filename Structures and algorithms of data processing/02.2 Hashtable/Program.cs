using System;
using System.IO;
using System.Text;

namespace _02._2_Hashtable {
    // класс хеш-таблицы
    public class Hashtable {

        // элемент хеш-таблицы
        public class node {
            public string word; // слово
            public int count; // встречаемость слова
            public node next = null; // указатель на следующий элемент
        }

        // размер таблицы
        public int Size { get; }
        // хранилице элементов
        public node[] nodes;

        // конструктор
        public Hashtable(int size) {
            Size = size;
            nodes = new node[Size];
        }

        // хеш-функция
        const uint FNV_PRIME = 16777619u;
        const uint OFFSET_BASIS = 2166136261u;
        public int hash(char data) {
            uint hash = OFFSET_BASIS;
            hash ^= data;
            hash *= FNV_PRIME;
            return (int)(hash % Size);
        }

        // счетчик сравнений при поиске
        public int _counter = 1;
        public node LookUp(string word) {
            char key = word[0];
            int index = hash(key);
            if(nodes[index] == null)
                return null;

            var nextNode = nodes[index];

            _counter = 1;
            if(nextNode.word == word)
                return nextNode;

            while(true) {
                _counter++;
                if(nextNode.word == word)
                    return nextNode;
                if(nextNode.next == null)
                    break;
                nextNode = nextNode.next;
            }
            return null;
        }

        // вставить элемент в таблицу
        private void Insert(node node, int index) {
            if(nodes[index] == null) {
                nodes[index] = node;
                return;
            }

            var nextNode = nodes[index];
            while(nextNode.next != null) {
                nextNode = nextNode.next;
            }
            nextNode.next = node;
        }

        // убрать элементы начинающиеся на данную букву
        public void Remove(char c) {
            int index = hash(c);
            if(nodes[index] == null) {
                return;
            }

            var nextNode = nodes[index];
            //убираем слово с первого места
            while(nextNode != null) {
                if(nextNode.word[0] != c) {
                    break;
                }
                nodes[index] = nextNode.next;
                nextNode = nextNode.next;
            }

            if(nextNode == null)
                return;

            while(true) {
                if(nextNode.next == null)
                    break;

                if(nextNode.next.word[0] != c) {
                    nextNode = nextNode.next;
                } else {
                    nextNode.next = nextNode.next.next;
                }
            }
        }

        // вставить слово в таблицу
        public void Add(string word) {
            char key = word[0];
            int index = hash(key);
            var node = LookUp(word);
            if(node == null) {
                node = new node() {
                    word = word,
                    count = 1,
                    next = null
                };
                Insert(node, index);
            } else {
                node.count++;
            }
        }
    }

    class Program {

        // импорт файла в хеш-таблицу
        static void Import(string filename, Hashtable hashtable) {
            var words = File.ReadAllText(filename).Split(" ");
            foreach(var word in words) {
                var sb = new StringBuilder();
                foreach(char c in word) {
                    if(char.IsLetterOrDigit(c))
                        sb.Append(c);
                }
                var cleanword = sb.ToString();
                if(string.IsNullOrWhiteSpace(cleanword))
                    continue;
                hashtable.Add(cleanword.ToLower());
            }
        }

        // печать хеш-таблицы
        static void Print(Hashtable hashtable) {
            var nodes = hashtable.nodes;
            for(int i = 0; i < hashtable.Size; i++) {
                // если элемент таблицы пуст - пропускаем
                if(nodes[i] == null)
                    continue;

                // в противном случае, печатаем его
                Console.WriteLine($"[{i}]: {nodes[i].word} : {nodes[i].count}");

                // если ветка коллизии не пуста - идем по ней и печатаем все значения
                var child = nodes[i].next;
                while(child != null) {
                    Console.WriteLine($"| -> {child.word}: {child.count}");
                    child = child.next;
                }
            }
        }

        static void Main(string[] args) {
            Console.Write("Введите размер таблицы: ");
            if(!int.TryParse(Console.ReadLine(), out int size)) {
                throw new InvalidCastException("Введенные данные - не число");
            }

            Hashtable hashtable = new Hashtable(size);
            Import(@"../../../WeDrive.txt", hashtable);
            Console.WriteLine("Import successful!");

            Console.WriteLine("Commands: , 'search xword', 'delete x', 'print', 'exit'\n");

            string[] input = null;
            string command = null;
            while(true) {
                Console.Write("\ncmd:> ");
                input = Console.ReadLine().Split(" ");
                command = input[0];
                switch(command) {
                    case "search": {
                        var result = hashtable.LookUp(input[1]);
                        if(result != null) {
                            Console.WriteLine($"{result.word}: {result.count}");
                            Console.WriteLine("Сравнений: " + hashtable._counter);
                        } else
                            Console.WriteLine("No word found.");
                    }; break;

                    case "delete": {
                        hashtable.Remove(input[1][0]);
                    }; break;

                    case "print": {
                        Print(hashtable);
                    }; break;

                    case "exit": {
                        Environment.Exit(0);
                    }; break;

                    default: {
                        Console.WriteLine("Incorrect command.");
                        break;
                    }

                }
            }
        }
    }
}
