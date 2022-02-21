using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Program
    {
        static private int GetRandomSize()
        {
            Random rnd = new Random();
            int size = 0;

            do
            {
                size = rnd.Next(1, 1000);
            }
            while (size <= 0);

            return size;
        }

        static private Figure GetFigure(int numberFigure, int numberTypeFigure)
        {
            int sizeSide, sizeSide1, sizeSide2;

            switch (numberTypeFigure)
            {
                case (int)TypeFigure.Square:
                    sizeSide = GetRandomSize();
                    return new Square($"Квадрат №{numberFigure}", sizeSide);
                case (int)TypeFigure.Rectangle:
                    sizeSide = GetRandomSize();
                    sizeSide1 = GetRandomSize();
                    return new Rectangle($"Прямоугольник №{numberFigure}", sizeSide, sizeSide1);
                case (int)TypeFigure.Triangle:
                    sizeSide = GetRandomSize();
                    sizeSide1 = GetRandomSize();
                    sizeSide2 = GetRandomSize();
                    return new Triangle($"Треугольник №{numberFigure}", sizeSide, sizeSide1, sizeSide2);
                case (int)TypeFigure.Circle:
                    sizeSide = GetRandomSize();
                    return new Circle($"Круг №{numberFigure}", sizeSide);
                case (int)TypeFigure.Cube:
                    sizeSide = GetRandomSize();
                    return new Cube($"Куб №{numberFigure}", sizeSide);
                case (int)TypeFigure.Ball:
                    sizeSide = GetRandomSize();
                    return new Ball($"Шар №{numberFigure}", sizeSide);
                default:
                    throw new Exception("Тип фигуры не найден");
            }
        }

        static public Figure[] GetArrayFigure(int number)
        {
            Random rnd = new Random();
            Figure[] figures = new Figure[number];

            var max = Enum.GetNames(typeof(TypeFigure)).Length;

            for (int i = 0; i < figures.Length; i++)
            {
                var indexTypeFigure = rnd.Next(0, max);
                var numberFigure = i + 1;

                figures[i] = GetFigure(numberFigure, indexTypeFigure);
            }

            return figures;
        }

        static int GetNumberOfFigures()
        {
            int number = 0;

            while (number == 0)
            {
                try
                {
                    Console.Write("Задайте количество фигур: ");

                    string str = Console.ReadLine();
                    number = Convert.ToInt32(str);

                    Console.WriteLine("Количество фигур равно {0}", number);
                    Console.WriteLine();
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("The number cannot fit in int.");
                }
            }

            return number;
        }

        static void Main(string[] args)
        {
            int numberOfFigures = GetNumberOfFigures();

            try
            {
                Figure[] figures = GetArrayFigure(numberOfFigures);

                foreach (var figure in figures)
                {
                    Console.WriteLine(figure.GetInformationStringFigure());
                    Console.WriteLine();
                }

                Console.WriteLine("Поиск фигур с максимальной площадью и запись данных в файл figures.txt");
                double maxSpace = figures.Max(f => f.Space());
                var maxSpaceFigures = figures.Where(f => f.Space() == maxSpace);

                using (StreamWriter sw = new StreamWriter("figures.txt", false))
                {
                    foreach (var figure in maxSpaceFigures)
                    {
                        sw.WriteLine("Фигура под именем {0} имеет максимальную площадь: {1}",
                            figure.Name,
                            figure.Space());
                    }
                }

                Console.WriteLine("Запись данных в файл figures.txt завершена");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
