using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_9
{
    class Program
    {
        static Random rnd = new Random();
        static ListItem Head;

        static void Main(string[] args)
        {

            ListItemWorks();


        }

        private static void ListItemWorks()
        {
            string userCommand = null;
            do
            {
                Console.WriteLine("1)Сформировать однонаправленный список");
                Console.WriteLine("2)Создать список с клавиатуры");
                Console.WriteLine("3)Перестановка элементов");
                Console.WriteLine("4)Перестановка элементов (рекурсивно)");
                Console.WriteLine("5)В главное меню");
                Console.Write(">");
                userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case "1":
                        Head = null;
                        GenerateList(rnd.Next(1, 10));
                        break;
                    case "3":
                        Reverse();
                        break;
                    case "4":
                        ListItem newHead = null;
                        ReverseRecur(Head, ref newHead);
                        PrintList(newHead);
                        break;
                    case "2":
                        Head = null;
                        int size = InputNumber("Введите количество элементов в списке:", x => x > 0);
                        GenerateListFromKey(size);
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "5");
        }

        private static void GenerateListFromKey(int size)
        {
            for (int i = 0; i < size; i++)
            {
                int data = InputNumber($"Введите элемент {i}:", x => true);
                ListItem item = new ListItem(data);
                item.Next = Head;
                Head = item;
            }
            PrintList(Head);
        }

        static void GenerateList(int size)
        {
            for (int i = 0; i < size; i++)
            {
                ListItem item = new ListItem(rnd.Next(0, 100));
                item.Next = Head;
                Head = item;
            }
            PrintList(Head);
        }
        static void PrintList(ListItem head)
        {
            ListItem item = head;
            while (item != null)
            {
                Console.Write(item.Data + " ");
                item = item.Next;
            }
            Console.WriteLine();
        }
        static void Reverse()
        {
            ListItem item = Head;
            ListItem newHead = null;

            while (item != null)
            {
                ListItem newItem = new ListItem(item.Data);
                newItem.Next = newHead;
                newHead = newItem;
                item = item.Next;
            }

            PrintList(newHead);
        }

        static void ReverseRecur(ListItem item, ref ListItem newHead)
        {
            if (item != null)
            {
                ListItem newItem = new ListItem(item.Data);
                newItem.Next = newHead;
                newHead = newItem;
                ReverseRecur (item.Next, ref newHead);
            }
        }

        private static int InputNumber(string prompt, Func<int, bool> condition)
        {
            Console.WriteLine(prompt);
            bool ok = false;
            int result = 0;

            do
            {
                string input = Console.ReadLine();
                ok = int.TryParse(input, out result) && condition(result);
                if (!ok)
                {
                    Console.WriteLine($"Неверное значение'{input}'. Повторите ввод.");
                }
            } while (!ok);
            return result;
        }

        public static string DupLicate(string s, int n)
        {
            string result = null;
            for (int i = 0; i < n; i++)
                result += s;
            return result;
        }

    }
}
