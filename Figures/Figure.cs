using System;

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
                throw new FigureException("Тип не найден");
            }
        }
        public string Type { get; }
        public string Name { get; }
        public abstract double Perimeter();
        public abstract double Space();
        public abstract string GetInformationStringFigure();
    }
}
