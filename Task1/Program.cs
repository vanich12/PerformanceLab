
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Введите ДВА аргумента: n и m");
                return;
            }

            if (int.TryParse(args[0], out int n) && int.TryParse(args[1], out int m))
            {
                Solve(n, m);
                Console.ReadKey();
            }
            else
                throw new ArgumentException("Не корректные аргументы строки");

        }

        private static void Solve(int n, int m)
        {
            List<int> roundArray = new List<int>();
            List<int> resultArray = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                roundArray.Add(i);
            }

            int currentIndex = 0;
            while (true)
            {
                resultArray.Add(roundArray[currentIndex]);
                currentIndex = (currentIndex + m - 1) % n;
                if (currentIndex == 0)
                    break;
                
            }
            PrintArray(resultArray);
        }

        private static void PrintArray(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item);
            }
        }
    }
}