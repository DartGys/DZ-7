using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PrototypeFigure
{
    class Triangle1
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IFigure figure = new Rectangle(10, 20);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();
            figure = new Circle(15);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();
            figure = new Triangle(15, 20, 10);
            figure.GetInfo();
            clonedFigure = figure.Clone();
            clonedFigure.GetInfo();
            Console.Read();
        }
    }
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }
    class Triangle : IFigure
    {
        int FirstSide;
        int SecondSide;
        int ThirdSide;
        public Triangle(int f, int s, int t)
        {
            FirstSide = f;
            SecondSide = s;
            ThirdSide = t;
        }
        public IFigure Clone()
        {
            return new Triangle(this.FirstSide, this.SecondSide, this.ThirdSide);
        }
        public void GetInfo()
        {
            Console.WriteLine("Перша сторона {0} друга сторона {1} третя сторона {2}", FirstSide, SecondSide, ThirdSide);
        }
    }

    class Rectangle : IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }
        public IFigure Clone()
        {
            return new Rectangle(this.width, this.height);
        }
        public void GetInfo()
        {
            Console.WriteLine("Прямокутник довжиною {0} и шириною {1}", height, width);
        }
    }
    class Circle : IFigure
    {
        int radius;
        public Circle(int r)
        {
            radius = r;
        }
        public IFigure Clone()
        {
            return new Circle(this.radius);
        }
        public void GetInfo()
        {
            Console.WriteLine("Круг радіусом {0}", radius);
        }
    }
}
