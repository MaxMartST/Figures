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

        public Square(TypeFigure typeFigure, string nameFigure, double sizeSide) : base(typeFigure, nameFigure)
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
            return sizeSide * 4;
        }

        public override double Space()
        {
            return Math.Pow(sizeSide, 2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var square1 = new Square(TypeFigure.Square, "Квадрат №1", 10);
                var square2 = new Square(TypeFigure.Square, "Квадрат №2", 4);

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
