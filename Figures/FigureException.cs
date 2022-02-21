using System;

namespace Figures
{
    class FigureException : Exception
    {
        public FigureException(string message)
        : base(message) { }
    }
}
