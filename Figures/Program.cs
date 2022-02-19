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

    /*    public static class Type
        {
            public static string GetTypeFigure(this TypeFigure te)
            {
                switch (te)
                {
                    case TypeFigure.Square:
                        return "Квадрат";
                    case TypeFigure.Rectangle:
                        return "Прямоугольник";
                    case TypeFigure.Triangle:
                        return "Треугольник";
                    case TypeFigure.Circle:
                        return "Круг";
                    case TypeFigure.Cube:
                        return "Куб";
                    case TypeFigure.Ball:
                        return "Шар";
                    default:
                        return "Тип не обнаружен";
                }
            }
        }*/

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

    class Square : Figure
    {
        private double sizeSide;

        public Square(string nameFigure, double sizeSide) : base(TypeFigure.Square, nameFigure)
        {
            if (sizeSide <= 0)
            {
                throw new Exception("Размер стороны фигуры должен быть больше нуля");
            }
            else
            {
                this.sizeSide = sizeSide;
            }
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
            else
            {
                this.width = width;
                this.height = height;
            }
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

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var square1 = new Square("Квадрат №1", 10);
                var square2 = new Square("Квадрат №2", 4);
                var rectangle1 = new Rectangle("Прямоугольник №1", 10, 20);
                var triangle1 = new Triangle("Треугольник №1", 15, 15, 15);
                var circle1 = new Circle("Круг №1", 25);

                Console.WriteLine("Фигура типа {0}, с именем {1}, имеет площадь равную {2} и перимерт равный {3}",
                    square1.Type,
                    square1.Name,
                    square1.Space(),
                    square1.Perimeter());

                Console.WriteLine("Фигура типа {0}, с именем {1}, имеет площадь равную {2} и перимерт равный {3}",
                    square2.Type,
                    square2.Name,
                    square2.Space(),
                    square2.Perimeter());

                Console.WriteLine("Фигура типа {0}, с именем {1}, имеет площадь равную {2} и перимерт равный {3}",
                    rectangle1.Type,
                    rectangle1.Name,
                    rectangle1.Space(),
                    rectangle1.Perimeter());

                Console.WriteLine("Фигура типа {0}, с именем {1}, имеет площадь равную {2} и перимерт равный {3}",
                    triangle1.Type,
                    triangle1.Name,
                    triangle1.Space(),
                    triangle1.Perimeter());

                Console.WriteLine("Фигура типа {0}, с именем {1}, имеет площадь равную {2} и перимерт равный {3}",
                    circle1.Type,
                    circle1.Name,
                    circle1.Space(),
                    circle1.Perimeter());
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
