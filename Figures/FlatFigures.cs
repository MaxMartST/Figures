using System;

namespace Figures
{
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
}
