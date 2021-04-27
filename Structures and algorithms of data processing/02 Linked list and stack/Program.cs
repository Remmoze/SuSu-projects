using System;
using System.IO;

namespace _02_Linked_list_and_stack {

    public class LinkedList {

        private Node Root = null;
        public LinkedList() {
            // Чтобы упростить себе жизнь, создаем "фальшивку" как перый элемент списка.
            // Данный элемент не будет учитываться в реальной работе списка, он служит
            // лишь для того, чтобы уменьшить размер кода и увеличить читабельность. 
            Root = new Node(new Account());
        }

        // Функция вставки элемента в список
        // Список всегда отсортирован.
        public void Append(Account account) {
            // Создаем новый элемент списка
            var newNode = new Node(account);

            // следим за текущим элементом
            var currentNode = Root;
            while(true) {

                // Если мы достигли конца списка, добавляем элемент.
                if(currentNode.next == null) {
                    InsertAfter(newNode, currentNode);
                    break;
                }

                // Сравниваем новый элемент с последующим в списке
                var result = newNode.Compare(currentNode.next);

                // Если новый элемент меньше или равен следующиму, то вставляем его после текущего элемента
                if(result <= 0) {
                    InsertAfter(newNode, currentNode);
                    break;
                }

                // идем дальше по списку.
                currentNode = currentNode.next;
            }
        }

        // Вставляем элемент node в список после элемента current
        private void InsertAfter(Node node, Node current) {
            node.next = current.next;
            current.next = node;
        }

        // Создаем список из массива.
        public static LinkedList FromArray(Account[] accounts) {
            var list = new LinkedList();
            foreach(var account in accounts) {
                list.Append(account);
            }
            return list;
        }

        // поиск по списку.
        public string Search(string param, int searchType) {
            string result = "";

            // Проверяем исходные данные на верность
            DateTime paramDate = new DateTime();
            if(searchType == 2 && !DateTime.TryParse(param, out paramDate)) {
                return "Не верные данные.";
            }

            var paramInt = 0;
            if(searchType == 3 && !Int32.TryParse(param, out paramInt)) {
                return "Не верные данные.";
            }

            // Добавляем элементы из списка, если они соответсвуют критериям
            var current = Root;
            while(current.next != null) {
                switch(searchType) {
                    case 1: {
                        if(current.next.data.UserLastname == param)
                            result += current.next.data;
                        break;
                    }
                    case 2: {
                        if(current.next.data.WorkoutStart == paramDate)
                            result += current.next.data;
                        break;
                    }
                    case 3: {
                        if(current.next.data.WorkoutDuration == paramInt)
                            result += current.next.data;
                        break;
                    }
                    default: {
                        result += current.next.data;
                        break;

                    }
                }
                current = current.next;
            }
            return result == "" ? "No data." : result;
        }

        // Перезаписываем ToString() чтобы корректно отображались данные.
        public override string ToString() {
            string result = "";
            var current = Root;
            while(current.next != null) {
                result += current.next.data.UserLastname + ", ";
                current = current.next;
            }
            return result == "" ? "No data." : result;
        }
    }

    // Класс элемента в списке
    // Следит за следующим элементом в списке, а также держит в себе информацию об учетной записи.
    public class Node {
        public Account data;
        public Node next = null;

        public Node(Account account) {
            data = account;
        }

        // функция сравнивая двух элементов в списке.
        public int Compare(Node node2) {
            var result = data.UserLastname.CompareTo(node2.data.UserLastname);
            if(result != 0)
                return result;
            result = data.WorkoutStart.CompareTo(node2.data.WorkoutStart);
            if(result != 0)
                return result;
            return data.WorkoutDuration.CompareTo(node2.data.WorkoutDuration);
        }
    }

    public class Account {
        public string UserLastname;

        public string SportsCode;
        public string CoachLastname;

        public DateTime WorkoutStart;

        public int WorkoutDuration;
        public int Payment;

        // Перезаписываем ToString() чтобы корректно отображались данные.
        public override string ToString() {
            string result = "";
            result += "\nФамилия: " + UserLastname;
            result += "\nКод и вид занятия: " + SportsCode;
            result += "\nТренер: " + CoachLastname;
            result += "\nДата и время начала занятий: " + WorkoutStart.ToString();
            result += "\nКоличество минут тренировки: " + WorkoutDuration;
            result += "\nТариф: " + Payment + "р.";
            return result;
        }
    }

    class Program {

        // Загружаем данные об аккаунтов из файла.
        public static Account[] ImportData() {
            string[] lines = File.ReadAllLines(@"../../../data.txt");
            var accounts = new Account[lines.Length / 6];

            for(int i = 0, j = 0; i < lines.Length; j++) {
                accounts[j] = new Account() {
                    UserLastname = lines[i++],
                    SportsCode = lines[i++],
                    CoachLastname = lines[i++],
                    WorkoutStart = Convert.ToDateTime(lines[i++]),
                    WorkoutDuration = Convert.ToInt32(lines[i++]),
                    Payment = Convert.ToInt32(lines[i++]),
                };
            }

            return accounts;
        }

        static void Main(string[] args) {
            var list = LinkedList.FromArray(ImportData());

            var next = true;
            do {
                Console.Clear();
                Console.WriteLine("1. Найти по фамилии");
                Console.WriteLine("2. Найти по дате начала занятий");
                Console.WriteLine("3. Найти по количеству минут тренировки");

                Console.WriteLine("Введите цифру метода поиска и параметр поиска. Пример: \"1 Лебедев\"");
                var result = Console.ReadLine();
                var type = Convert.ToInt32(result.Split(" ")[0]);
                if(type == 1 || type == 2 || type == 3) {
                    Console.WriteLine(list.Search(result.Substring(2), type));
                } else {
                    Console.WriteLine("Не верная цифра ввода.");
                }

                Console.WriteLine("\nЧтобы продолжить, нажмите любую кнопку.");
                Console.WriteLine("Чтобы закрыть программу, нажмите Esc.");
                next = Console.ReadKey(true).Key != ConsoleKey.Escape;
            } while(next);
        }
    }
}
