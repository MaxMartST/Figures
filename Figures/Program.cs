using System;
using System.Collections.Generic;
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
        static private Figure GetFigure(int numberFigure, int numberTypeFigure)
        {
            switch (numberTypeFigure)
            {
                case (int)TypeFigure.Square:
                    return new Square($"Квадрат №{numberFigure}", 10);
                case (int)TypeFigure.Rectangle:
                    return new Rectangle($"Прямоугольник №{numberFigure}", 10, 20);
                case (int)TypeFigure.Triangle:
                    return new Triangle($"Треугольник №{numberFigure}", 15, 15, 15);
                case (int)TypeFigure.Circle:
                    return new Circle($"Круг №{numberFigure}", 25);
                case (int)TypeFigure.Cube:
                    return new Cube($"Куб №{numberFigure}", 10);
                case (int)TypeFigure.Ball:
                    return new Ball($"Шар №{numberFigure}", 20);
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
                var indexTypeFigure = rnd.Next(0, max - 1);
                var numberFigure = i + 1;

                figures[i] = GetFigure(numberFigure, indexTypeFigure);
            }

            return figures;
        }

        static void Main(string[] args)
        {
            int number = 0;

            //while (number == 0)
            //{
            //    try
            //    {
            //        Console.Write("Задайте количество фигур: ");

            //        string str = Console.ReadLine();
            //        number = Convert.ToInt32(str);

            //        Console.Write("Количество фигур равно {0}", number);
            //        break;
            //    }
            //    catch (FormatException e)
            //    {
            //        Console.WriteLine("Input string is not a sequence of digits.");
            //    }
            //    catch (OverflowException e)
            //    {
            //        Console.WriteLine("The number cannot fit in int.");
            //    }
            //}

            //number = 0;
            //string figure;

            //switch (number)
            //{
            //    case (int)TypeFigure.Square:
            //        figure = "Квадрат";
            //        break;
            //    case (int)TypeFigure.Rectangle:
            //        figure = "Прямоугольник";
            //        break;
            //    case (int)TypeFigure.Triangle:
            //        figure = "Треугольник";
            //        break;
            //    case (int)TypeFigure.Circle:
            //        figure = "Круг";
            //        break;
            //    case (int)TypeFigure.Cube:
            //        figure = "Куб";
            //        break;
            //    case (int)TypeFigure.Ball:
            //        figure = "Шар";
            //        break;
            //    default:
            //        figure = "нет типа";
            //        break;
            //}

            //Console.WriteLine(figure);

            var figures = GetArrayFigure(2);

            foreach (var figure in figures)
            {
                var name = figure.Name;
                var type = figure.Type;

                Console.WriteLine("Фигура типа {0}, с именем {1}", type, name);
            }

            try
            {
                //var square1 = new Square("Квадрат №1", 10);
                //var rectangle1 = new Rectangle("Прямоугольник №1", 10, 20);
                //var triangle1 = new Triangle("Треугольник №1", 15, 15, 15);
                //var circle1 = new Circle("Круг №1", 25);

                //var cube1 = new Cube("Куб №1", 10);
                //var ball1 = new Ball("Шар №1", 20);

                //Console.WriteLine("Фигура типа {0}, с именем {1}, имеет площадь равную {2} и перимерт равный {3}",
                //    square1.Type,
                //    square1.Name,
                //    square1.Space(),
                //    square1.Perimeter());

                //Console.WriteLine("Фигура типа {0}, с именем {1}, имеет площадь равную {2} и перимерт равный {3}",
                //    rectangle1.Type,
                //    rectangle1.Name,
                //    rectangle1.Space(),
                //    rectangle1.Perimeter());

                //Console.WriteLine("Фигура типа {0}, с именем {1}, имеет площадь равную {2} и перимерт равный {3}",
                //    triangle1.Type,
                //    triangle1.Name,
                //    triangle1.Space(),
                //    triangle1.Perimeter());

                //Console.WriteLine("Фигура типа {0}, с именем {1}, имеет площадь равную {2} и перимерт равный {3}",
                //    circle1.Type,
                //    circle1.Name,
                //    circle1.Space(),
                //    circle1.Perimeter());

                //Console.WriteLine("Фигура типа {0}, с именем {1}, имеет площадь равную {2}, перимерт равный {3} и объем равный {4}",
                //    cube1.Type,
                //    cube1.Name,
                //    cube1.Space(),
                //    cube1.Perimeter(),
                //    cube1.Volume());

                //Console.WriteLine("Фигура типа {0}, с именем {1}, имеет площадь равную {2}, перимерт равный {3} и объем равный {4}",
                //    ball1.Type,
                //    ball1.Name,
                //    ball1.Space(),
                //    ball1.Perimeter(),
                //    ball1.Volume());
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
