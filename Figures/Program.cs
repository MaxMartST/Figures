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
                    throw new FigureException("Тип фигуры не найден");
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

        static private int GetNumberFromInputString(string inputStr)
        {
            try
            {
                return Convert.ToInt32(inputStr);
            }
            catch (FormatException e)
            {
                throw new FigureException("Входная строка не является последовательностью цифр.");
            }
            catch (OverflowException e)
            {
                throw new FigureException("Число не помещается в int.");
            }  
        }

        static int GetNumberOfFigures()
        {
            int numberOfFigures = 0;

            while (numberOfFigures == 0)
            {
                try
                {
                    Console.Write("Задайте количество фигур: ");

                    string str = Console.ReadLine();
                    numberOfFigures = GetNumberFromInputString(str);

                    Console.WriteLine("Количество фигур равно {0}", numberOfFigures);
                    Console.WriteLine();
                    break;
                }
                catch (FigureException fe)
                {
                    Console.WriteLine($"Ошибка: {fe.Message}");
                }
            }

            return numberOfFigures;
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
            catch (FigureException fe)
            {
                Console.WriteLine($"Ошибка: {fe.Message}");
                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
