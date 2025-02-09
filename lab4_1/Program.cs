class Program
{

    abstract class Shape
    {
        private int x;
        private int y;
        private int height;
        private int width;
        protected Shape(int x, int y, int height, int width)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }

        public virtual void draw() { }
    }

    class Rectangle : Shape
    {
        public Rectangle(int x, int y, int height, int width) : base(x, y, height, width) { }

        public override void draw()
        {
            Console.WriteLine("Drawing rectangle");
        }
    }

    class Triangle : Shape
    {
        public Triangle(int x, int y, int height, int width) : base(x, y, height, width) { }

        public override void draw()
        {
            Console.WriteLine("Drawing triangle");
        }
    }

    class Circle : Shape
    {
        public Circle(int x, int y, int height, int width) : base(x, y, height, width) { }

        public override void draw()
        {
            Console.WriteLine("Drawing circle");
        }
    }






    public static void Main(String[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Rectangle rectangle = new Rectangle(10, 10, 20, 20);
        Triangle triangle = new Triangle(5, 5, 10, 15);
        Circle circle = new Circle(3, 2, 40, 35);
        shapes.Add(rectangle);
        shapes.Add(triangle);
        shapes.Add(circle);
        shapes.ForEach(x => x.draw());
    }
}
