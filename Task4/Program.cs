using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = new List<int>();
            if (args.Length == 0)
            {
                Console.WriteLine("Укажите путь к файлу");
                return;
            }
            var path = args[0];
            try
            {
                arr = File.ReadAllLines(path).Select(int.Parse).ToList();
                Solve(arr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.ReadKey();
        }

        private static void Solve(List<int> arr)
        {
            arr.Sort();
            var medianValue = arr[arr.Count / 2];
            long sum = 0;
            foreach (int x in arr)
            {
                sum += Math.Abs(x - medianValue);
            }

            Console.WriteLine(sum);
        }
    }
}