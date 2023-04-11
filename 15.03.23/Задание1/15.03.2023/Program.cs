using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._03._2023
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ArrayList listForInsert = new ArrayList() { 1, 1, 1 };

            Console.WriteLine("Введите индекс начала");
            int index;
            if (Int32.TryParse(Console.ReadLine(), out index) && index >= 0 && index < list.Capacity)
                list.InsertRange(index, listForInsert);
            else
                Console.WriteLine("Неверный ввод");

            Console.WriteLine("Промежуточный список");
            foreach (var i in list)
                Console.Write($"{i} ");
            Console.Write("\n");

            Console.WriteLine("Введите кол-во чисел");
            int count;
            if (Int32.TryParse(Console.ReadLine(), out count) && count >= 0 && count < list.Capacity - index / 2)
                list.RemoveRange(index / 2, count);
            else
                Console.WriteLine("Неверный ввод");
            foreach (var i in list)
                Console.Write($"{i} ");

            Console.ReadLine();
        }
    }
}
