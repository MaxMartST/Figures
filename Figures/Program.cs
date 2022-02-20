using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public enum TypeFigure
    {
        Square,
        Rectangle,
        Triangle,
        Circle,
        Cube,
        Ball
    }

    abstract class Figure
    {
        public Figure(TypeFigure typeFigure, string nameFigure)
        {
            if (nameFigure != null)
            {
                Name = nameFigure;
            }
            else
            {
                throw new Exception("Не заданно имя фигуры");
            }

            if (typeFigure is TypeFigure.Square)
            {
                Type = "Квадрат";
            }
            else if (typeFigure is TypeFigure.Rectangle)
            {
                Type = "Прямоугольник";
            }
            else if (typeFigure is TypeFigure.Triangle)
            {
                Type = "Треугольник";
            }
            else if (typeFigure is TypeFigure.Circle)
            {
                Type = "Круг";
            }
            else if (typeFigure is TypeFigure.Cube)
            {
                Type = "Куб";
            }
            else if (typeFigure is TypeFigure.Ball)
            {
                Type = "Шар";
            }
            else
            {
                throw new Exception("Тип не найден");
            }
        }
        public string Type { get; }
        public string Name { get; }
        public abstract double Perimeter();
        public abstract double Space();
        public abstract string GetInformationStringFigure();
    }

    abstract class ThreeDimensionalFigure : Figure
    {
        public ThreeDimensionalFigure(TypeFigure typeFigure, string nameFigure) : base(typeFigure, nameFigure)
        {
        }

        public abstract double Volume();
    }

    class Square : Figure
    {
        private double sizeSide;

        public Square(string nameFigure, double sizeSide) : base(TypeFigure.Square, nameFigure)
        {
            if (sizeSide <= 0)
            {
                throw new Exception("Размер стороны фигуры должен быть больше нуля");
            }
            
            this.sizeSide = sizeSide;
        }

        public override string GetInformationStringFigure()
        {
            return String.Format("Тип фигуры: {0}\nИмя фигуры: {1}\nПлощадь: {2}\nПеримерт: {3}",
                    Type,
                    Name,
                    Space(),
                    Perimeter());
        }

        public override double Perimeter()
        {
            return this.sizeSide * 4;
        }

        public override double Space()
        {
            return Math.Pow(this.sizeSide, 2);
        }
    }

    class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(string nameFigure, double width, double height) : base(TypeFigure.Rectangle, nameFigure)
        {
            if (width <= 0 || height <= 0)
            {
                throw new Exception("Размер стороны фигуры должен быть больше нуля");
            }

            this.width = width;
            this.height = height;
         
        }

        public override string GetInformationStringFigure()
        {
            return String.Format("Тип фигуры: {0}\nИмя фигуры: {1}\nПлощадь: {2}\nПеримерт: {3}",
                    Type,
                    Name,
                    Space(),
                    Perimeter());
        }

        public override double Perimeter()
        {
            return (this.width + this.height) * 2;
        }

        public override double Space()
        {
            return this.width * this.height;
        }
    }

    class Triangle : Figure
    {
        private double side1, side2, side3;

        public Triangle(string nameFigure, double side1, double side2, double side3) : base(TypeFigure.Triangle, nameFigure)
        {
            if (side1 <= 0 || side2 <= 0 || side1 <= 0)
            {
                throw new Exception("Размер стороны фигуры должен быть больше нуля");
            }

            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }

        public override string GetInformationStringFigure()
        {
            return String.Format("Тип фигуры: {0}\nИмя фигуры: {1}\nПлощадь: {2}\nПеримерт: {3}",
                    Type,
                    Name,
                    Space(),
                    Perimeter());
        }

        public override double Perimeter()
        {
            return this.side1 + this.side2 + this.side3;
        }

        public override double Space()
        {
            var semiP = this.Perimeter() / 2;
            var s = semiP * (semiP - this.side1) * (semiP - this.side2) * (semiP - this.side3);

            return Math.Sqrt(s);
        }
    }

    class Circle : Figure
    {
        private double radius;

        public Circle(string nameFigure, double radius) : base(TypeFigure.Circle, nameFigure)
        {
            if (radius <= 0)
            {
                throw new Exception("Радиус должен быть больше нуля");
            }

            this.radius = radius;
        }

        public override string GetInformationStringFigure()
        {
            return String.Format("Тип фигуры: {0}\nИмя фигуры: {1}\nПлощадь: {2}\nПеримерт: {3}",
                    Type,
                    Name,
                    Space(),
                    Perimeter());
        }

        public override double Perimeter()
        {
            return 0;
        }

        public override double Space()
        {
            return Math.PI * Math.Pow(this.radius, 2);
        }
    }

    class Cube : ThreeDimensionalFigure
    {
        private double sizeSide;

        public Cube(string nameFigure, double sizeSide) : base(TypeFigure.Cube, nameFigure)
        {
            if (sizeSide <= 0)
            {
                throw new Exception("Размер стороны фигуры должен быть больше нуля");
            }

            this.sizeSide = sizeSide;
        }

        public override string GetInformationStringFigure()
        {
            return String.Format("Тип фигуры: {0}\nИмя фигуры: {1}\nПлощадь: {2}\nПеримерт: {3}\nОбъем: {4}",
                    Type,
                    Name,
                    Space(),
                    Perimeter(),
                    Volume());
        }

        public override double Perimeter()
        {
            return 12 * this.sizeSide;
        }

        public override double Space()
        {
            return 6 * Math.Pow(this.sizeSide, 2);
        }

        public override double Volume()
        {
            return Math.Pow(this.sizeSide, 3);
        }
    }

    class Ball : ThreeDimensionalFigure
    {
        private double radius;

        public Ball(string nameFigure, double radius) : base(TypeFigure.Ball, nameFigure)
        {
            if (radius <= 0)
            {
                throw new Exception("Радиус должен быть больше нуля");
            }

            this.radius = radius;
        }

        public override string GetInformationStringFigure()
        {
            return String.Format("Тип фигуры: {0}\nИмя фигуры: {1}\nПлощадь: {2}\nПеримерт: {3}\nОбъем: {4}",
                    Type,
                    Name,
                    Space(),
                    Perimeter(),
                    Volume());
        }

        public override double Perimeter()
        {
            return 0;
        }

        public override double Space()
        {
            return 4 * Math.PI * Math.Pow(this.radius, 2);
        }

        public override double Volume()
        {
            return (4 * Math.PI * Math.Pow(this.radius, 3)) / 3;
        }
    }

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

        static void Main(string[] args)
        {
            int number = 0;
            Figure[] figures;

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

            try
            {
                figures = GetArrayFigure(number);

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
