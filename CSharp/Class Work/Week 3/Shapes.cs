namespace Shapes {
    abstract class Shape {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    class Circle : Shape {
        public double radius;

        public Circle(double radius) {
            this.radius = radius;
        }

        public override double GetArea() {
            return Math.PI * Math.Pow(this.radius, 2);
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * this.radius;
        }
    }
}