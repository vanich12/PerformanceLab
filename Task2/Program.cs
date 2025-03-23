using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Необходимо указать два пути к файлам");
                return;
            }


            string path1 = args[0];
            string path2 = args[1];

            string[] circleLines;
            try
            {
                circleLines = File.ReadAllLines(path1);
                var centerCircle = circleLines[0].Split(' ');
                var radiusCircle = double.Parse(circleLines[1]);

                string[] pointLines = File.ReadAllLines(path2);
                var points = new List<Point>();
                foreach (var pointLine in pointLines)
                {
                    var point = pointLine.Split(' ');
                    points.Add(new Point
                    {
                        X = double.Parse(point[0]),
                        Y = double.Parse(point[1])
                    });
                }

                foreach (var point in points)
                {
                    CalculateDistanceBetweenPoints(point, new Point
                    {
                        X = double.Parse(centerCircle[0]),
                        Y = double.Parse(centerCircle[1])
                    }, radiusCircle);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void CalculateDistanceBetweenPoints(Point p1, Point p2, double raduis)
        {
            // по теореме Пифагора :)
            var distance = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));

            // здесь идет проверка на равенство по сути, но так как равенства =+ может дать неверный результат сравнивается с 1e-9(ну то есть с маленьким числом)
            if (Math.Abs(distance - raduis) < 1e-9)
                Console.WriteLine("0");
            else if (distance < raduis)
                Console.WriteLine("1");
            else
                Console.WriteLine("2");
        }
    }


    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}