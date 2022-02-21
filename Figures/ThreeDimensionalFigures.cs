using System;

namespace Figures
{
    abstract class ThreeDimensionalFigure : Figure
    {
        public ThreeDimensionalFigure(TypeFigure typeFigure, string nameFigure) : base(typeFigure, nameFigure)
        {
        }

        public abstract double Volume();
    }

    class Cube : ThreeDimensionalFigure
    {
        private double sizeSide;

        public Cube(string nameFigure, double sizeSide) : base(TypeFigure.Cube, nameFigure)
        {
            if (sizeSide <= 0)
            {
                throw new FigureException("Размер стороны фигуры должен быть больше нуля");
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
                throw new FigureException("Радиус должен быть больше нуля");
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
}
